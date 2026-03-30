---
name: generate-alerts
description: "Generates randomized alert test data for the alert management system. Use this when asked to create sample alerts, mock data, or populate the system with test events for development and testing."
argument-hint: "[count] [severity-filter]"
---

# Generate Alert Test Data

This skill generates randomized alert events that match the project's `AlarmEvent` / `Alert` data model.

## When to use this skill

Use this skill when you need to:
- Generate sample alert data for testing
- Populate the system with realistic mock events
- Create edge-case alerts for specific testing scenarios

## Alert Schema

Each generated alert must include:
- `id`: Unique identifier (UUID or incrementing number)
- `name`: Descriptive alert name (e.g., "Motion detected in warehouse")
- `description`: Detailed description of the event
- `time` / `createdDate`: ISO 8601 timestamp in UTC
- `severity`: One of `Info`, `Warning`, `Error`, `Critical`
- `status`: One of `Active`, `Acknowledged`, `Resolved`
- `location`: Human-readable location name
- `latitude` / `longitude`: Valid coordinates
- `source`: Device type (Camera, Microphone, Sensor, MotionDetector, SmartPhone, Tablet)

## Generation Rules

1. **Realistic distribution**: ~40% Info, ~30% Warning, ~20% Error, ~10% Critical
2. **Time spread**: Generate alerts across the last 30 days with realistic clustering
3. **Location variety**: Use at least 5 different locations
4. **Source diversity**: Distribute across all device types
5. **Status mix**: ~50% Active, ~30% Acknowledged, ~20% Resolved
6. **Descriptions**: Use realistic security/safety scenarios (not generic placeholder text)

## Output Format

Generate data matching the track's language:
- **TypeScript**: Array of `AlarmEvent` objects matching `models.ts`
- **C#**: List of `Alert` objects matching `Alert.cs`
- **C++**: Vector of `Alert` structs matching `Alert.h`

## Example Usage

```
/generate-alerts 20
/generate-alerts 5 Critical
/generate-alerts 50 for load testing
```
