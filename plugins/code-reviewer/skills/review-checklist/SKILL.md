---
name: review-checklist
description: Generates a language-specific code review checklist tailored to the files being changed.
argument-hint: "[language-or-file]"
---

# Review Checklist Skill

This skill generates targeted code review checklists customized for the specific programming language or files in your change.

## When to Use

- Before submitting a PR for review
- When reviewing code from teammates
- To ensure consistency with language best practices
- To catch common language-specific pitfalls

## Supported Languages

- **TypeScript** — Type safety, async/await patterns, React/Node conventions
- **C#** — Null safety, async patterns, LINQ, .NET framework usage
- **C++** — Memory management, smart pointers, const correctness, thread safety
- **Python** — Type hints, exception handling, PEP 8, async patterns
- **Go** — Error handling, goroutines, channels, interfaces
- **Java** — NullPointerException handling, resource management, collection APIs

## Checklist Categories

Each checklist includes checks for:

### Type Safety
- Type annotations present and correct
- No unsafe casts or type assertions
- Proper generic type usage
- Runtime type validation where needed

### Error Handling
- All exceptions/errors properly handled
- No silent failures or swallowed exceptions
- Appropriate error recovery strategies
- User-facing error messages are clear

### Testing & Coverage
- Unit tests for new logic
- Edge cases covered
- Error paths tested
- Integration points validated

### Security
- Input validation and sanitization
- No hardcoded credentials or secrets
- Proper authentication/authorization checks
- SQL injection and XSS prevention

### Documentation
- Public API methods documented
- Complex logic has explanatory comments
- Breaking changes noted
- Examples provided for non-obvious behavior

## Output Format

Checklists are formatted as markdown with categories as sections, each containing checkboxes:

```markdown
## [Language] Code Review Checklist

### Type Safety
- [ ] All variables have explicit types
- [ ] No unnecessary type assertions
- ...

### Error Handling
- [ ] Exception handling is explicit
- [ ] Error messages are helpful
- ...

### Testing & Coverage
- [ ] New code has unit tests
- [ ] Edge cases are covered
- ...

### Security
- [ ] Input validation present
- [ ] No credential leaks
- ...

### Documentation
- [ ] Public APIs are documented
- [ ] Complex logic is explained
- ...
```

## Example Usage

```
/review-checklist TypeScript
/review-checklist C#
/review-checklist for src/auth.ts
/review-checklist Python
```

The skill automatically detects the language from file extensions when provided, or uses the language name directly to generate the appropriate checklist.
