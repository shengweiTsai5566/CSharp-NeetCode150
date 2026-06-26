# DoNetLeetCodePractice

> 一個 .NET C# LeetCode 刷題練習環境，搭配 VS Code Copilot Skill 自動化管理。
> 專為**軟體工程師面試**設計，題目涵蓋製程控制、硬體抽象化、通訊協定等實務場景。

> ✅ **NeetCode 150 完整收錄** — 全數 149+ 題目已加入專案，每題皆含 `ANSWER.md` 解題思路 + C# 實作 + xUnit 測試。

---

## 🎯 這個專案對刷題有什麼幫助？

### ✅ 省去繁瑣設定，專注解題本身
- **使用leetcode-helper scaffold新增題目**：輸入 `lc: scaffold TwoSum` 自動建立題目檔案 + 測試 + ANSWER.md，不用手動新增專案、測試專案、namespace
- **leetcode-helper測試解答**：`dotnet test --filter TwoSum` 直接驗證該題解答，不用開 IDE 慢慢找測試位置
- **集中管理**：149+ 題目統一放在 `Problems/` 下，結構一致，不用在檔案系統裡翻來翻去

### ✅ 每題附完整解題筆記，學得深、記得牢
- 每題都有 **`ANSWER.md`**，包含：思路推導、時間/空間複雜度分析、多種解法比較、C# 完整實作
- 解題思路直接用中文或英文寫在題目旁邊，複習時一目瞭然
- 支援 `lc: list` 快速瀏覽所有題目

### ✅ 系統化分類，按主題循序漸進
- 完整 **NeetCode 150** 題庫，按 Array、Stack、Tree、Graph、DP 等主題分類
- 自訂面試相關題目（WaferScanOptimizer、CommandParser 等），貼近面試場景

### ✅ 真實 C# 專案結構，面試無縫接軌
- 使用最新 **.NET 9.0**、**xUnit**、**file-scoped namespace**，與業界實務開發一致
- 共用資料型別（`ListNode`、`TreeNode`、`Node`）集中管理，減少重複程式碼
- `dotnet build` 0 錯誤，隨時保持可編譯狀態

### ✅ AI 輔助學習，事半功倍
- **Copilot Skill 自動化**：用 `lc: scaffold` 一鍵開新題、`lc: list` 瀏覽進度、`lc: remove` 清理，瑣事交給 AI
- **Copilot Chat 即時答疑**：卡關時直接問「Explain this solution」、「What's the time complexity?」、「How to optimize?」，不用跳出編輯器
- **AI 生成面試準備清單**：貼上 JD 職缺描述，讓 Copilot 幫你對應到專案中的題目，自動產出 `Interview-Prep-List.md`
- **解答比對與優化**：寫完後可請 Copilot Review 程式碼，檢查邊界條件、建議更優解法或說明複雜度

> 💡 **學習建議**：先嘗試自己寫一遍 → 遇到卡關再看 `ANSWER.md` 提示 → 寫完後跑測試確認 → 隔天複習時只看思路重新實作。這個專案就是圍繞這個流程設計的。

---

## ✨ 專案特色

| 特色 | 說明 |
|------|------|
| 🧩 **149+ LeetCode 題目** | 完整 NeetCode 150 清單 + 半導體設備 custom 題 |
| 📂 **問題資料夾管理** | 每個題目獨立資料夾，包含 `.cs` + `ANSWER.md` |
| 🧪 **xUnit 測試** | 每題都有對應測試檔，支援 `dotnet test` |
| 🧠 **解題思路** | 每個 `ANSWER.md` 含完整思路、複雜度分析、C# 解答 |
| 🤖 **Copilot Skill** | 用 `lc:` 短指令快速 scaffold / remove / rename / list |
| 🔍 **面試準備清單** | `Interview-Prep-List.md` 依職缺需求分類整理 |

---

## 🚀 快速開始

### 必要條件
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- VS Code + C# Dev Kit + GitHub Copilot

### 安裝與執行測試

```powershell
cd <repository-root>
dotnet test
```

### 瀏覽題目

執行 `lc: list` 或直接開啟根目錄的 [`LeetCodeProblems.md`](LeetCodeProblems.md) 查看所有題目。

---

## 📂 專案結構

