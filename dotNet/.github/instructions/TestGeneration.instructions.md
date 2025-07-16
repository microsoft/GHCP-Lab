# Test Generation Instructions for C# with MOQ and NUnit

When generating unit tests for this project, follow these guidelines to ensure consistent, maintainable, and effective test code.

## Testing Framework Setup

### Required NuGet Packages
- NUnit (3.13.3 or later)
- NUnit3TestAdapter (4.2.1 or later)
- MOQ (4.18.4 or later)
- Microsoft.NET.Test.Sdk (17.3.2 or later)

### Using Statements
Always include these using statements in test files:
```csharp
using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
```

## Test Class Structure

### Test Class Naming Convention
- Use `[ClassUnderTest]Tests` pattern
- Example: `AlertProcessorTests`, `UserServiceTests`

### Test Class Setup
```csharp
[TestFixture]
public class [ClassUnderTest]Tests
{
    private Mock<[IDependency]> _mockDependency;
    private [ClassUnderTest] _sut; // System Under Test
    
    [SetUp]
    public void Setup()
    {
        _mockDependency = new Mock<[IDependency]>();
        _sut = new [ClassUnderTest](_mockDependency.Object);
    }
}
```

## Test Method Guidelines

### Test Method Naming
Follow the pattern: `[MethodName]_[Scenario]_[ExpectedBehavior]`
- Use descriptive names that explain the test case
- Avoid abbreviations unless widely understood
- Use PascalCase for method names

### Test Method Structure (Arrange-Act-Assert)
```csharp
[Test]
public void MethodName_Scenario_ExpectedBehavior()
{
    // Arrange
    // Set up test data, mocks, and expectations
    
    // Act
    // Execute the method under test
    
    // Assert
    // Verify the expected behavior
}
```

## Mocking Guidelines

### Mock Setup Patterns
- Use `Mock<T>` for interface dependencies
- Set up method calls with `.Setup()` and specify return values with `.Returns()`
- Use `.Callback()` for capturing method arguments when needed
- Verify method calls with `.Verify()` when behavior verification is required

### Mock Verification
- Verify that expected methods were called with correct parameters
- Use `Times.Once`, `Times.Never`, `Times.AtLeast()`, etc. for call frequency verification
- Verify all setups that should be called during the test

## Test Data Management

### Test Data Principles
- Use meaningful test data that represents realistic scenarios
- Create helper methods for complex object creation
- Use parameterized tests for testing multiple scenarios
- Avoid magic numbers and strings - use constants or variables with descriptive names

### Parameterized Tests
Use `[TestCase]` for multiple test scenarios:
```csharp
[TestCase(value1, expectedResult1)]
[TestCase(value2, expectedResult2)]
public void Method_VariousInputs_ReturnsExpectedResults(inputType input, expectedType expected)
```

## Exception Testing

### Testing Expected Exceptions
```csharp
[Test]
public void Method_InvalidInput_ThrowsArgumentException()
{
    // Arrange
    var invalidInput = // ... setup invalid input
    
    // Act & Assert
    var exception = Assert.Throws<ArgumentException>(() => _sut.Method(invalidInput));
    Assert.That(exception.Message, Contains.Substring("expected error message"));
}
```

## Async Method Testing

### Testing Async Methods
```csharp
[Test]
public async Task AsyncMethod_Scenario_ExpectedBehavior()
{
    // Arrange
    // ... setup
    
    // Act
    var result = await _sut.AsyncMethod();
    
    // Assert
    Assert.That(result, Is.EqualTo(expectedValue));
}
```

## Assertion Guidelines

### Preferred Assertion Patterns
- Use `Assert.That()` with constraint-based assertions
- Use `Is.EqualTo()`, `Is.Not.Null`, `Is.True`, etc.
- Use `Contains.Item()` for collection assertions
- Use `Has.Count` for collection size verification

### Collection Assertions
```csharp
Assert.That(collection, Has.Count.EqualTo(expectedCount));
Assert.That(collection, Contains.Item(expectedItem));
Assert.That(collection, Is.All.InstanceOf<ExpectedType>());
```

## Test Categories and Attributes

### Test Organization
- Use `[Category("CategoryName")]` to group related tests
- Use `[Ignore("Reason")]` for temporarily disabled tests
- Use `[Explicit]` for tests that should only run when explicitly requested

### Common Categories
- `[Category("Unit")]` for pure unit tests
- `[Category("Integration")]` for integration tests
- `[Category("Performance")]` for performance-related tests

## Code Coverage Considerations

### Test Coverage Goals
- Aim for high code coverage but focus on meaningful scenarios
- Test both happy path and edge cases
- Include null checks and boundary conditions
- Test error handling and exception scenarios

### What to Test
- Public methods and their various input combinations
- Business logic and decision points
- Error conditions and exception handling
- State changes and side effects

## Best Practices

### General Guidelines
- Each test should test only one specific behavior
- Tests should be independent and not rely on execution order
- Use descriptive variable names in tests
- Keep tests simple and focused
- Avoid complex logic in test methods
- Prefer explicit assertions over generic ones

### Performance Considerations
- Minimize test setup overhead
- Use `[OneTimeSetUp]` for expensive initialization that can be shared
- Clean up resources in `[TearDown]` when necessary
- Consider using `[Parallelizable]` for independent tests

### Maintainability
- Extract common setup into helper methods
- Use constants for frequently used test values
- Document complex test scenarios with comments
- Refactor tests when the production code changes
- Remove obsolete tests promptly

## Error Messages and Debugging

### Assertion Messages
- Provide clear, descriptive failure messages
- Include relevant context in custom assertion messages
- Use `Assert.That(actual, constraint, "Custom message")` when helpful

### Debugging Failed Tests
- Use meaningful variable names to aid debugging
- Consider using `Console.WriteLine()` or `TestContext.WriteLine()` for debugging output
- Structure tests to make failures obvious and easy to diagnose



