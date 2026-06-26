# DoNetLeetCodePractice Copilot Instructions

This workspace contains a custom skill for managing LeetCode problems.

## Available Skill: leetcode-helper

### Direct Invocation
Use the short prefix `lc:` in chat:

#### Scaffold (新增)
- `lc: scaffold <ProblemName>`
- `lc: scaffold new problem <ProblemName>`
- `scaffold <ProblemName>` (implicit)

#### Remove (移除)
- `lc: remove <ProblemName>`
- `lc: delete problem <ProblemName>`

#### Rename (重新命名)
- `lc: rename <OldName> to <NewName>`

#### List (列出所有問題)
- `lc: list problems`
- `lc: list all`
- `lc: show all problems`

### What It Does

**Scaffold** — When you use any scaffold command, I will:
1. Generate `LeetCodePractice/Problems/<ProblemName>.cs` from the template
2. Generate `LeetCodePractice.Tests/<ProblemName>Tests.cs` from the template
3. Provide you with empty, commented templates to fill in

**Remove** — When you use any remove command, I will:
1. Confirm with you before proceeding
2. Delete `LeetCodePractice/Problems/<ProblemName>.cs`
3. Delete `LeetCodePractice.Tests/<ProblemName>Tests.cs`
4. Run `dotnet test` to verify nothing is broken

**Rename** — When you use any rename command, I will:
1. Rename the problem and test files
2. Update the class name inside both files
3. Run `dotnet test` to verify everything still works

**List** — When you use any list command, I will:
1. Scan `LeetCodePractice/Problems/` for all problem files
2. Read problem descriptions from XML doc comments
3. Generate `LeetCodeProblems.md` at the repository root with full descriptions and file links
4. Show a summary table in chat

### Important
- Scaffold creates **template files only** — it does not solve the problem
- You must add the problem description and implement the solution yourself
- Test files will have placeholder comments for expected values

### Examples

**Example 1**: Scaffold a new problem called "MergeIntervals"
```
lc: scaffold MergeIntervals
```

**Example 2**: Remove a problem
```
lc: remove WaferScanOptimizer
```

**Example 3**: Rename a problem
```
lc: rename TwoSum to TwoSumV2
```

**Example 4**: List all problems
```
lc: list problems
```

## Workspace Structure
- `LeetCodePractice/Problems/` — Your problem implementations
- `LeetCodePractice.Tests/` — Your xUnit test files
- `ProblemTemplate.cs` — Template for new problems
- `ProblemTemplateTests.cs` — Template for new tests

## Running Tests
```powershell
cd <repository-root>
dotnet test
```

## SKILL Folder Structure
```
.agents/skills/leetcode-helper/
├── SKILL.md               # Skill descriptor
├── prompt.md              # Execution logic
├── resources/
│   └── problem-list.md    # Canonical problem list
├── references/
│   └── project-structure.md
└── scripts/               # Automation scripts (future)
```

## Related Files
- `.agents/skills/leetcode-helper/SKILL.md` — Skill definition
- `.agents/skills/leetcode-helper/prompt.md` — Execution logic
- `.agents/skills/leetcode-helper/resources/problem-list.md` — Canonical problem list
- `.agents/skills/leetcode-helper/references/project-structure.md` — Project reference
- `README.md` — Full project documentation