```
DoNetLeetterCodePractice/
├── LeetCodePractice/                     # 主專案
│   └── Problems/                         # 所有題目
│       ├── ListNode.cs                   # 共用資料型別
│       ├── TreeNode.cs
│       ├── Node.cs
│       ├── TwoSum/                       # 每個題目獨立資料夾
│       │   ├── TwoSum.cs                 #   實作檔
│       │   └── ANSWER.md                 #   解題思路 + 解答
│       ├── AddTwoNumbers/
│       ├── WaferScanOptimizer/
│       ├── CommandDispatcher/            # E-beam 面試 custom 題
│       └── ...（149+ 資料夾）
├── LeetCodePractice.Tests/               # xUnit 測試專案
│   ├── TwoSum/
│   │   └── TwoSumTests.cs
│   └── ...（對應每個題目）
├── .agents/skills/leetcode-helper/       # Copilot Skill
│   ├── SKILL.md
│   ├── prompt.md
│   ├── resources/problem-list.md         # 題目清單
│   ├── references/                       # 參考文件
│   └── scripts/                          # 自動化腳本
├── LeetCodeProblems.md                   # 自動產生的題目總覽
├── Interview-Prep-List.md                # 面試準備清單
├── copilot-instructions.md               # Copilot 指示
└── README.md
```

---

## 🤖 使用 Copilot Skill（`lc:` 指令）

本專案內建 VS Code Copilot Skill，支援下列短指令：

### 新增題目（Scaffold）

```powershell
lc: scaffold TwoSum
lc: scaffold new problem MergeIntervals
```

Skill 會：
1. 在 `Problems/<Name>/` 建立 `.cs` 骨架檔
2. 在 `Tests/<Name>/` 建立 xUnit 測試檔
3. 詢問**分類標籤**（如 Array, String, Tree, DP 等）
4. 詢問**來源**（LeetCode / LeetCode Variant / NeetCode 150 / Custom）
5. 更新題目清單

### 移除題目

```powershell
lc: remove WaferScanOptimizer
lc: delete problem TwoSum
```

Skill 會確認後刪除實作檔與測試檔，並執行 `dotnet test` 驗證。

### 重新命名題目

```powershell
lc: rename TwoSum to TwoSumV2
```

Skill 會重新命名檔案並更新內部的 class 名稱。

### 列出所有題目

```powershell
lc: list
lc: list problems
```

Skill 會掃描所有題目，讀取 XML 註解中的描述，然後在根目錄**產生 `LeetCodeProblems.md`** 總覽檔。

> 💡 **提示**：在 VS Code 中按 `Ctrl+Shift+I` 開啟 Quick Chat，直接輸入 `lc: list` 即可，不用打開對話面板。

---

## 🧪 測試

每個題目都有對應的 xUnit 測試檔，放在 `LeetCodePractice.Tests/<ProblemName>/` 資料夾中。

### 執行所有測試

```powershell
dotnet test
```

### 執行單一題目的測試

使用 `--filter` 參數指定測試類別名稱：

```powershell
# 只跑 TwoSum 的測試
dotnet test --filter TwoSumTests

# 只跑 WaferScanOptimizer 的測試
dotnet test --filter WaferScanOptimizerTests

# 使用萬用字元：只跑某個分類的測試
dotnet test --filter "FullyQualifiedName~TwoPointers"
```

或者在 VS Code 的測試總管（Testing Panel）中，直接點選單一測試執行。

### 測試涵蓋範圍

測試涵蓋：

```powershell
dotnet test
```

測試涵蓋：
- ✅ 正常情況（Happy Path）
- ✅ 邊界情況（Edge Cases）
- ✅ 無效輸入（Invalid Inputs）
- ✅ 壓力測試（Large Data）

---

## 🤖 使用 Copilot 協助解題與評斷

### 評斷你的解答是否正確

寫完解法後，在 VS Code 中選取你的程式碼，然後在 Copilot Chat 中輸入：

```
幫我 Review 這個解法是否正確，並指出可能的 bug 或效能問題。
```

Copilot 會：
- 分析你的演算法邏輯
- 指出潛在的邊界條件遺漏（如 null 輸入、空陣列等）
- 建議時間/空間複雜度的優化方向
- 檢查程式碼風格與 C# 慣例

### 針對單一測試失敗求助

如果 `dotnet test` 出現失敗，將錯誤訊息貼給 Copilot：

```
這個測試失敗了，幫我看看為什麼：
[貼上錯誤訊息]
```

或者直接問：

```
TwoSumTests 中的 Solve_Example1 測試失敗，請問我該如何修正？
```

### 完全不知從何下手

如果你看到題目完全沒有頭緒，可以逐步尋求 Copilot 幫助：

**① 先讓 Copilot 解釋題目：**

```
我看不懂這題在問什麼，幫我用白話解釋一下 LC 200 Number of Islands
```

