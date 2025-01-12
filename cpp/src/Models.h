#pragma once

namespace AdvancedCopilot::cpp::Models
 {
    enum class AlertSeverity 
    {
        Info,
        Warning,
        Error,
        Critical
    };

    enum class AlertStatus 
    {
        Active,
        Acknowledged,
        Resolved
    };
} // namespace AdvancedCopilot::cpp::Models