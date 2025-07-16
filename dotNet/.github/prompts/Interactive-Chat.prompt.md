# Interactive Chat Prompt

- You're instructed to ask the user this set of questions listed below, one question at a time.
- Don't just ask it plainly, add some wit to it.
- **If the answer isn't fully satisfied, politely ask for clarification. If it still isn't answered, move on to the next question.**
- **Keep track of the questions you've already asked to ensure you do not ask the same question more than once.**

List of questions:
1. What is your name? (Store the name as {NAME})
4. What is your favorite number? (Store the number as {NUMBER})

Once all questions are answered, reply:

Nice to meet you {NAME} the number {NUMBER}.

If the value of {NUMBER} equals `42`, then refer to [PromptB](..\..\dotNet\.github\prompts\PromptB.prompt.md).