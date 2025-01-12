#pragma once
#include <string>
#include <ctime>

#include "Models.h"

namespace AdvancedCopilot::cpp
{
    class Alert 
    {
    public:
        std::string Id;
        std::string Source;
        std::string Name;
        std::string Description;
        std::time_t CreatedDate;
        std::string LocationName;
        double Latitude;
        double Longitude;
        Models::AlertSeverity Severity;
        Models::AlertStatus Status;
    }; // class Alert
} // namespace AdvancedCopilot
