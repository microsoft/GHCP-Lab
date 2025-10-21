using SOC.AdvancedCopilot.DotNet;
using SOC.AdvancedCopilot.Models;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Alert Management System - Interactive Console Application
        Console.WriteLine("=== Alert Management System ===");
        Console.WriteLine();

        // Get the list of alerts (mocked ones for now)
        List<Alert> alerts = Mocks.MockedAlerts.GetMockedAlerts();

        bool continueRunning = true;
        while (continueRunning)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListAllAlerts(alerts);
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                case "3":
                    ShowAlertCountBySeverity(alerts);
                    break;
                case "4":
                    ShowAlertCountByStatus(alerts);
                    break;
                case "5":
                    ShowAlertCountBySource(alerts);
                    break;
                case "6":
                    ShowAlertCountByLocation(alerts);
                    break;
                case "7":
                    ShowAlertsInDateRange(alerts);
                    break;
                case "8":
                    ShowMostRecentAlertBySeverity(alerts);
                    break;
                case "9":
                    ShowActiveAlertCountBySeverity(alerts);
                    break;
                case "10":
                    ShowAverageCoordinatesByLocation(alerts);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (choice != "2")
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. List all alerts");
        Console.WriteLine("2. Exit program");
        Console.WriteLine("3. Get alert count by severity");
        Console.WriteLine("4. Get alert count by status");
        Console.WriteLine("5. Get alert count by source");
        Console.WriteLine("6. Get alert count by location");
        Console.WriteLine("7. Get alerts in date range");
        Console.WriteLine("8. Get most recent alert by severity");
        Console.WriteLine("9. Get active alert count by severity");
        Console.WriteLine("10. Get average coordinates by location");
        Console.Write("\nEnter your choice (1-10): ");
    }

    static void ListAllAlerts(List<Alert> alerts)
    {
        Console.WriteLine("\n=== All Alerts ===");
        Console.WriteLine();

        foreach (Alert alert in alerts)
        {
            Console.WriteLine($"ID: {alert.Id}");
            Console.WriteLine($"Name: {alert.Name}");
            Console.WriteLine($"Description: {alert.Description}");
            Console.WriteLine($"Source: {alert.Source}");
            Console.WriteLine($"Severity: {alert.Severity}");
            Console.WriteLine($"Status: {alert.Status}");
            Console.WriteLine($"Location: {alert.LocationName} ({alert.Latitude}, {alert.Longitude})");
            Console.WriteLine($"Created: {alert.CreatedDate:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine(new string('-', 50));
        }

        Console.WriteLine($"\nTotal alerts: {alerts.Count}");
    }

    static void ShowAlertCountBySeverity(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Alert Count by Severity ===");
        Dictionary<AlertSeverity, int> result = AlertAggregations.GetAlertCountBySeverity(alerts);

        foreach (KeyValuePair<AlertSeverity, int> item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void ShowAlertCountByStatus(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Alert Count by Status ===");
        Dictionary<AlertStatus, int> result = AlertAggregations.GetAlertCountByStatus(alerts);

        foreach (KeyValuePair<AlertStatus, int> item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void ShowAlertCountBySource(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Alert Count by Source ===");
        Dictionary<string, int> result = AlertAggregations.GetAlertCountBySource(alerts);

        foreach (KeyValuePair<string, int> item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void ShowAlertCountByLocation(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Alert Count by Location ===");
        Dictionary<string, int> result = AlertAggregations.GetAlertCountByLocation(alerts);

        foreach (KeyValuePair<string, int> item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void ShowAlertsInDateRange(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Alerts in Date Range ===");
        Console.Write("Enter start date (yyyy-MM-dd): ");
        string startInput = Console.ReadLine();
        Console.Write("Enter end date (yyyy-MM-dd): ");
        string endInput = Console.ReadLine();

        if (DateTime.TryParse(startInput, out DateTime startDate) && 
            DateTime.TryParse(endInput, out DateTime endDate))
        {
            IEnumerable<Alert> result = AlertAggregations.GetAlertsInDateRange(alerts, startDate, endDate);
            List<Alert> resultList = result.ToList();

            if (resultList.Any())
            {
                foreach (Alert alert in resultList)
                {
                    Console.WriteLine($"[{alert.CreatedDate:yyyy-MM-dd}] {alert.Name} - {alert.Severity}");
                }
                Console.WriteLine($"\nFound {resultList.Count} alerts in the specified date range.");
            }
            else
            {
                Console.WriteLine("No alerts found in the specified date range.");
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd format.");
        }
    }

    static void ShowMostRecentAlertBySeverity(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Most Recent Alert by Severity ===");
        Dictionary<AlertSeverity, Alert> result = AlertAggregations.GetMostRecentAlertBySeverity(alerts);

        foreach (KeyValuePair<AlertSeverity, Alert> item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value.Name} (Created: {item.Value.CreatedDate:yyyy-MM-dd HH:mm:ss})");
        }
    }

    static void ShowActiveAlertCountBySeverity(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Active Alert Count by Severity ===");
        Dictionary<AlertSeverity, int> result = AlertAggregations.GetActiveAlertCountBySeverity(alerts);

        if (result.Any())
        {
            foreach (KeyValuePair<AlertSeverity, int> item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        else
        {
            Console.WriteLine("No active alerts found.");
        }
    }

    static void ShowAverageCoordinatesByLocation(List<Alert> alerts)
    {
        Console.WriteLine("\n=== Average Coordinates by Location ===");
        Dictionary<string, (double AverageLatitude, double AverageLongitude)> result = 
            AlertAggregations.GetAverageCoordinatesByLocation(alerts);

        foreach (KeyValuePair<string, (double AverageLatitude, double AverageLongitude)> item in result)
        {
            Console.WriteLine($"{item.Key}: Lat {item.Value.AverageLatitude:F4}, Lng {item.Value.AverageLongitude:F4}");
        }
    }
}

// SECRET: rick

