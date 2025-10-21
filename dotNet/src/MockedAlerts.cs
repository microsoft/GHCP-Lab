using System;
using System.Collections.Generic;
using SOC.AdvancedCopilot.Models;

namespace Mocks;

public class MockedAlerts
{
    public static List<Alert> GetMockedAlerts()
    {
        return new List<Alert>
        {
            new Alert
            {
                Id = "1",
                Name = "Microservice communication timeout spikes",
                Description = "Detected spikes in timeout failures for microservice calls in Load Balancer for East US",
                CreatedDate = DateTime.Now.AddDays(2),
                LocationName = "Quincy",
                Latitude = 42.3601,
                Longitude = -71.0589,
                Severity = AlertSeverity.Warning,
                Status = AlertStatus.Active,
                Source = "Load Balancer"
            },
            new Alert
            {
                Id = "2",
                Name = "DNS resolution intermittent latency in secondary zones",
                Description = "Intermittent latency observed in DNS resolution for secondary zones impacting service accessibility.",
                CreatedDate = DateTime.Now.AddDays(4),
                LocationName = "Denver",
                Latitude = 39.7392,
                Longitude = -104.9903,
                Severity = AlertSeverity.Info,
                Status = AlertStatus.Resolved,
                Source = "DNS Service"
            },
            new Alert
            {
                Id = "3",
                Name = "Increased error rates in authentication service",
                Description = "Observed a rise in 500 Internal Server Errors in the authentication microservice affecting user logins.",
                CreatedDate = DateTime.Now.AddDays(1),
                LocationName = "San Francisco",
                Latitude = 37.7749,
                Longitude = -122.4194,
                Severity = AlertSeverity.Critical,
                Status = AlertStatus.Active,
                Source = "Authentication Service"
            },
            new Alert
            {
                Id = "4",
                Name = "Object storage service throttling affecting uploads",
                Description = "Increased throttling events in the object storage service leading to failed or delayed file uploads.",
                CreatedDate = DateTime.Now.AddDays(3),
                LocationName = "San Francisco",
                Latitude = 37.7749,
                Longitude = -122.4194,
                Severity = AlertSeverity.Warning,
                Status = AlertStatus.Acknowledged,
                Source = "Storage Service"
            },
            new Alert
            {
                Id = "5",
                Name = "Notification delivery service minor delays",
                Description = "Minor delays observed in the notification delivery service impacting user alerts.",
                CreatedDate = DateTime.Now.AddDays(5),
                LocationName = "Redmond",
                Latitude = 47.6740,
                Longitude = -122.1215,
                Severity = AlertSeverity.Warning,
                Status = AlertStatus.Acknowledged,
                Source = "Notification Service"
            },
            new Alert
            {
                Id = "6",
                Name = "Database connection pool exhaustion in primary cluster",
                Description = "Connection pool exhaustion detected in the primary database cluster causing application timeouts and degraded performance.",
                CreatedDate = DateTime.Now.AddDays(-1),
                LocationName = "Tokyo",
                Latitude = 35.6762,
                Longitude = 139.6503,
                Severity = AlertSeverity.Error,
                Status = AlertStatus.Active,
                Source = "Database Service"
            },
            new Alert
            {
                Id = "7",
                Name = "Content delivery network cache miss rate spike",
                Description = "Unusual spike in cache miss rates across CDN edge nodes resulting in increased origin server load and slower content delivery.",
                CreatedDate = DateTime.Now.AddDays(-3),
                LocationName = "London",
                Latitude = 51.5074,
                Longitude = -0.1278,
                Severity = AlertSeverity.Warning,
                Status = AlertStatus.Resolved,
                Source = "CDN Service"
            },
            new Alert
            {
                Id = "8",
                Name = "Message queue processing backlog critical threshold",
                Description = "Message processing backlog has exceeded critical thresholds leading to delayed task execution and potential data loss.",
                CreatedDate = DateTime.Now.AddHours(-6),
                LocationName = "Sydney",
                Latitude = -33.8688,
                Longitude = 151.2093,
                Severity = AlertSeverity.Critical,
                Status = AlertStatus.Active,
                Source = "Message Queue Service"
            },
            new Alert
            {
                Id = "9",
                Name = "API gateway rate limiting anomalies",
                Description = "Detected anomalous patterns in API gateway rate limiting causing legitimate requests to be incorrectly throttled.",
                CreatedDate = DateTime.Now.AddDays(-2),
                LocationName = "Mumbai",
                Latitude = 19.0760,
                Longitude = 72.8777,
                Severity = AlertSeverity.Info,
                Status = AlertStatus.Acknowledged,
                Source = "API Gateway"
            },
            new Alert
            {
                Id = "10",
                Name = "Container orchestration resource allocation inefficiencies",
                Description = "Suboptimal resource allocation patterns detected in container orchestration leading to underutilized nodes and scaling delays.",
                CreatedDate = DateTime.Now.AddDays(-4),
                LocationName = "São Paulo",
                Latitude = -23.5505,
                Longitude = -46.6333,
                Severity = AlertSeverity.Warning,
                Status = AlertStatus.Active,
                Source = "Orchestration Service"
            },
        };
    }
}