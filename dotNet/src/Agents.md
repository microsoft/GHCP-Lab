# Understanding GitHub Copilot Agents

## What are GitHub Copilot Agents?

GitHub Copilot Agents are specialized AI assistants that can be configured to help with specific development tasks. They live in your repository's `.github/agents/` directory and can be customized to understand your project's context, coding standards, and workflows.

## Key Features

### 🤖 Multiple AI Assistants Out of the Box
When you navigate to [agents.md](https://agents.md), you'll discover a variety of pre-built AI agents that GitHub Copilot supports right away! These agents can:
- Help with code reviews
- Generate documentation
- Assist with testing strategies
- Provide architectural guidance
- And much more!

### 📁 Nested Folder Support
Agents can be organized in nested folders within `.github/agents/` to provide deeper, more context-specific assistance:

```
.github/
└── agents/
    ├── tour-agent.md              # Top-level tour building agent
    ├── backend/
    │   ├── api-reviewer.md        # Backend-specific API review agent
    │   └── database-helper.md     # Database query assistance
    └── frontend/
        ├── ui-component-agent.md  # UI component generation
        └── accessibility-agent.md # Accessibility checking
```

This hierarchical structure allows you to:
- **Organize by domain** - Separate concerns (backend, frontend, infrastructure)
- **Enrich context** - Deeper folders provide more specific context when working on specialized code
- **Team collaboration** - Different teams can maintain their own agent configurations

## How to Use Agents

1. **Discover available agents** - Visit [agents.md](https://agents.md) to explore supported AI assistants
2. **Create custom agents** - Add `.md` files in `.github/agents/` with your agent instructions
3. **Reference in chat** - Use agents through GitHub Copilot chat with specific commands
4. **Iterate and improve** - Update agent instructions based on team feedback and evolving needs

## Example: Tour Agent

This repository includes a tour-building agent at `.github/agents/tour-agent.md` that helps create interactive CodeTour experiences for learning GitHub Copilot features.

## Best Practices

- **Keep agents focused** - Each agent should have a specific, well-defined purpose
- **Use nested folders** - Organize agents by domain or feature area for better context
- **Document agent capabilities** - Clearly describe what each agent can help with
- **Version control** - Track agent changes like any other code asset
- **Team review** - Have team members review and improve agent instructions together

---

**Pro Tip**: Custom agents work best when combined with GitHub Copilot Instructions (`.github/copilot-instructions.md`) to provide comprehensive context about your project's coding standards and preferences!
