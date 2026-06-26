# LeetCode Problems

> 此檔案由 `lc: list` 自動產生，記錄本工作區所有 LeetCode 題目，依分類排列。
> 最後更新：2026-06-26

## 總覽

| # | Source | Category | Problem | LeetCode | 實作檔 | 測試檔 | Status |
|---|--------|----------|---------|----------|--------|--------|:------:|
| 1 | LeetCode Variant | String / State Machine | CommandParser | LC 65 / LC 8 | [`CommandParser.cs`](LeetCodePractice/Problems/CommandParser.cs) | [`CommandParserTests.cs`](LeetCodePractice.Tests/CommandParserTests.cs) | ✅ |
| 2 | LeetCode | Design / LRU Cache | DeviceParameterCache | LC 146 | [`DeviceParameterCache.cs`](LeetCodePractice/Problems/DeviceParameterCache.cs) | [`DeviceParameterCacheTests.cs`](LeetCodePractice.Tests/DeviceParameterCacheTests.cs) | ✅ |
| 3 | NeetCode 150 | Array / Hash Table | TwoSum | LC 1 | [`TwoSum.cs`](LeetCodePractice/Problems/TwoSum.cs) | [`TwoSumTests.cs`](LeetCodePractice.Tests/TwoSumTests.cs) | ✅ |
| 4 | LeetCode Variant | Array / Interval | WaferScanOptimizer | LC 56 / LC 57 | [`WaferScanOptimizer.cs`](LeetCodePractice/Problems/WaferScanOptimizer.cs) | [`WaferScanOptimizerTests.cs`](LeetCodePractice.Tests/WaferScanOptimizerTests.cs) | ✅ |

---

## 依分類瀏覽

### Array / Hash Table

#### TwoSum
**LC 1 Two Sum（NeetCode 150）**

Given an array of integers `nums` and an integer `target`，return indices of the two numbers such that they add up to `target`。
假設每個輸入都有恰好一個解，且不能使用相同元素兩次。

- [實作檔](LeetCodePractice/Problems/TwoSum.cs)
- [測試檔](LeetCodePractice.Tests/TwoSumTests.cs)

---

### Array / Interval

#### WaferScanOptimizer
**LC 56 Merge Intervals / LC 57 Insert Interval 延伸變形**

晶圓缺陷區域掃描範圍合併。在光學檢測（AOI）設備中，將重疊或連續的曝光區間進行合併，
避免電子束（E-beam）複檢時重複掃描。需考慮記憶體優化（Zero-allocation 意識）。

- [實作檔](LeetCodePractice/Problems/WaferScanOptimizer.cs)
- [測試檔](LeetCodePractice.Tests/WaferScanOptimizerTests.cs)

---

### Design / LRU Cache

#### DeviceParameterCache
**LC 146 LRU Cache**

高效能設備參數 LRU 快取機制。實作 `Get(int key)` 和 `Put(int key, int value)`。
當快取達到容量上限時，應在寫入新資料前，汰換最久未使用（Least Recently Used）的資料。
**Senior 重點**：使用 Array-based Doubly Linked List 或 Object Pool 避免 GC 壓力。

- [實作檔](LeetCodePractice/Problems/DeviceParameterCache.cs)
- [測試檔](LeetCodePractice.Tests/DeviceParameterCacheTests.cs)

---

### String / State Machine

#### CommandParser
**LC 65 Valid Number / LC 8 String to Integer (atoi) 延伸變形**

通訊協定封包狀態解析器。機台與上位機（MES）或下位機（PLC）透過 TCP/IP 傳輸自訂的控制指令。
封包格式要求：以 `$` 開頭，接著 4 位指令碼（僅限大寫英文字母），可選的參數區（由 `,` 分隔的數字），最後以 `;` 結尾。
任何非法格式都必須立刻觸發錯誤狀態。

- [實作檔](LeetCodePractice/Problems/CommandParser.cs)
- [測試檔](LeetCodePractice.Tests/CommandParserTests.cs)
