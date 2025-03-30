Below is a template for GitHub Copilot instructions that outlines how to create tests in a general way. Feel free to adjust names and types to match your project.

---

**GitHub Copilot Test Creation Template Instructions**

1. **Framework & Dependencies**  
   - Use the Xunit framework for unit tests.  
   - Use Moq (or another mock library) to create mocks for all external dependencies.  
   - Include necessary using directives: System, Collections, Threading, Xunit, Moq, and your project namespaces.

2. **Test Class Setup**  
   - Create a test class in an appropriate namespace (for example, UnitTests.Skills or similar).  
   - Name the class following the pattern <ClassUnderTest>Tests.  
   - Define member variables for all dependencies (e.g., clients, loggers, service dependencies).

3. **Constructor Initialization**  
   - In the constructor, instantiate mocks using Moq, and configure default behavior as needed (e.g., setup return values for specific methods).  
   - Instantiate the class under test by injecting the created mocks.

4. **Writing Test Methods**  
   - Follow the Arrange–Act–Assert pattern in each test:
     - **Arrange:** Set up test data, configure mocks or any preconditions.
     - **Act:** Invoke the method on the class under test.
     - **Assert:** Validate results with Xunit assertions (e.g., Assert.Equal, Assert.NotNull).
   - Use [Fact] for standard tests and [Theory] along with [InlineData] or [MemberData] for parameterized tests.

5. **Parameterized Tests & Member Data**  
   - For tests that require multiple data sets, implement helper methods or properties that return IEnumerable<object[]>.
   - Use these methods with [MemberData] in your test attributes to supply multiple cases.

6. **Naming Conventions & Best Practices**  
   - Use descriptive names: name your tests with a method pattern that reflects what is being tested (e.g., FormatData_ShouldReturnExpectedOutput).  
   - Ensure each test is self-contained by setting up its own test data and mock configurations.  
   - When testing transformation or clustering logic, validate both the count and the exact content of collections.

7. **Helper Methods**  
   - Create helper methods for generating duplicate elements or different test objects if needed.
   - Keep these helper methods private and local to the test file for clarity.