---
name: leetcode-helper
description: Manage LeetCode problems - scaffold, remove, rename, list. Use "lc:" short prefix in chat.
---

# LeetCode Helper Prompt Handler

When the user requests to manage a LeetCode problem (scaffold, remove, rename, or list),
follow the corresponding steps below.

---

## Scaffold (新增題目)

### Recognize These Patterns
- `lc: scaffold <ProblemName>`
- `lc: scaffold new problem <ProblemName>`
- "Please create a new problem template for <ProblemName>"
- "Scaffold a new problem called <ProblemName>"

### Action
When recognized, immediately:

1. **Ask for category**: Ask the user: "請輸入分類標籤（例如 Array, String, Tree, DP, Design / LRU, Interval 等）"
   - 此欄位為必填，由使用者手動輸入。
   - 若使用者未回答，應等待使用者提供分類後再繼續，不可自動推斷。

2. **Ask for source**: Ask the user: "請選擇題目來源：`LeetCode`（原題）、`LeetCode Variant`（延伸變形）、`NeetCode 150`（精選列表）或 `Custom`（自訂題目）"
   - 此欄位為必填，由使用者選擇。

3. **Create Problem Folder and File**: `LeetCodePractice/Problems/<ProblemName>/<ProblemName>.cs`
   - Use the pattern from `ProblemTemplate.cs`
   - Replace class name with user's ProblemName
   - Add TODO comments for problem description and implementation
   - Do NOT implement the solution

4. **Create Test Folder and File**: `LeetCodePractice.Tests/<ProblemName>/<ProblemName>Tests.cs`
   - Use the pattern from `ProblemTemplateTests.cs`
   - Add at least one example test case
   - Include placeholder comments to update expected values
   - Do NOT implement test assertions with correct values

5. **Update problem list**: Add the new problem (with category and source) to `.agents/skills/leetcode-helper/resources/problem-list.md`

6. **Confirm**: Show the user the created folder paths and remind them to:
   - Add problem description as comments
   - Add test cases with expected values
   - Implement their solution

### Example Execution
**User**: `lc: scaffold MergeIntervals`

**Action**:
- Ask category → user says "Array / Interval"
- Ask source → user says "LeetCode"
- Create `LeetCodePractice/Problems/MergeIntervals/MergeIntervals.cs` based on template
- Create `LeetCodePractice.Tests/MergeIntervals/MergeIntervalsTests.cs` based on template
- Update `.agents/skills/leetcode-helper/resources/problem-list.md` with category "Array / Interval" and source "LeetCode"
- Output: "✓ Created MergeIntervals problem scaffold [Array / Interval][LeetCode]"

---

## Remove (移除題目)

### Recognize These Patterns
- `lc: remove <ProblemName>`
- `lc: delete problem <ProblemName>`
- `lc: remove problem <ProblemName>`
- "Please remove <ProblemName>"
- "Delete the problem <ProblemName>"

### Action
When recognized, immediately:

1. **Confirm**: Ask the user to confirm they want to delete both folders:
   - `LeetCodePractice/Problems/<ProblemName>/`
   - `LeetCodePractice.Tests/<ProblemName>/`

2. **Delete Folders**: After confirmation, recursively delete both folders.

3. **Update problem list**: Remove the problem from `.agents/skills/leetcode-helper/resources/problem-list.md`

4. **Verify**: Run `dotnet test` to ensure nothing else is broken.

### Example Execution
**User**: `lc: remove WaferScanOptimizer`

**Action**:
- Confirm with user
- Delete `LeetCodePractice/Problems/WaferScanOptimizer/`
- Delete `LeetCodePractice.Tests/WaferScanOptimizer/`
- Update `.agents/skills/leetcode-helper/resources/problem-list.md`
- Run `dotnet test`
- Output: "✓ Removed WaferScanOptimizer and its test folder. dotnet test passed."

---

## Rename (重新命名題目)

