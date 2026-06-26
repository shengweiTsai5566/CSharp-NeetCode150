# DoNetLeetCodePractice

> A .NET C# LeetCode practice environment with VS Code Copilot Skill automation.
> Designed for **semiconductor equipment software engineer interviews**, covering process control, hardware abstraction, communication protocols, and more.

> ✅ **NeetCode 150 Complete** — All 149+ problems are fully included, each with `ANSWER.md` (approach + C# solution) and xUnit tests.

---

## 🎯 How This Project Helps You Practice

### ✅ Skip the Setup, Focus on Solving
- **One-click scaffold**: `lc: scaffold TwoSum` auto-creates the problem file + test + ANSWER.md — no manual project/config/namespace work
- **One-click test**: `dotnet test --filter TwoSum` verifies your solution instantly
- **Centralized management**: 149+ problems under `Problems/` with consistent structure

### ✅ Deep Learning with Solution Notes
- Every problem includes **`ANSWER.md`** with: approach derivation, time/space complexity, multiple solutions comparison, complete C# implementation
- Review-friendly — approach notes right next to the code
- `lc: list` to quickly browse all problems and track progress

### ✅ Systematic Categorization, Step by Step
- Complete **NeetCode 150**题库, organized by topic: Array, Stack, Tree, Graph, DP, etc.
- Paste a job description to auto-generate **`Interview-Prep-List.md`** — focus on高频 problems first
- Custom problems (WaferScanOptimizer, CommandParser, etc.) tailored to equipment software interviews

### ✅ Real C# Project Structure, Interview-Ready
- Uses latest **.NET 9.0**, **xUnit**, **file-scoped namespaces** — consistent with industry practice
- Shared types (`ListNode`, `TreeNode`, `Node`) in one place, reducing duplicate code
- `dotnet build` — 0 errors, always compilable

### ✅ AI-Assisted Learning, Work Smarter
- **Copilot Skill automation**: `lc: scaffold` to start a problem, `lc: list` to check progress, `lc: remove` to clean up — let AI handle the chores
- **Copilot Chat for instant help**: Stuck? Ask "Explain this solution", "What's the time complexity?", "How to optimize?" — no need to leave the editor
- **AI-generated interview prep**: Paste a JD and let Copilot map it to project problems, auto-creating `Interview-Prep-List.md`
- **Code review & optimization**: After solving, ask Copilot to review edge cases, suggest better approaches, or explain complexity

> 💡 **Learning Tip**: Try solving first → peek at `ANSWER.md` if stuck → run tests to verify → review by re-implementing from scratch the next day. This project is built around this workflow.

---

## ✨ Features

| Feature | Description |
|---------|-------------|
| 🧩 **149+ Problems** | Complete NeetCode 150 + semiconductor custom problems |
| 📂 **Organized by Folder** | Each problem in its own folder with `.cs` + `ANSWER.md` |
| 🧪 **xUnit Tests** | Every problem has matching tests via `dotnet test` |
| 🧠 **Solution Guide** | Each `ANSWER.md` has approach, complexity analysis, and C# solution |
| 🤖 **Copilot Skill** | Use `lc:` prefix for scaffold / remove / rename / list |
| 🔍 **Interview Prep** | Generate a study list from a job description |

---

## 🚀 Quick Start

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- VS Code + C# Dev Kit + GitHub Copilot

### Install & Run Tests

```powershell
cd <repository-root>
dotnet test
```

### Browse Problems

Run `lc: list` or open [`LeetCodeProblems.md`](LeetCodeProblems.md) at the repository root.

---

## 📂 Project Structure

```
DoNetLeetterCodePractice/
├── LeetCodePractice/                     # Main project
│   └── Problems/                         # All problems
│       ├── ListNode.cs                   # Shared data types
│       ├── TreeNode.cs
│       ├── Node.cs
│       ├── TwoSum/                       # Each problem in its own folder
│       │   ├── TwoSum.cs                 #   Skeleton file (TODO for you)
│       │   └── ANSWER.md                 #   Solution guide (verify after trying)
│       ├── AddTwoNumbers/
│       ├── WaferScanOptimizer/
│       ├── CommandDispatcher/
│       └── ... (149+ folders)
├── LeetCodePractice.Tests/               # xUnit test project
│   ├── TwoSum/
│   │   └── TwoSumTests.cs
│   └── ... (matching each problem)
├── .agents/skills/leetcode-helper/       # Copilot Skill
│   ├── SKILL.md
│   ├── prompt.md
│   ├── resources/problem-list.md         # Problem registry
│   ├── references/                       # Reference docs
│   └── scripts/                          # Automation scripts
├── LeetCodeProblems.md                   # Auto-generated problem catalog
├── Interview-Prep-List.md                # Interview preparation list
├── copilot-instructions.md               # Copilot workspace instructions
├── README.md                             # Chinese documentation
└── README.en.md                          # This file
```

---

## 🤖 Using the Copilot Skill (`lc:` commands)

This project has a built-in VS Code Copilot Skill for managing problems.

### Scaffold a New Problem

```powershell
lc: scaffold TwoSum
lc: scaffold new problem MergeIntervals
```

The Skill will:
1. Create `.cs` skeleton in `Problems/<Name>/`
2. Create xUnit test file in `Tests/<Name>/`
3. Ask for a **category tag** (Array, String, Tree, DP, etc.)
4. Ask for a **source** (LeetCode / LeetCode Variant / NeetCode 150 / Custom)
5. Update the problem list

### Remove a Problem

```powershell
lc: remove WaferScanOptimizer
lc: delete problem TwoSum
```

Skill confirms, then deletes the entire problem folder and runs `dotnet test`.

### Rename a Problem

```powershell
lc: rename TwoSum to TwoSumV2
```

Skill renames the folder and updates the class name inside.

### List All Problems

```powershell
lc: list
lc: list problems
```

Skill scans all problem folders, reads XML doc comments, and generates `LeetCodeProblems.md`.

> 💡 **Tip**: Press `Ctrl+Shift+I` in VS Code to open Quick Chat and type `lc: list` directly.

---

## 🧪 Testing

### Run All Tests

```powershell
dotnet test
```

### Run a Single Problem's Tests

```powershell
dotnet test --filter TwoSumTests
dotnet test --filter WaferScanOptimizerTests
dotnet test --filter "FullyQualifiedName~TwoPointers"
```

### Test Coverage

Each test file covers:
- ✅ Happy Path
- ✅ Edge Cases
- ✅ Invalid Inputs
- ✅ Stress / Large Data

---

## 📖 Learning Philosophy: Try First, Then Verify

```
TwoSum/
├── TwoSum.cs         # Problem skeleton (TODO — your turn to implement)
└── ANSWER.md         # Solution guide — open ONLY after you've tried
```

### Recommended Workflow

| Step | Action |
|:----:|--------|
| 1️⃣ | Open `.cs`, read the problem description |
| 2️⃣ | **Write your own solution**, run `dotnet test --filter TwoSumTests` |
| 3️⃣ | Stuck for 15+ min? Ask Copilot for hints (see below) |
| 4️⃣ | Finished? Open `ANSWER.md` and **compare** your solution |
| 5️⃣ | Reflect: Why this approach? Any better alternatives? |

---

## 🤖 Getting Help from Copilot

### Review Your Solution

Select your code in VS Code and ask:

```
Review this solution for correctness, potential bugs, and performance issues.
```

### Debug a Failing Test

```
This test is failing, can you help me fix it?
[paste error message]
```

### Completely Stuck?

```
I don't understand LC 200 Number of Islands. Explain it in plain language.
```

```
Don't give me the answer — just hint what data structure or algorithm to use.
```

```
Use the Socratic method: ask me one question at a time to guide me to the solution.
```

### Compare with ANSWER.md

After finishing, select your code and the ANSWER.md solution, then ask:

```
Compare these two solutions. What are the trade-offs?
```

### Mock Interview

```
Act as a semiconductor equipment company interviewer. Ask me about thread safety
and give feedback on my answers.
```

---

## 📋 Generate Interview Prep List from a Job Description

Paste a job description to Copilot and say:

```
This is my interview notification. Find the most relevant problems from the
problem bank and generate a study list.
```

The Skill will:
1. **Analyze the JD** — identify key technologies (C#, process control, protocols, etc.)
2. **Match the problem bank** — filter relevant problems by priority
3. **Generate `Interview-Prep-List.md`** — with a weekly study plan

---

## 🛠 Scripts

Located in `.agents/skills/leetcode-helper/scripts/`:

| Script | Purpose |
|--------|---------|
| `batch-scaffold-neetcode150.ps1` | Batch create all NeetCode 150 templates |
| `fetch-and-update-descriptions.ps1` | Fetch problem descriptions from LeetCode API |
| `fix-nested-summary.ps1` | Fix nested XML doc comments |
| `reorganize-to-folders.ps1` | Reorganize problems into folders |

---

## 📋 Problem Sources

| Source | Description | Count |
|--------|-------------|:-----:|
| **NeetCode 150** | Curated LeetCode top 150 | ~145 |
| **LeetCode** | Original problems | ~2 |
| **LeetCode Variant** | Semiconductor-context variants | ~2 |
| **Custom** | Custom interview problems | ~2 |

---

## 🤝 Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md).

---

## 📝 License

For personal learning and interview preparation only.
