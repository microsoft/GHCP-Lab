/*
 * Alert MCP Server — C#/.NET
 *
 * Exposes 3 tools to GitHub Copilot via the Model Context Protocol (MCP):
 *   get_alerts(severity?)   → query the in-memory alert store
 *   get_alert_stats()       → severity breakdown count
 *   create_alert(...)       → add a new alert
 *
 * Transport: Stdio (default — VS Code spawns this as a child process)
 * To switch to HTTP Streamable, run /MCP-Server-Builder in Copilot Chat.
 *
 * Install & run:
 *   dotnet restore
 *   dotnet run
 */

using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text.Json;

// ── In-memory alert store (POC) ───────────────────────────────────────────────
// TODO: Use the /generate-alerts skill to populate with more realistic data

var alertStore = new List<Alert>
{
    new("1", "High CPU usage on prod-01",       "critical", "open",         "monitoring",     DateTime.UtcNow),
    new("2", "Disk space below 10% on db-server","high",    "open",         "infrastructure", DateTime.UtcNow),
    new("3", "API response latency spike (p99 > 2s)", "medium", "acknowledged", "api-gateway", DateTime.UtcNow),
    new("4", "SSL certificate expiring in 7 days","low",    "open",         "security",       DateTime.UtcNow),
};

// ── Host & Transport ──────────────────────────────────────────────────────────
// TRANSPORT — swap .WithStdioServerTransport() to switch modes
// See /MCP-Server-Builder prompt for HTTP Streamable alternative

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<AlertTools>();

// Pass the shared store to the tools via DI
builder.Services.AddSingleton(alertStore);

var app = builder.Build();
Console.Error.WriteLine("🚀 Alert MCP Server running (stdio transport)");
await app.RunAsync();

// ── Types ─────────────────────────────────────────────────────────────────────

record Alert(string Id, string Title, string Severity, string Status, string Source, DateTime Timestamp);

// ── MCP Tools ─────────────────────────────────────────────────────────────────

[McpServerToolType]
public class AlertTools(List<Alert> store)
{
    [McpServerTool, Description("Get alerts from the alert management system, optionally filtered by severity.")]
    public string GetAlerts(
        [Description("Filter by severity: critical, high, medium, low. Omit for all.")] string? severity = null)
    {
        var results = severity is null
            ? store
            : store.Where(a => a.Severity == severity).ToList();
        return JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
    }

    [McpServerTool, Description("Get a summary count of alerts broken down by severity level.")]
    public string GetAlertStats()
    {
        var bySeverity = store.GroupBy(a => a.Severity)
            .ToDictionary(g => g.Key, g => g.Count());
        var stats = new { total = store.Count, bySeverity };
        return JsonSerializer.Serialize(stats, new JsonSerializerOptions { WriteIndented = true });
    }

    [McpServerTool, Description("Create a new alert in the alert management system.")]
    public string CreateAlert(
        [Description("Short description of the alert")] string title,
        [Description("Severity level: critical, high, medium, low")] string severity,
        [Description("System or service that triggered the alert (optional)")] string? source = "manual")
    {
        // TODO: Ask Copilot to add input validation using inline chat (/fix)
        var newAlert = new Alert(
            Id: (store.Count + 1).ToString(),
            Title: title,
            Severity: severity,
            Status: "open",
            Source: source ?? "manual",
            Timestamp: DateTime.UtcNow
        );
        store.Add(newAlert);
        return $"✅ Alert created:\n{JsonSerializer.Serialize(newAlert, new JsonSerializerOptions { WriteIndented = true })}";
    }
}
