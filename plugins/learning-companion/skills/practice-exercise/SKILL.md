---
name: practice-exercise
description: Generates a hands-on practice exercise for a specified GitHub Copilot feature.
argument-hint: "[feature-name] [difficulty]"
---

# Practice Exercise Skill

Generate targeted, hands-on exercises to master specific GitHub Copilot features at your preferred difficulty level.

## When to Use This Skill

- **Learning a new feature** - Get structured exercises to understand how it works
- **Building confidence** - Practice with scaffolded tasks before tackling real code
- **Filling skill gaps** - Identify weak areas and practice with targeted exercises
- **Teaching others** - Create consistent, effective exercises for team learning
- **Daily practice** - Keep your Copilot skills sharp with varied challenges

## Supported Features

The following GitHub Copilot features have practice exercises available:

1. **completions** - Master the 3 S Principle (Simple, Short, Specific) and predict Copilot's suggestions accurately
2. **inline-chat** - Learn to ask targeted questions about code with Ctrl+I
3. **chat** - Develop deeper conversations with Copilot using Ctrl+Alt+I for complex problems
4. **agents** - Understand how autonomous agents explore and work with your codebase
5. **edits** - Master preview-based, multi-file code transformations with Ctrl+Shift+I
6. **cli** - Command-line integration and scripting with Copilot

## Difficulty Levels

Choose a level that matches your current skill:

- **beginner** - Introductory exercises with clear guidance, simple concepts, scaffolded steps, helpful hints
- **intermediate** - Moderate complexity, less guidance, combination of features, real-world scenarios from the alert system
- **advanced** - Complex tasks, minimal guidance, multi-step problems, performance considerations, edge cases

## Exercise Format

Each generated exercise includes:

### 📋 **Objective**
Clear statement of what you'll learn and accomplish

### 🏗️ **Setup Instructions**
How to prepare your environment (files to open, context to understand, starting code)

### 👣 **Step-by-Step Guidance**
Progressively more independent steps:
- Early steps have detailed hints
- Middle steps require more problem-solving
- Final steps encourage experimentation and creativity

### ✅ **Expected Outcome**
What success looks like - specific code behavior, output, or understanding demonstrated

### 🚀 **Bonus Challenge**
Optional advanced stretch goal to extend learning beyond the core exercise

## Example Usage

```
/practice-exercise completions beginner
→ Learn to write simple completions with good context

/practice-exercise inline-chat intermediate
→ Practice asking smart questions about alert filtering logic

/practice-exercise agents advanced
→ Build a custom agent to analyze and document your alert domain

/practice-exercise edits beginner
→ Get comfortable with the preview-based editing workflow

/practice-exercise chat advanced
→ Multi-turn conversation solving complex architecture problems
```

## How It Works

1. **Specify** - Choose a feature and difficulty level
2. **Receive** - Get a structured, ready-to-go exercise
3. **Practice** - Work through the steps in your code editor
4. **Apply** - Take the skills to your real projects
5. **Share** - Exercises are great for pairing and team learning

## Features in Detail

### Completions
Learn to guide Copilot to generate better code by following the **3 S Principle**:
- **Simple**: Keep suggestions focused
- **Short**: Brief, specific context wins
- **Specific**: Clear variable names and patterns

### Inline Chat (Ctrl+I)
Ask targeted questions about selected code:
- "Optimize this for performance"
- "Add error handling"
- "Explain what this does"
- "Write tests for this function"

### Chat (Ctrl+Alt+I)
Deep, multi-turn conversations with full context access using `@workspace`, `#file`, `#selection`

### Agents
Autonomous agents with specific capabilities - explore codebases, run tests, analyze patterns

### Edits (Ctrl+Shift+I)
Preview before applying complex refactorings and multi-file changes

### CLI
Command-line power - ask questions, generate code, run Copilot features from your terminal

## Tips for Success

✅ **Do:**
- Start with beginner exercises to build confidence
- Read hints but try to solve before looking at the answer
- Experiment with variations on the exercise
- Combine multiple features in your solutions
- Discuss exercises with teammates

❌ **Don't:**
- Skip the objectives - they explain the "why"
- Rush through setups - good context leads to better learning
- Treat exercises as just getting to the end - focus on understanding
- Memorize solutions - each situation is slightly different
- Give up if Copilot's response isn't perfect on the first try

## Progress Tracking

Keep a learning journal:
- Record which features you've practiced
- Note aha moments and key insights
- Track features you want to revisit
- Document your favorite keyboard shortcuts
- Build a personal cookbook of patterns that work well

## Next Steps After Practicing

1. **Apply to Real Code** - Use the techniques on your actual projects
2. **Level Up** - Try a harder difficulty or related feature
3. **Teach Others** - Pair with a teammate and walk through the exercise
4. **Combine Features** - Merge completions with inline chat, or chat with edits
5. **Provide Feedback** - Help us improve exercises by sharing what worked and what didn't

---

**Remember**: Becoming proficient with Copilot is like learning any new tool. The more you practice, the more natural it becomes. Each exercise builds toward mastery!
