#pragma once
#include "CommonHeaders.h"

namespace AdvancedCopilot::cpp
{
    class MockedAlerts {
    public:
        static std::vector<Alert> GetMockedAlerts() {

            auto now = std::chrono::system_clock::now();

            std::vector<Alert> alerts;

            alerts.push_back(Alert{
                "1", 
                "Scooby Doo", 
                "Microphone detected a noise that sounds like a ghost", "Microphone",
                std::chrono::system_clock::to_time_t(now + std::chrono::hours(42)), 
                "Kitchen", 1.0, 1.0, 
                Models::AlertSeverity::Info, Models::AlertStatus::Active
            });

            alerts.push_back(Alert{
                "2", 
                "Burgers alert", 
                "Looks like instead of burglers in our living room, we have burgers, let's dine!",
                "Camera",
                std::chrono::system_clock::to_time_t(now + std::chrono::hours(2)),
                "Living room", 2.0, 2.0, 
                Models::AlertSeverity::Warning, Models::AlertStatus::Acknowledged
            });

            alerts.push_back(Alert{
                "3", "Dude, where's my car?", "Car is missing from the garage, I swear I parked it there","Camera",
                std::chrono::system_clock::to_time_t(now), "Garage", 3.0, 3.0, 
                Models::AlertSeverity::Error, Models::AlertStatus::Resolved
            });

            alerts.push_back(Alert{
                "4", "Garage door jammed", "This is the last time I'm letting the kids play with jam sandwhiches in the garage",  "Sensor",
                std::chrono::system_clock::to_time_t(now - std::chrono::hours(24)), "Garage", 4.0, 4.0, 
                Models::AlertSeverity::Critical, Models::AlertStatus::Active
            });

            alerts.push_back(Alert{
                "5", "Cat Nap", "The cat has taken over the keyboard again, typing gibberish", "Keyboard",
                std::chrono::system_clock::to_time_t(now - std::chrono::hours(5)), "Office", 5.0, 5.0, 
                Models::AlertSeverity::Info, Models::AlertStatus::Active
            });

            alerts.push_back(Alert{
                "6", "Fridge Raid", "Someone raided the fridge and left it open, ice cream is melting!", "Fridge Sensor",
                std::chrono::system_clock::to_time_t(now - std::chrono::minutes(30)), "Kitchen", 6.0, 6.0, 
                Models::AlertSeverity::Warning, Models::AlertStatus::Acknowledged
            });

            alerts.push_back(Alert{
                "7", "Laundry Monster", "The washing machine is making strange noises, could be a laundry monster", "Washing Machine",
                std::chrono::system_clock::to_time_t(now - std::chrono::hours(2)), "Laundry Room", 7.0, 7.0, 
                Models::AlertSeverity::Error, Models::AlertStatus::Resolved
            });

            // sekret alert
            
            return alerts;
        }
    };
}