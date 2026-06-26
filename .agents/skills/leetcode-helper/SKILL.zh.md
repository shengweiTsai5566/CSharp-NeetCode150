---
name: leetcode-helper
description: 在此工作區中建立、移除、重新命名與列出 LeetCode 題目。使用短前綴 "lc:"。管理問題檔案與 xUnit 測試。
applyTo: ["**/*"]
---

# LeetCode Helper 技能

這是 `DoNetLeetCodePractice` 的本地工作區技能。
提供在 `LeetCodePractice/Problems` 中建立、移除、重新命名與管理 LeetCode 題目實作檔案，
以及 `LeetCodePractice.Tests` 中對應的 xUnit 測試檔案的指令。

## 目的
- 為新的 LeetCode 題目建立起始檔案，不需實作解法（scaffold，建立模板）。
- 移除既有題目與其測試檔（remove，移除）。
- 重新命名既有題目與其測試檔（rename，重新命名）。
- 列出工作區中所有既有的題目（list，列出）。
- 保留儲存庫的結構與命名慣例。
- 提供註解與佔位符，讓開發者自行填寫。
- **產生包含邊界情況與失敗情境的全面單元測試案例**，以便及早發現錯誤並提升程式碼準確性。

## 行為 — 建立模板（Scaffold）
- 當使用者要求新的題目模板時，產生：
  - `LeetCodePractice/Problems/<ProblemName>.cs`
  - `LeetCodePractice.Tests/<ProblemName>Tests.cs`
- 使用 `ProblemTemplate.cs` 作為新題目檔案的基本模式。
- **產生多個測試案例，涵蓋：**
  - 正常情況（Happy path）
  - 邊界情況（Edge cases，如空值、最小值、最大值）
  - 邊界條件（Boundary conditions）
  - 無效輸入（Invalid inputs）
  - 邊界差一錯誤（Off-by-one scenarios）
  - 壓力測試（大數據或特殊場景）
- 至少包含 **5-10 個測試方法**，以最大化錯誤偵測與程式碼準確性。
- 除非明確要求，否則不實作題目解法。

## 行為 — 移除（Remove）
- 當使用者要求移除題目時，刪除兩個檔案：
  - `LeetCodePractice/Problems/<ProblemName>.cs`
  - `LeetCodePractice.Tests/<ProblemName>Tests.cs`
- 在執行前先與使用者確認。
- 刪除後執行 `dotnet test`，確認沒有破壞其他功能。

## 行為 — 重新命名（Rename）
- 當使用者要求將題目從 `<OldName>` 重新命名為 `<NewName>` 時：
  - 將 `LeetCodePractice/Problems/<OldName>.cs` 重新命名為 `LeetCodePractice/Problems/<NewName>.cs`
  - 將 `LeetCodePractice.Tests/<OldName>Tests.cs` 重新命名為 `LeetCodePractice.Tests/<NewName>Tests.cs`
- 更新兩個檔案內部的類別名稱以符合新名稱。
- 必要時更新任何 `using` 或命名空間參照。
- 重新命名後執行 `dotnet test`，確認一切仍正常運作。

## 行為 — 列出（List）
- 當使用者要求列出所有題目時，掃描 `LeetCodePractice/Problems/` 中的 `.cs` 檔案。
- 排除 `ProblemTemplate.cs`（它是範本，不是實際題目）。
- 顯示每個題目名稱與其對應測試檔案狀態（存在 / 遺失）。

## 範例

### 建立新題目模板
如果使用者要求 `MergeIntervals`，技能應建立：
- `LeetCodePractice/Problems/MergeIntervals.cs`
- `LeetCodePractice.Tests/MergeIntervalsTests.cs`

### 移除既有題目
如果使用者要求移除 `WaferScanOptimizer`，技能應刪除：
- `LeetCodePractice/Problems/WaferScanOptimizer.cs`
- `LeetCodePractice.Tests/WaferScanOptimizerTests.cs`

### 重新命名既有題目
如果使用者要求將 `TwoSum` 重新命名為 `TwoSumV2`，技能應：
- 重新命名兩個檔案並更新內部的類別名稱。

### 列出所有題目
| Problem | Test File | Status |
|---------|-----------|--------|
| CommandParser | CommandParserTests.cs | ✅ |
| TwoSum | TwoSumTests.cs | ✅ |

## 測試策略（測試驅動設計）
- **多層次測試覆蓋**：不僅測試正常流程，更要測試邊界、異常、無效輸入。
- **失敗測試案例**：專注於找出程式碼漏洞（Edge cases, Off-by-one, Null/Empty, 大數據）。
- **測試設計先行**：在實作解決方案前先設計全面的測試案例，有助於提升程式碼精準度與覆蓋率。
- **每個測試應關注一個特定行為**：確保單元測試專注、獨立、可重複執行。

## 注意事項
- 除非明確要求，否則不解題。
- 提供範本結構與註解，供使用者填寫。
- 這是本地工作區技能描述檔，不會自動安裝為全域 GitHub Copilot 技能。

## 指令式呼叫
在與助理對話時使用以下明確指令：

### 建立模板（新增）
- `lc: scaffold MergeIntervals`
- `lc: scaffold new problem MergeIntervals`
- `lc: scaffold <ProblemName>`

### 移除（移除）
- `lc: remove WaferScanOptimizer`
- `lc: delete problem WaferScanOptimizer`
- `lc: remove <ProblemName>`

### 重新命名（重新命名）
- `lc: rename TwoSum to TwoSumV2`
- `lc: rename <OldName> to <NewName>`

### 列出（列出所有問題）
- `lc: list problems`
- `lc: list all`
- `lc: show all problems`

助理應辨識遵循這些指令模式的請求，並對以下檔案執行對應操作：
- `LeetCodePractice/Problems/<ProblemName>.cs`
- `LeetCodePractice.Tests/<ProblemName>Tests.cs`

## 資源
- 題目清單追蹤：`resources/problem-list.md`（每次新增/移除/重新命名後更新）
- 專案結構參考：`references/project-structure.md`
- 自動化腳本：`scripts/`

## 範圍
- 僅限本地工作區技能。
- 非全域 GitHub Copilot 技能安裝。
- 僅供在此儲存庫內使用。
