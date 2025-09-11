# GitHub Copilot Lab Repository

Always reference these instructions first and fallback to search or additional context gathering only when you encounter unexpected information that does not match the info here.

## Working Effectively

This is an educational repository for learning GitHub Copilot, NOT a traditional software project. The repository contains intentionally incomplete code designed for hands-on learning experiences.

### Essential Setup Steps

- Install VS Code with these critical extensions:
  - `github.copilot` - GitHub Copilot completions
  - `github.copilot-chat` - GitHub Copilot Chat
  - `vsls-contrib.codetour` - CodeTour (MANDATORY for lab navigation)
  - `ms-dotnettools.csharp` - C# support (for .NET track)
  - `ms-dotnettools.csdevkit` - C# Dev Kit (for .NET track)

- Open the appropriate workspace file for your chosen track:
  - `Typescript/GHCP-Typescript.code-workspace` - TypeScript track
  - `dotNet/GHCP-dotNet.code-workspace` - .NET/C# track  
  - `cpp/GHCP-cpp.code-workspace` - C++ track

- Start the CodeTour:
  - Navigate to Explorer panel in VS Code
  - Find "CODETOUR" section at bottom
  - Click the Play button next to the tour name
  - Follow the guided tour steps using Next/Previous buttons

### Build and Development Commands

**CRITICAL WARNING**: This repository contains intentionally incomplete code. Build failures are EXPECTED and BY DESIGN.

#### .NET Track (dotNet folder)
- `dotnet --version` - Verify .NET 8.0+ is installed
- `dotnet restore dotNet.sln` - Restore dependencies (~1 second)
- `dotnet build dotNet.sln` - WILL FAIL - code is intentionally incomplete for learning
- NEVER attempt to make incomplete code compile during the lab

#### TypeScript Track (Typescript folder)  
- `node --version && npm --version` - Verify Node.js and npm availability
- `tsc --version` - Verify TypeScript compiler (requires 5.0+)
- `tsc --noEmit *.ts` - Type check without compilation - WILL FAIL, intentionally incomplete
- `tsc models.ts && node models.js` - Compile and run complete files only

#### C++ Track (cpp folder)
- `g++ --version` - Verify C++ compiler availability
- `g++ -c <file>.cpp` - Compile individual files - WILL FAIL, code intentionally incomplete
- DO NOT attempt to create Makefiles or build systems

### Expected Timing and Timeouts

- **Lab completion time**: 60 minutes maximum (stop at 30 minutes if not progressing)
- **CodeTour navigation**: Instant
- **.NET restore**: 1-2 seconds - NEVER CANCEL, use timeout of 60+ seconds
- **TypeScript type checking**: 1-2 seconds - NEVER CANCEL, use timeout of 60+ seconds
- **Reading documentation**: 5-10 minutes per track

### Validation Scenarios

**CRITICAL**: Do NOT validate by building or running applications. This lab validates learning through CodeTour completion.

#### After Making Changes
- Navigate through CodeTour steps to ensure guidance is clear
- Verify GitHub Copilot completions appear when typing in incomplete code sections
- Test chat and inline chat functionality with sample prompts
- Confirm all three tracks' workspaces open correctly with proper color themes

#### Manual Testing Steps
1. Open workspace for chosen track
2. Install recommended extensions when prompted
3. Start CodeTour from Explorer panel
4. Navigate through at least 3 tour steps
5. Test GitHub Copilot completion in an incomplete code section
6. Test GitHub Copilot chat with a simple question about the code
7. Verify proper syntax highlighting and IntelliSense

### Key Projects and Structure

#### Repository Organization
- `README.md` - Main lab introduction and participation instructions
- `Typescript/` - TypeScript learning track with models for alert processing
- `dotNet/` - C# learning track with alert processing exercises  
- `cpp/` - C++ learning track with alert processing exercises
- `.github/prompts/` - Sample prompts for GitHub Copilot Chat exercises
- `assets/` - Images and documentation assets

#### Learning Tracks Overview
Each track contains:
- **Models/Data**: Alert and user event data structures
- **Completions exercises**: Practice with ghost text suggestions
- **Inline Chat exercises**: Practice with embedded chat interface
- **Chat exercises**: Practice with sidebar chat interface
- **CodeTour files**: Step-by-step guided learning experience

### Common Issues and Solutions

#### "Build Failed" Errors
- **Expected behavior** - code is intentionally incomplete
- DO NOT fix compilation errors during learning
- Focus on using GitHub Copilot features, not making code compile

#### CodeTour Not Starting
- Ensure `vsls-contrib.codetour` extension is installed
- Look for "CODETOUR" section in Explorer panel
- Click refresh icon if tours don't appear
- Restart VS Code if extension issues persist

#### GitHub Copilot Not Working
- Verify extensions are installed and authenticated
- Check GitHub Copilot subscription status
- Restart VS Code and re-authenticate if needed
- Test with simple prompts in chat first

### Learning Validation

**Primary validation**: Successful completion of CodeTour steps for chosen track
**Secondary validation**: Ability to generate code completions and use chat features
**Success criteria**: Understanding differences between completions, inline chat, and chat

#### What NOT to Test
- Do NOT test application functionality - there is no running application
- Do NOT validate by building or compiling code
- Do NOT create additional test files or test frameworks
- Do NOT attempt to fix intentional compilation errors

#### Time Management
- Spend maximum 20 minutes per track if doing multiple tracks
- Stop if spending more than 30 minutes total without progress
- Focus on hands-on experience with GitHub Copilot features, not code completion

Always remember: The goal is learning GitHub Copilot, not creating working software.