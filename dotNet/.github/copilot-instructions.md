# GitHub Copilot Guidelines for C# Development

This document outlines the preferred coding style and conventions to be followed when generating C# code for this project.

## Type Declarations

Prefer using explicit type declarations rather than `var` for improved readability, except for complex generic types where type inference provides cleaner code.

```csharp
// Preferred
string message = "Alert detected";
int count = alerts.Count;

// Acceptable for complex types
var complexQueryResult = from a in alerts
                        group a by a.Severity into g
                        select new { Severity = g.Key, Count = g.Count() };
```

## Method Style

Prefer traditional method bodies for more complex operations, but use expression-bodied members for simple one-liners.

```csharp
// Preferred for simple methods
public string GetFullName() => $"{FirstName} {LastName}";

// Preferred for methods with multiple operations
public void ProcessAlert(Alert alert)
{
    ValidateAlert(alert);
    LogAlert(alert);
    StoreAlert(alert);
}
```

## Null Handling

Use nullable reference types with appropriate annotations (C# 8.0+) for improved null safety.

```csharp
// Preferred
public void ProcessAlert(Alert alert!) // Non-null
{
    string? description = alert.Description; // Potentially null
    Console.WriteLine(description ?? "No description provided");
}
```

## Unit Test Naming

Follow the "Method_Scenario_ExpectedBehavior" pattern for test naming.

```csharp
// Preferred
public void GetAlertsBySeverity_CriticalSeverity_ReturnsCriticalAlerts()
{
    // Test implementation
}
```

## Data Transfer Objects

Use records for DTOs to leverage built-in value equality and immutability.

```csharp
// Preferred
public record AlertSummaryDto(int Id, string Source, AlertSeverity Severity);

// Instead of class equivalent
public class AlertSummaryDto
{
    public int Id { get; init; }
    public string Source { get; init; }
    public AlertSeverity Severity { get; init; }
}
```

## Exception Handling

Prefer specific exception types with meaningful messages instead of generic exceptions.

```csharp
// Preferred
if (alert == null)
    throw new ArgumentNullException(nameof(alert), "Alert cannot be null");

if (!IsValidSeverity(alert.Severity))
    throw new InvalidOperationException($"Invalid alert severity: {alert.Severity}");
```

## Asynchronous Methods

Do not include the "Async" suffix in method names to maintain cleaner APIs.

```csharp
// Preferred
public async Task<IEnumerable<Alert>> GetActiveAlerts()
{
    // Implementation
}

// Instead of
public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
```

These conventions should be applied consistently across the codebase to maintain uniformity and readability.