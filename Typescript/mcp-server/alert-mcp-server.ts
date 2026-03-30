/**
 * Alert MCP Server — TypeScript/Node.js
 *
 * Exposes 3 tools to GitHub Copilot via the Model Context Protocol (MCP):
 *   get_alerts(severity?)   → query the in-memory alert store
 *   get_alert_stats()       → severity breakdown count
 *   create_alert(...)       → add a new alert
 *
 * Transport: Stdio (default — VS Code spawns this as a child process)
 * To switch to HTTP Streamable or SSE, run /MCP-Server-Builder in Copilot Chat.
 *
 * Install & run:
 *   npm install
 *   npx ts-node alert-mcp-server.ts
 */

import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import {
  CallToolRequestSchema,
  ListToolsRequestSchema,
} from "@modelcontextprotocol/sdk/types.js";

// ── Types ────────────────────────────────────────────────────────────────────

type Severity = "critical" | "high" | "medium" | "low";
type AlertStatus = "open" | "acknowledged" | "resolved";

interface Alert {
  id: string;
  title: string;
  severity: Severity;
  status: AlertStatus;
  source: string;
  timestamp: string;
}

// ── In-memory alert store (POC) ───────────────────────────────────────────────
// TODO: Use the /generate-alerts skill to populate with more realistic data

const alertStore: Alert[] = [
  { id: "1", title: "High CPU usage on prod-01", severity: "critical", status: "open", source: "monitoring", timestamp: new Date().toISOString() },
  { id: "2", title: "Disk space below 10% on db-server", severity: "high", status: "open", source: "infrastructure", timestamp: new Date().toISOString() },
  { id: "3", title: "API response latency spike (p99 > 2s)", severity: "medium", status: "acknowledged", source: "api-gateway", timestamp: new Date().toISOString() },
  { id: "4", title: "SSL certificate expiring in 7 days", severity: "low", status: "open", source: "security", timestamp: new Date().toISOString() },
];

// ── MCP Server ────────────────────────────────────────────────────────────────

const server = new Server(
  { name: "alert-mcp-server", version: "1.0.0" },
  { capabilities: { tools: {} } }
);

// ── Tool Definitions ──────────────────────────────────────────────────────────

server.setRequestHandler(ListToolsRequestSchema, async () => ({
  tools: [
    {
      name: "get_alerts",
      description: "Get alerts from the alert management system, optionally filtered by severity",
      inputSchema: {
        type: "object",
        properties: {
          severity: {
            type: "string",
            enum: ["critical", "high", "medium", "low"],
            description: "Filter by severity (optional — omit to get all alerts)",
          },
        },
      },
    },
    {
      name: "get_alert_stats",
      description: "Get a summary count of alerts broken down by severity level",
      inputSchema: { type: "object", properties: {} },
    },
    {
      name: "create_alert",
      description: "Create a new alert in the alert management system",
      inputSchema: {
        type: "object",
        required: ["title", "severity"],
        properties: {
          title: { type: "string", description: "Short description of the alert" },
          severity: {
            type: "string",
            enum: ["critical", "high", "medium", "low"],
          },
          source: {
            type: "string",
            description: "System or service that triggered the alert (optional)",
          },
        },
      },
    },
  ],
}));

// ── Tool Handlers ─────────────────────────────────────────────────────────────

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  const { name, arguments: args } = request.params;

  switch (name) {
    case "get_alerts": {
      const results = args?.severity
        ? alertStore.filter((a) => a.severity === args.severity)
        : alertStore;
      return {
        content: [{ type: "text", text: JSON.stringify(results, null, 2) }],
      };
    }

    case "get_alert_stats": {
      const bySeverity = alertStore.reduce((acc, a) => {
        acc[a.severity] = (acc[a.severity] ?? 0) + 1;
        return acc;
      }, {} as Record<string, number>);
      return {
        content: [
          { type: "text", text: JSON.stringify({ total: alertStore.length, bySeverity }, null, 2) },
        ],
      };
    }

    case "create_alert": {
      // TODO: Ask Copilot to add input validation using inline chat (/fix)
      const newAlert: Alert = {
        id: String(alertStore.length + 1),
        title: args!.title as string,
        severity: args!.severity as Severity,
        status: "open",
        source: (args?.source as string) ?? "manual",
        timestamp: new Date().toISOString(),
      };
      alertStore.push(newAlert);
      return {
        content: [{ type: "text", text: `✅ Alert created:\n${JSON.stringify(newAlert, null, 2)}` }],
      };
    }

    default:
      throw new Error(`Unknown tool: ${name}`);
  }
});

// ── TRANSPORT — swap this block to switch transport modes ─────────────────────
// See /MCP-Server-Builder prompt for HTTP Streamable or SSE alternatives

async function main() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
  console.error("🚀 Alert MCP Server running (stdio transport)");
}

main().catch(console.error);
