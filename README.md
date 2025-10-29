# Github Copilot Lab

Welcome to the Github Copilot (GHCP) lab.

For easier reading within VS Code, you can preview this file as Markdown using `Ctrl+Shift+V`, it may need a moment to open render.

## What will we learn in this lab?

- At the end of this lab you will know the differences between Github Copilot Agent, Ask and Edit modes, inline chat, completions, Github Copilot Coding agent, Github Copilot CLI and **most importantly - you'll learn when to use what**
- You will learn about GHCP aliases (`@` / `#`) and slash (`/`) commands for Github Copilot Chat and inline
- You will learn how to be more proficient with your completions and how to get it right on the first try 🥇
- You will learn about the GHCP suggestions panel
- How to utilize context to the fullest so that Github Copilot gives you what you want
- Gain hands on experience with Github copilot agent and learn about best practices on how to build your own app from scratch, boost your enterprise by adding that feature without battling GHCP and getting it right on the first try

## How will we learn it?

Using the *_[CodeTour](https://marketplace.visualstudio.com/items?itemName=vsls-contrib.codetour)_ extension, you will receive assignments, learn beginner and advanced tips and tricks, answer questions and finally build a small app using GHCP features and SDD (Spec-Driven Development) principles.
All of this is designed to help you shift your how to program paradigm, enabling you to use GitHub Copilot more effectively by writing less and generating more high-quality code.

\* Why _CodeTour_ you may ask? Because it allows you to learn at your own pace, revisit previous steps, and follow along with the code in a structured manner. But most importantly - it is outside of Github Copilot's context, so you can focus on learning without GHCP trying to help you while you're reading the instructions 😉

## Pre-requisite

Install [VS Code](https://code.visualstudio.com/download) or if you like the latest and greatest - **[VS Code insiders](https://code.visualstudio.com/insiders/)**

If you're an MS employee - visit [https://aka.ms/copilot](https://aka.ms/copilot) to sort out your license.

## Terminology (and some tips)

- Completions is the "ghost text" (gray) that appears in your editor after you start typing
  1. Clicking `Tab` will accept the entire text (there may be more suggestions once you accept the first one or jump to a new line)
  1. Clicking `Ctrl + Right arrow` will accept the next word only! (First hidden gem 💡)
  1. When a completion is showing up, you can click `Ctrl + Enter` to open a panel with several suggestions
- Inline chat is the experience where you have a small chat window that appears in the editor. You can make change requests, ask questions and get answers from GHCP, all in the editor window.
- Copilot Side panel is where Agent / Ask / Edit all reside, next to the editor (usually on the right side).
- In GHCP, **Context Is Everything**. Starting from your selection, to the open files in your IDE and most importantly- to what aliases / commands you're asking GHCP to do include in your prompt's context.
- Use the Up/Down arrows in Chat or Inline Chat to navigate prompt history, so you don't have to retype previous prompts 💡

## How to participate

1. Pick the language of your choice and click on it to navigate to the relevant workspace. Then hit the "Open Workspace" button in the Editor (bottom right)
    1. [`GHCP-dotNet.code-workspace`](./dotNet/GHCP-dotNet.code-workspace) for dotNet developers.
    1. [`GHCP-Typescript.code-workspace`](./Typescript/GHCP-Typescript.code-workspace) for Typescript developers
    1. [`GHCP-cpp.code-workspace`](./cpp/GHCP-cpp.code-workspace) for C++ developers
  
      ![Image showing where to click to open the relevant workspace](assets/image-1.png)
2. Install recommended extensions from the workspace
    1. If you don't want to run the code, CodeTour is the critical one
3. Start the tour by clicking on tour Panel, then hit the the Play icon button to start.

![Code tour starting place](assets/image-2.png)

1. Click the Next or Previous buttons to navigate the CodeTour when you're ready to move on or need to review a previous step.

![Next Code tour step](assets/image-3.png)

Feel free to reach out with improvement suggestions, feedback, or any other comments to <yomanor@microsoft.com> /  [@m-tantan](https://github.com/m-tantan)

### ⚠️⚠️⚠️ Disclaimer ⚠️⚠️⚠️

Github Copilot team are working 24/7 to deliver astounding features. This lab is updated from time to time and may not always include all the latest feature, but stay tuned changes are coming!
