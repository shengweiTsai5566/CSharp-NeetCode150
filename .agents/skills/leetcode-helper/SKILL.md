---
name: leetcode-helper
description: Scaffold, remove, rename, and list LeetCode problems in this workspace. Use "lc:" as short prefix. Manage problem files and xUnit tests.
applyTo: ["**/*"]
---

# LeetCode Helper Skill

This is a local workspace skill for `DoNetLeetCodePractice`.
It provides commands to scaffold, remove, rename, and manage LeetCode problem
implementation files in `LeetCodePractice/Problems` and matching xUnit test
files in `LeetCodePractice.Tests`.

## Purpose
- Create starter files for a new LeetCode problem without solving it (scaffold).
- Remove an existing problem and its test file (remove).
- Rename an existing problem and its test file (rename).
- List all existing problems in the workspace (list).
- Preserve the repository structure and naming conventions.
- Provide comments and placeholders for the developer to complete.
- **Generate comprehensive unit test cases including edge cases and failure scenarios** to catch bugs early and improve code accuracy.

## Behavior — Scaffold
- When the user requests a new problem template, generate:
  - `LeetCodePractice/Problems/<ProblemName>.cs`
  - `LeetCodePractice.Tests/<ProblemName>Tests.cs`
- Use `ProblemTemplate.cs` as the base pattern for new problem files.
- **Ask the user for a category tag** (e.g. "Array", "Hash Table", "String", "Tree", "DP", "Design / LRU", "Interval"). This is required — the user must provide it manually; do not auto-infer.
- **Ask the user for a source tag** — choose from: `LeetCode` (原題), `LeetCode Variant` (延伸變形), `NeetCode 150` (精選列表), or `Custom` (自訂題目). This is required.
- **Generate multiple test cases covering:**
  - Happy path cases (正常情況)
  - Edge cases (邊界情況，如空值、最小值、最大值)
  - Boundary conditions (邊界條件)
  - Invalid inputs (無效輸入)
  - Off-by-one scenarios (邊界差一錯誤)
  - Stress cases (大數據或特殊場景)
- Include at least **5-10 test methods** to maximize bug detection and code accuracy.
- Do not implement the problem solution unless explicitly asked.

## Behavior — Remove
- When the user requests to remove a problem, delete both files:
  - `LeetCodePractice/Problems/<ProblemName>.cs`
  - `LeetCodePractice.Tests/<ProblemName>Tests.cs`
- Confirm deletion with the user before proceeding.
- Run `dotnet test` after deletion to verify nothing else broke.

## Behavior — Rename
- When the user requests to rename a problem from `<OldName>` to `<NewName>`:
  - Rename `LeetCodePractice/Problems/<OldName>.cs` → `LeetCodePractice/Problems/<NewName>.cs`
  - Rename `LeetCodePractice.Tests/<OldName>Tests.cs` → `LeetCodePractice.Tests/<NewName>Tests.cs`
- Update the class name inside both files to match the new name.
- Update any `using` or namespace references if needed.
- Run `dotnet test` after renaming to verify everything still works.

## Behavior — List
- When the user requests to list all problems, scan `LeetCodePractice/Problems/` for `.cs` files.
- Exclude `ProblemTemplate.cs` from the listing (it is a template, not a real problem).
- For each problem file, read the XML doc comment (`/// <summary>`) to extract the problem title and description.
- **Generate a `LeetCodeProblems.md` file at the repository root** containing:
  - A table of all problems with category, status icons
  - Problems **grouped by category** (e.g. "Array", "String", "Design") for easy browsing
  - For each problem: title, description, and links to implementation & test files
- Also display a summary table with categories in chat.

## Examples

### Scaffold a new problem
If the user asks for `MergeIntervals`, the skill should create:
- `LeetCodePractice/Problems/MergeIntervals.cs`
- `LeetCodePractice.Tests/MergeIntervalsTests.cs`

### Remove an existing problem
If the user asks to remove `WaferScanOptimizer`, the skill should delete:
- `LeetCodePractice/Problems/WaferScanOptimizer.cs`
- `LeetCodePractice.Tests/WaferScanOptimizerTests.cs`

### Rename an existing problem
If the user asks to rename `TwoSum` to `TwoSumV2`, the skill should:
- Rename both files and update class names inside them.

### List all problems
Running `lc: list` generates `LeetCodeProblems.md` at the root with full descriptions and file links, plus a chat summary.

###### Problem list output (partial example)
```
## DeviceParameterCache
**LC 146 LRU Cache 變形**
實作 LRU 快取，支援 Get / Put，使用 Array-based 鏈結串列避免 GC。
- [實作檔](LeetCodePractice/Problems/DeviceParameterCache.cs)
- [測試檔](LeetCodePractice.Tests/DeviceParameterCacheTests.cs)
```

## Test Strategy (測試驅動設計)
- **多層次測試覆蓋** : 不僅測試正常流程，更要測試邊界、異常、無效輸入
- **失敗測試案例** : 專注於找出程式碼漏洞 (Edge cases, Off-by-one, Null/Empty, 大數據)
- **測試設計先行** : 在實現解決方案前先設計全面的測試案例，有助於提升代碼精準度和覆蓋率
- **每個測試應關注一個特定行為** : 確保單位測試專注、獨立、可重複執行

## Notes
- Do not solve the problem unless explicitly asked.
- Provide a template structure and comments for the user to fill in.
- This is a local workspace skill descriptor; it is not automatically installed as a global GitHub Copilot skill.

## Command-style invocation
Use these explicit commands when asking the assistant:

### Scaffold (新增)
- `lc: scaffold MergeIntervals`
- `lc: scaffold new problem MergeIntervals`
- `lc: scaffold <ProblemName>`

### Remove (移除)
- `lc: remove WaferScanOptimizer`
- `lc: delete problem WaferScanOptimizer`
- `lc: remove <ProblemName>`

### Rename (重新命名)
- `lc: rename TwoSum to TwoSumV2`
- `lc: rename <OldName> to <NewName>`

### List (列出所有問題)
- `lc: list problems`
- `lc: list all`
- `lc: show all problems`

The assistant should recognize requests that follow these command patterns and perform the corresponding operations on:
- `LeetCodePractice/Problems/<ProblemName>.cs`
- `LeetCodePractice.Tests/<ProblemName>Tests.cs`

## Resources
- Problem list tracking: `resources/problem-list.md` (update after each add/remove/rename)
- Project structure reference: `references/project-structure.md`
- Automation scripts: `scripts/`

## Scope
- Local workspace skill only.
- Not a global GitHub Copilot skill implementation.
- Intended for use inside this repository only.