using System;
using System.Linq;
using System.Collections.Generic;
using SOC.AdvancedCopilot.Models;

namespace SOC.AdvancedCopilot.DotNet;

public static class AlertAggregations
{
    /// <summary>
    /// Groups alerts by severity and returns the count for each severity level
    /// </summary>
    public static Dictionary<AlertSeverity, int> GetAlertCountBySeverity(IEnumerable<Alert> alerts)
    {
        return alerts
            .GroupBy(alert => alert.Severity)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    /// <summary>
    /// Groups alerts by status and returns the count for each status
    /// </summary>
    public static Dictionary<AlertStatus, int> GetAlertCountByStatus(IEnumerable<Alert> alerts)
    {
        return alerts
            .GroupBy(alert => alert.Status)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    /// <summary>
    /// Groups alerts by source service and returns the count for each source
    /// </summary>
    public static Dictionary<string, int> GetAlertCountBySource(IEnumerable<Alert> alerts)
    {
        return alerts
            .GroupBy(alert => alert.Source)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    /// <summary>
    /// Groups alerts by location and returns the count for each location
    /// </summary>
    public static Dictionary<string, int> GetAlertCountByLocation(IEnumerable<Alert> alerts)
    {
        return alerts
            .GroupBy(alert => alert.LocationName)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    /// <summary>
    /// Gets alerts created within a specified time range
    /// </summary>
    public static IEnumerable<Alert> GetAlertsInDateRange(IEnumerable<Alert> alerts, DateTime startDate, DateTime endDate)
    {
        return alerts.Where(alert => alert.CreatedDate >= startDate && alert.CreatedDate <= endDate);
    }

    /// <summary>
    /// Gets the most recent alert for each severity level
    /// </summary>
    public static Dictionary<AlertSeverity, Alert> GetMostRecentAlertBySeverity(IEnumerable<Alert> alerts)
    {
        return alerts
            .GroupBy(alert => alert.Severity)
            .ToDictionary(
                group => group.Key,
                group => group.OrderByDescending(alert => alert.CreatedDate).First()
            );
    }

    /// <summary>
    /// Gets active alerts grouped by severity with their counts
    /// </summary>
    public static Dictionary<AlertSeverity, int> GetActiveAlertCountBySeverity(IEnumerable<Alert> alerts)
    {
        return alerts
            .Where(alert => alert.Status == AlertStatus.Active)
            .GroupBy(alert => alert.Severity)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    /// <summary>
    /// Calculates average geographical coordinates for alerts by location
    /// </summary>
    public static Dictionary<string, (double AverageLatitude, double AverageLongitude)> GetAverageCoordinatesByLocation(IEnumerable<Alert> alerts)
    {
        return alerts
            .GroupBy(alert => alert.LocationName)
            .ToDictionary(
                group => group.Key,
                group => (
                    AverageLatitude: group.Average(alert => alert.Latitude),
                    AverageLongitude: group.Average(alert => alert.Longitude)
                )
            );
    }
}