**② 請 Copilot 提示方向，不要直接給答案：**

```
不要給我解答，只要提示我這題可以用什麼資料結構或演算法就好
```

**③ 請 Copilot 引導你一步步思考：**

```
用蘇格拉底提問法，一步步引導我解出這題。每次只問我一個問題，
等我回答後再繼續下一步。
```

**④ 請 Copilot 視覺化解題過程：**

```
用 ASCII 圖或流程圖畫出這題的演算法執行過程
```

**⑤ 最後才看 ANSWER.md 驗證：**

當你寫出解答後，再打開資料夾中的 `ANSWER.md` 比對。

### 理解題目與提示

當你對題目沒有頭緒時，可以直接問：

```
解釋一下 LC 200 Number of Islands 的解題思路
```

```
這題可以用 BFS 或 DFS，哪個在 C# 中比較適合？為什麼？
```

### 比較你的解答與 ANSWER.md

當你完成實作後，打開對應的 `ANSWER.md`，選取你的程式碼與 ANSWER.md 中的解答，然後問：

```
比較這兩種解法，說出各自的優缺點與適用場景
```

### 模擬面試

你可以請 Copilot 模擬面試官：

```
扮演半導體設備商的面試官，問我關於執行緒安全的問題，
並根據我的回答給予回饋。
```

---

## 📋 從職缺描述（JD）產生面試準備清單

你可以將收到的面試邀請或職缺描述貼給 Copilot，讓 SKILL 自動分析並產生對應的 LeetCode 練習清單。

### 使用方式

將職缺描述的完整內容貼給 Copilot，然後說：

```
這是我收到的面試通知，請幫我從題庫中找出最相關的題目，
在專案目錄下產出一份 LIST 清單。
```

### SKILL 會自動做三件事

| 步驟 | 說明 |
|:----:|------|
| 1️⃣ 分析 JD | 辨識關鍵技術需求（如 C#、製程控制、通訊協定、設計模式等） |
| 2️⃣ 比對題庫 | 從 149+ 題中篩選出最相關的題目，按優先級分類 |
| 3️⃣ 產生清單 | 在根目錄建立一份 `Interview-Prep-List.md`，包含閱讀順序建議 |

### 實際範例

你只需要貼上職缺內容後說：

```
這是我要面試的職缺，幫我整理一份 LeetCode 練習清單
```

Copilot 就會像我們先前做的那樣，產出一份完整的準備清單，包含：

- 🔴 **第一優先**：直接對應 JD 核心技能的題目
- 🟠 **第二優先**：輔助技能相關題目
- 🟡 **第三優先**：軟體設計與架構題目
- 🟢 **第四優先**：測試與效能優化題目
- 📊 **閱讀順序建議**：四週複習計畫

> 💡 **提示**：你也可以只貼部分關鍵技能，例如「我要面試半導體設備商，強調 C# 和製程控制」，SKILL 就會只針對這些主題產出清單。

## 📖 每個題目資料夾的內容

```
TwoSum/
├── TwoSum.cs         # 問題實作骨架（TODO 等待你完成）
└── ANSWER.md         # 🔥 完整解題思路與解答
```

`ANSWER.md` 包含：
1. **解題思路**（繁體中文步驟說明）
2. **時間/空間複雜度**分析
3. **完整 C# 解答程式碼**（可直接參考）

> 💡 先自己嘗試實作，卡住時再參考 `ANSWER.md`！


---

## 🛠 自動化腳本

位於 `.agents/skills/leetcode-helper/scripts/`：

| 腳本 | 說明 |
|------|------|
| `batch-scaffold-neetcode150.ps1` | 批次建立 NeetCode 150 所有題目模板 |
| `fetch-and-update-descriptions.ps1` | 從 LeetCode API 抓取題目描述並更新 |
| `fix-nested-summary.ps1` | 修復巢狀 summary 問題 |
| `reorganize-to-folders.ps1` | 將題目重新組織到各別資料夾 |

---

## 📋 題目來源

| 來源 | 說明 | 數量 |
|------|------|:----:|
| **NeetCode 150** | LeetCode 精選 150 題 | ~145 |
| **LeetCode** | 原題 | ~2 |
| **LeetCode Variant** | 延伸變形（半導體情境） | ~2 |
| **Custom** | 自訂面試題 | ~2 |

---

## 📝 授權與貢獻

- 僅供個人學習與面試準備使用。
- 想貢獻？請參考 [`CONTRIBUTING.md`](CONTRIBUTING.md)
- 英文版：[`README.en.md`](README.en.md)
