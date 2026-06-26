# Contributing to DoNetLeetCodePractice

Thanks for your interest in contributing! 🎉

This project is a **learning-first** LeetCode practice environment. The goal is not just to have answers, but to help people **think, implement, and then verify**.

---

## 🧭 Philosophy

```
Write code first → then look at ANSWER.md to verify
```

Please keep this in mind when contributing. ANSWER.md is a **verification tool**, not a "give me the answer" cheat sheet.

---

## 🐛 Reporting Issues

- Found a bug in the solution code? Open an issue.
- Have a better solution approach? Open an issue or PR.
- Want to request a missing NeetCode 150 problem? Open an issue.

---

## 🚀 How to Contribute

### 1️⃣ Add a Missing Problem

If a problem from NeetCode 150 is missing:

1. Create a folder `LeetCodePractice/Problems/<ProblemName>/`
2. Create `<ProblemName>.cs` with:
   - Proper namespace `LeetCodePractice.Problems`
   - XML doc comment with problem description
   - Method signature (return type + parameters)
   - `throw new NotImplementedException();` (no solution!)
3. Create `LeetCodePractice.Tests/<ProblemName>/<ProblemName>Tests.cs` with xUnit tests
4. Create `ANSWER.md` with the full solution (approach, complexity, code)
5. Update `.agents/skills/leetcode-helper/resources/problem-list.md`

### 2️⃣ Improve an Existing Solution

If you have a better approach:

1. Update the `ANSWER.md` — add your approach alongside the existing one
2. Mention the trade-offs compared to the original

### 3️⃣ Add a Semiconductor Custom Problem

We value real-world problems from semiconductor equipment contexts:

- E-beam / AOI inspection
- Wafer map processing
- State machine / protocol parsing
- Thread-safe command queues
- Hardware abstraction layers

### 4️⃣ Improve the Copilot Skill

The Skill lives in `.agents/skills/leetcode-helper/`. Improvements to:

- `SKILL.md` — behavior descriptions
- `prompt.md` / `prompt.zh.md` — execution logic
- `scripts/` — automation scripts

---

## ✅ Pull Request Checklist

Before submitting a PR:

- [ ] `dotnet build` passes with no errors
- [ ] `dotnet test` passes for the affected problems
- [ ] Code follows C# conventions (PascalCase methods, camelCase params)
- [ ] All files are in the correct folder structure
- [ ] No hardcoded absolute paths (use `$PSScriptRoot` in scripts)
- [ ] ANSWER.md uses Traditional Chinese (zh-TW) for explanations

---

## 📁 Folder Structure Rules

```
Problems/<ProblemName>/
├── <ProblemName>.cs         # Required — skeleton (no solution)
├── ANSWER.md                # Required — full solution guide
└── (optional: additional files)

Tests/<ProblemName>/
└── <ProblemName>Tests.cs    # Required — xUnit tests
```

---

## 📝 Code Style

- Use `namespace LeetCodePractice.Problems;` (file-scoped)
- Method signature: `public ReturnType Solve(Parameters)`
- Use `throw new NotImplementedException();` for unsolved skeletons
- Use English method names, Chinese comments for problem descriptions (optional)

---

## ❓ Questions

Open an issue or ask in the Discussions tab.

Thank you for helping others learn! 💪
