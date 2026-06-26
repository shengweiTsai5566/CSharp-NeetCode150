---
name: leetcode-helper
description: 管理 LeetCode 題目 - 建立模板、移除、重新命名、列出。在對話中使用短前綴 "lc:"。
---

# LeetCode Helper 提示處理器

當使用者要求管理 LeetCode 題目（建立模板、移除、重新命名或列出）時，
依照下列對應步驟執行。

---

## 建立模板（新增題目）

### 辨識以下模式
- `lc: scaffold <ProblemName>`
- `lc: scaffold new problem <ProblemName>`
- 「請為 <ProblemName> 建立新的題目模板」
- 「建立一個名為 <ProblemName> 的新題目」

### 執行步驟
辨識後立即執行：

1. **詢問分類**：詢問使用者：「請輸入分類標籤（例如 Array, String, Tree, DP, Design / LRU, Interval 等）」
   - 此欄位為必填，由使用者手動輸入。
   - 若使用者未回答，應等待使用者提供分類後再繼續，不可自動推斷。

2. **詢問來源**：詢問使用者：「請選擇題目來源：`LeetCode`（原題）、`LeetCode Variant`（延伸變形）、`NeetCode 150`（精選列表）或 `Custom`（自訂題目）」
   - 此欄位為必填，由使用者選擇。

3. **建立題目檔案**：`LeetCodePractice/Problems/<ProblemName>.cs`
   - 使用 `ProblemTemplate.cs` 的模式
   - 將類別名稱取代為使用者的 ProblemName
   - 加入 TODO 註解供題目描述與實作使用
   - **不要**實作解法

3. **建立測試檔案**：`LeetCodePractice.Tests/<ProblemName>Tests.cs`
   - 使用 `ProblemTemplateTests.cs` 的模式
   - 加入至少一個範例測試案例
   - 包含佔位符註解，提示更新預期值
   - **不要**實作含有正確值的測試驗證

4. **更新題目清單**：將新題目（含分類）加入 `.agents/skills/leetcode-helper/resources/problem-list.md`

5. **確認**：向使用者顯示建立的兩個檔案路徑，並提醒他們：
   - 加入題目描述作為註解
   - 加入含有預期值的測試案例
   - 實作他們的解法

### 執行範例
**使用者**：`lc: scaffold MergeIntervals`

**動作**：
- 根據模板建立 `LeetCodePractice/Problems/MergeIntervals.cs`
- 根據模板建立 `LeetCodePractice.Tests/MergeIntervalsTests.cs`
- 更新 `.agents/skills/leetcode-helper/resources/problem-list.md`
- 輸出：「✓ 已建立 MergeIntervals 題目模板」

---

## 移除（移除題目）

### 辨識以下模式
- `lc: remove <ProblemName>`
- `lc: delete problem <ProblemName>`
- `lc: remove problem <ProblemName>`
- 「請移除 <ProblemName>」
- 「刪除題目 <ProblemName>」

### 執行步驟
辨識後立即執行：

1. **確認**：詢問使用者是否確定要刪除兩個檔案：
   - `LeetCodePractice/Problems/<ProblemName>.cs`
   - `LeetCodePractice.Tests/<ProblemName>Tests.cs`

2. **刪除檔案**：獲得確認後，刪除兩個檔案。

3. **更新題目清單**：從 `.agents/skills/leetcode-helper/resources/problem-list.md` 中移除該題目

4. **驗證**：執行 `dotnet test` 確保沒有破壞其他功能。

### 執行範例
**使用者**：`lc: remove WaferScanOptimizer`

**動作**：
- 與使用者確認
- 刪除 `LeetCodePractice/Problems/WaferScanOptimizer.cs`
- 刪除 `LeetCodePractice.Tests/WaferScanOptimizerTests.cs`
- 更新 `.agents/skills/leetcode-helper/resources/problem-list.md`
- 執行 `dotnet test`
- 輸出：「✓ 已移除 WaferScanOptimizer 及其測試檔。dotnet test 通過。」

