using System;
using SOC.AdvancedCopilot.Models;

public class Alert
{

    public string Id { get; set; }

    public string Source { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public string LocationName { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public AlertSeverity Severity { get; set; }

    public AlertStatus Status { get; set; }
}