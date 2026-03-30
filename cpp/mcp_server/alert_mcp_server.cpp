/*
 * Alert MCP Server — C++17
 *
 * Exposes 3 tools to GitHub Copilot via the Model Context Protocol (MCP)
 * using a hand-rolled JSON-RPC 2.0 implementation over stdio.
 *
 * Transport: Stdio only (VS Code spawns this as a child process)
 * C++ does not have an official MCP SDK — this implements the wire protocol
 * directly. For production use, prefer the TypeScript or C# scaffolds.
 *
 * Requires: nlohmann/json (single-header)
 *   curl -L https://github.com/nlohmann/json/releases/latest/download/json.hpp \
 *        -o cpp/mcp_server/json.hpp
 *
 * Compile & run:
 *   g++ -std=c++17 -o alert-mcp-server alert_mcp_server.cpp
 *   ./alert-mcp-server
 */

#include <iostream>
#include <string>
#include <vector>
#include <sstream>
#include <chrono>
#include <iomanip>
#include "json.hpp"

using json = nlohmann::json;

// ── Types ─────────────────────────────────────────────────────────────────────

struct Alert {
    std::string id;
    std::string title;
    std::string severity;
    std::string status;
    std::string source;
    std::string timestamp;
};

// ── Helpers ───────────────────────────────────────────────────────────────────

std::string now_iso() {
    auto t = std::chrono::system_clock::now();
    std::time_t tt = std::chrono::system_clock::to_time_t(t);
    std::ostringstream ss;
    ss << std::put_time(std::gmtime(&tt), "%Y-%m-%dT%H:%M:%SZ");
    return ss.str();
}

json alert_to_json(const Alert& a) {
    return { {"id", a.id}, {"title", a.title}, {"severity", a.severity},
             {"status", a.status}, {"source", a.source}, {"timestamp", a.timestamp} };
}

// ── In-memory alert store (POC) ───────────────────────────────────────────────
// TODO: Use the /generate-alerts skill to populate with more realistic data

std::vector<Alert> alertStore = {
    {"1", "High CPU usage on prod-01",            "critical", "open",         "monitoring",     now_iso()},
    {"2", "Disk space below 10% on db-server",    "high",     "open",         "infrastructure", now_iso()},
    {"3", "API response latency spike (p99 > 2s)","medium",   "acknowledged", "api-gateway",    now_iso()},
    {"4", "SSL certificate expiring in 7 days",   "low",      "open",         "security",       now_iso()},
};

// ── Tool: tools/list ─────────────────────────────────────────────────────────

json handle_list_tools() {
    return {
        {"tools", json::array({
            {
                {"name", "get_alerts"},
                {"description", "Get alerts, optionally filtered by severity"},
                {"inputSchema", {
                    {"type", "object"},
                    {"properties", {
                        {"severity", {
                            {"type", "string"},
                            {"enum", {"critical","high","medium","low"}},
                            {"description", "Filter by severity (optional)"}
                        }}
                    }}
                }}
            },
            {
                {"name", "get_alert_stats"},
                {"description", "Get count of alerts broken down by severity"},
                {"inputSchema", {{"type", "object"}, {"properties", json::object()}}}
            },
            {
                {"name", "create_alert"},
                {"description", "Create a new alert in the alert management system"},
                {"inputSchema", {
                    {"type", "object"},
                    {"required", {"title", "severity"}},
                    {"properties", {
                        {"title",    {{"type","string"}, {"description","Short description"}}},
                        {"severity", {{"type","string"}, {"enum", {"critical","high","medium","low"}}}},
                        {"source",   {{"type","string"}, {"description","Triggering system (optional)"}}}
                    }}
                }}
            }
        })}
    };
}

// ── Tool: tools/call ──────────────────────────────────────────────────────────

json handle_call_tool(const json& params) {
    std::string name = params.value("name", "");
    json args = params.value("arguments", json::object());

    if (name == "get_alerts") {
        json results = json::array();
        std::string sev = args.value("severity", "");
        for (const auto& a : alertStore) {
            if (sev.empty() || a.severity == sev) results.push_back(alert_to_json(a));
        }
        return {{"content", {{{"type","text"}, {"text", results.dump(2)}}}}};
    }

    if (name == "get_alert_stats") {
        json bySeverity = json::object();
        for (const auto& a : alertStore) {
            bySeverity[a.severity] = bySeverity.value(a.severity, 0) + 1;
        }
        json stats = {{"total", (int)alertStore.size()}, {"bySeverity", bySeverity}};
        return {{"content", {{{"type","text"}, {"text", stats.dump(2)}}}}};
    }

    if (name == "create_alert") {
        // TODO: Ask Copilot to add input validation using inline chat (/fix)
        Alert a;
        a.id        = std::to_string(alertStore.size() + 1);
        a.title     = args.value("title", "");
        a.severity  = args.value("severity", "low");
        a.status    = "open";
        a.source    = args.value("source", "manual");
        a.timestamp = now_iso();
        alertStore.push_back(a);
        std::string msg = "✅ Alert created:\n" + alert_to_json(a).dump(2);
        return {{"content", {{{"type","text"}, {"text", msg}}}}};
    }

    return {{"error", {{"code", -32601}, {"message", "Unknown tool: " + name}}}};
}

// ── JSON-RPC loop (stdio transport) ──────────────────────────────────────────

int main() {
    std::cerr << "🚀 Alert MCP Server running (stdio transport)" << std::endl;

    std::string line;
    while (std::getline(std::cin, line)) {
        if (line.empty()) continue;
        json req;
        try { req = json::parse(line); } catch (...) { continue; }

        std::string method = req.value("method", "");
        json id = req.value("id", nullptr);
        json result;

        if (method == "initialize") {
            result = {{"protocolVersion","2024-11-05"}, {"capabilities",{{"tools",json::object()}}},
                      {"serverInfo",{{"name","alert-mcp-server"},{"version","1.0.0"}}}};
        } else if (method == "tools/list") {
            result = handle_list_tools();
        } else if (method == "tools/call") {
            result = handle_call_tool(req.value("params", json::object()));
        } else {
            json err = {{"jsonrpc","2.0"},{"id",id},{"error",{{"code",-32601},{"message","Method not found"}}}};
            std::cout << err.dump() << "\n";
            std::cout.flush();
            continue;
        }

        json resp = {{"jsonrpc","2.0"}, {"id",id}, {"result",result}};
        std::cout << resp.dump() << "\n";
        std::cout.flush();
    }
    return 0;
}
