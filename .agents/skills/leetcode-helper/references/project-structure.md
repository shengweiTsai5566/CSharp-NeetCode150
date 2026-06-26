# Project Structure Reference

## Directory Layout

```
DoNetLeetterCodePractice/
├── .agents/
│   └── skills/
│       └── leetcode-helper/             # 🎯 Skill folder (this skill)
│           ├── SKILL.md                  # Skill descriptor
│           ├── prompt.md                 # Prompt handler
│           ├── resources/
│           │   └── problem-list.md       # Canonical problem list
│           ├── references/
│           │   └── project-structure.md  # This file
│           └── scripts/                  # Automation scripts (future)
├── LeetCodePractice/                     # Console app project
│   ├── Problems/                         # Problem implementations
│   │   ├── CommandParser.cs              # LC 65/8 variant
│   │   ├── TwoSum.cs                     # LC 1
│   │   ├── WaferScanOptimizer.cs         # Interval merge variant
│   │   └── ProblemTemplate.cs            # Template (not a real problem)
│   ├── Program.cs                        # Entry point (uses CommandParser)
│   └── LeetCodePractice.csproj
├── LeetCodePractice.Tests/               # xUnit test project
│   ├── CommandParserTests.cs
│   ├── TwoSumTests.cs
│   ├── WaferScanOptimizerTests.cs
│   ├── ProblemTemplateTests.cs
│   └── UnitTest1.cs
├── copilot-instructions.md               # Workspace Copilot instructions
├── README.md
└── DoNetLeetCodePractice.sln
```

## Conventions

### Problem File
- Location: `LeetCodePractice/Problems/<ProblemName>.cs`
- Namespace: `LeetCodePractice.Problems`
- Class name matches filename (PascalCase)
- Public method `Solve(...)` or domain-specific method name

### Test File
- Location: `LeetCodePractice.Tests/<ProblemName>Tests.cs`
- Uses xUnit (`[Fact]` attributes)
- References problem class via `using LeetCodePractice.Problems;`

### Running Tests
```powershell
cd <repository-root>
dotnet test
```