---

## 重新命名（重新命名題目）

### 辨識以下模式
- `lc: rename <OldName> to <NewName>`
- `lc: rename problem <OldName> to <NewName>`
- 「請將 <OldName> 重新命名為 <NewName>」

### 執行步驟
辨識後立即執行：

1. **重新命名檔案**：
   - 將 `LeetCodePractice/Problems/<OldName>.cs` 重新命名為 `LeetCodePractice/Problems/<NewName>.cs`
   - 將 `LeetCodePractice.Tests/<OldName>Tests.cs` 重新命名為 `LeetCodePractice.Tests/<NewName>Tests.cs`

2. **更新類別名稱**：讀取兩個重新命名後的檔案，將類別宣告從 `<OldName>` 更新為 `<NewName>`。

3. **更新題目清單**：更新 `.agents/skills/leetcode-helper/resources/problem-list.md` 中的對應項目

4. **驗證**：執行 `dotnet test` 確保一切仍正常運作。

### 執行範例
**使用者**：`lc: rename TwoSum to TwoSumV2`

**動作**：
- 重新命名檔案
- 更新兩個檔案內部的類別名稱
- 更新 `.agents/skills/leetcode-helper/resources/problem-list.md`
- 執行 `dotnet test`
- 輸出：「✓ 已將 TwoSum 重新命名為 TwoSumV2。dotnet test 通過。」

---

## 列出（列出所有題目）

### 辨識以下模式
- `lc: list problems`
- `lc: list all`
- `lc: show all problems`
- 「顯示所有題目」
- 「列出所有題目」

### 執行步驟
辨識後立即執行：

1. **讀取題目清單**：讀取 `.agents/skills/leetcode-helper/resources/problem-list.md` 作為標準清單。

2. **掃描**：列出 `LeetCodePractice/Problems/` 中所有 `.cs` 檔案（排除 `ProblemTemplate.cs`），並與題目清單交叉比對。

3. **檢查測試狀態**：對於每個題目，檢查 `LeetCodePractice.Tests/` 中是否存在對應的 `<ProblemName>Tests.cs` 檔案。

4. **讀取說明**：對每個題目檔案，讀取 XML 文件註解（`/// <summary>`）以取得：
   - 題目標題（summary 第一行）
   - 對應 LeetCode 編號（例如「LC 146 LRU Cache」）
   - 簡短描述（註解的主要內容）

5. **產生 `LeetCodeProblems.md`**：在儲存庫根目錄建立或覆寫 `LeetCodeProblems.md`，格式如下：
   ```markdown
   # LeetCode Problems
   
   | # | Problem | LeetCode | Status |
   |---|---------|----------|--------|
   | 1 | ProblemName | LC xxx | ✅ |
   
   ---
   
   ## ProblemName
   **LC xxx Original**
   簡短描述...
   - [實作檔](LeetCodePractice/Problems/ProblemName.cs)
   - [測試檔](LeetCodePractice.Tests/ProblemNameTests.cs)
   ```

6. **顯示**：在對話中顯示摘要表格與檔案路徑。

### 執行範例
**使用者**：`lc: list problems`

**動作**：
- 讀取 `.agents/skills/leetcode-helper/resources/problem-list.md`
- 與實際檔案交叉比對
- 讀取每個題目檔案的 XML 文件註解
- 在根目錄產生 `LeetCodeProblems.md`
- 輸出：「✓ 已產生 LeetCodeProblems.md，共 N 題」

---

## 關鍵規則
- **建立模板**：僅建立模板 — 不實作解法。
- **移除**：刪除檔案前務必先與使用者確認。
- **重新命名**：不僅重新命名檔案，也要更新內部的類別名稱。
- **列出**：從清單中排除範本檔案。
- **題目清單**：每次新增/移除/重新命名後，務必更新 `.agents/skills/leetcode-helper/resources/problem-list.md`。
- 不要為建立模板撰寫演算法或測試邏輯。
- 保持模板精簡且專注於結構。