### Recognize These Patterns
- `lc: rename <OldName> to <NewName>`
- `lc: rename problem <OldName> to <NewName>`
- "Please rename <OldName> to <NewName>"

### Action
When recognized, immediately:

1. **Rename Folders**:
   - Rename `LeetCodePractice/Problems/<OldName>/` → `LeetCodePractice/Problems/<NewName>/`
   - Rename `LeetCodePractice.Tests/<OldName>/` → `LeetCodePractice.Tests/<NewName>/`

2. **Update Class Names**: Read both `.cs` files and update the class declaration from `<OldName>` to `<NewName>`.

3. **Update problem list**: Update the entry in `.agents/skills/leetcode-helper/resources/problem-list.md`

4. **Verify**: Run `dotnet test` to ensure everything still works.

### Example Execution
**User**: `lc: rename TwoSum to TwoSumV2`

**Action**:
- Rename `LeetCodePractice/Problems/TwoSum/` → `LeetCodePractice/Problems/TwoSumV2/`
- Rename `LeetCodePractice.Tests/TwoSum/` → `LeetCodePractice.Tests/TwoSumV2/`
- Update class name inside both `.cs` files
- Update `.agents/skills/leetcode-helper/resources/problem-list.md`
- Run `dotnet test`
- Output: "✓ Renamed TwoSum to TwoSumV2. dotnet test passed."

---

## List (列出所有題目)

### Recognize These Patterns
- `lc: list problems`
- `lc: list all`
- `lc: show all problems`
- "Show me all problems"
- "List all problems"

### Action
When recognized, immediately:

1. **Read problem list**: Read `.agents/skills/leetcode-helper/resources/problem-list.md` for the canonical list.

2. **Scan**: Scan all subdirectories in `LeetCodePractice/Problems/`, each subdirectory is one problem. Exclude shared type folders (none, since they are files like `ListNode.cs` at root level). Cross-check with the problem list.

3. **Check Test Status**: For each problem, check if a `LeetCodePractice.Tests/<ProblemName>/<ProblemName>Tests.cs` file exists.

4. **Read descriptions and source**: For each problem file, read the XML doc comment (`/// <summary>`) to extract:
   - Problem title (first line of summary)
   - Corresponding LeetCode number (e.g., "LC 146 LRU Cache")
   - Brief description (the main body of the comment)
   - Also get the **Source** from the problem list (LeetCode / LeetCode Variant / Custom)

5. **Generate `LeetCodeProblems.md`**: Create or overwrite `LeetCodeProblems.md` at the repository root with:
   ```markdown
   # LeetCode Problems
   
   | # | Source | Category | Problem | LeetCode | Status |
   |---|--------|----------|---------|----------|--------|
   | 1 | LeetCode | Category | Name | LC xxx | ✅ |
   
   ---
   
   ## 依分類瀏覽
   
   ### CategoryName
   
   #### ProblemName
   **[Source] LC xxx Original**
   Brief description...
   - [Implementation](LeetCodePractice/Problems/ProblemName/ProblemName.cs)
   - [Tests](LeetCodePractice.Tests/ProblemName/ProblemNameTests.cs)
   ```

6. **Display**: Show a summary table and file path in chat.

### Example Execution
**User**: `lc: list problems`

**Action**:
- Read `.agents/skills/leetcode-helper/resources/problem-list.md`
- Cross-check with actual files
- Read XML doc comments from each problem file
- Generate `LeetCodeProblems.md` at root
- Output: "✓ 已產生 LeetCodeProblems.md，共 N 題"

---

## Key Rules
- **Scaffold**: ONLY scaffolding — template generation without solution implementation.
- **Remove**: Always confirm with the user before deleting files.
- **Rename**: Update class names inside files, not just filenames.
- **List**: Exclude template files from the listing.
- **Problem List**: Always update `.agents/skills/leetcode-helper/resources/problem-list.md` after add/remove/rename.
- Do not write the algorithm or test logic for scaffold.
- Keep the templates minimal and focused on structure.
