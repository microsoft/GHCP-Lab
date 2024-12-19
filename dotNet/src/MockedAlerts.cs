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
            Name = "Scooby Doo",
            Description = "Microphone detected a noise that sounds like a ghost",
            CreatedDate = DateTime.Now.AddDays(42),
            LocationName = "Kitchen",
            Latitude = 1.0,
            Longitude = 1.0,
            Severity = AlertSeverity.Info,
            Status = AlertStatus.Active,
            Source = "Microphone"
            },
            new Alert
            {
            Id = "2",
            Name = "Burgers alert",
            Description = "Looks like instead of burglers in our living room, we have burgers, let's dine!",
            CreatedDate = DateTime.Now.AddDays(2),
            LocationName = "Living room",
            Latitude = 2.0,
            Longitude = 2.0,
            Severity = AlertSeverity.Warning,
            Status = AlertStatus.Acknowledged,
            Source = "Camera"
            },
            new Alert
            {
            Id = "3",
            Name = "Dude, where's my car?",
            Description = "Car is missing from the garage, I swear I parked it there",
            CreatedDate = DateTime.Now,
            LocationName = "Garage",
            Latitude = 3.0,
            Longitude = 3.0,
            Severity = AlertSeverity.Error,
            Status = AlertStatus.Resolved,
            Source = "Camera"
            },
            new Alert
            {
            Id = "4",
            Name = "Garage door jammed",
            Description = "This is the last time I'm letting the kids play with jam sandwhiches in the garage",
            CreatedDate = DateTime.Now.AddDays(-1),
            LocationName = "Garage",
            Latitude = 4.0,
            Longitude = 4.0,
            Severity = AlertSeverity.Critical,
            Status = AlertStatus.Active,
            Source = "Sensor"
            },
            new Alert
            {
                Id = "5",
                Name = "Cat Nap",
                Description = "The cat has taken over the keyboard again, typing gibberish",
                CreatedDate = DateTime.Now.AddHours(-5),
                LocationName = "Office",
                Latitude = 5.0,
                Longitude = 5.0,
                Severity = AlertSeverity.Info,
                Status = AlertStatus.Active,
                Source = "Keyboard"
            },
            new Alert
            {
                Id = "6",
                Name = "Fridge Raid",
                Description = "Someone raided the fridge and left it open, ice cream is melting!",
                CreatedDate = DateTime.Now.AddMinutes(-30),
                LocationName = "Kitchen",
                Latitude = 6.0,
                Longitude = 6.0,
                Severity = AlertSeverity.Warning,
                Status = AlertStatus.Acknowledged,
                Source = "Fridge Sensor"
            },
            new Alert
            {
                Id = "7",
                Name = "Laundry Monster",
                Description = "The washing machine is making strange noises, could be a laundry monster",
                CreatedDate = DateTime.Now.AddHours(-2),
                LocationName = "Laundry Room",
                Latitude = 7.0,
                Longitude = 7.0,
                Severity = AlertSeverity.Error,
                Status = AlertStatus.Resolved,
                Source = "Washing Machine"
            }
        };
    }
}