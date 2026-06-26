# Combination Sum II

## 解題思路

與 Combination Sum（LC 39）類似，但每個數字最多只能使用一次，且 candidates 可能包含重複數字，需要避免產生重複組合。

**關鍵技巧：先排序，跳過同層重複元素，遞迴時傳入 `i + 1`。**

**步驟：**
1. 先將 `candidates` 排序。
2. 定義遞迴函式 `Backtrack(start, target, current)`：
   - `start`：當前可選擇的起始索引（每個元素只能用一次，所以傳入 `i + 1`）
   - `target`：剩餘目標值
3. 終止條件：
   - `target == 0`：找到一組解
   - `target < 0`：剪枝返回
4. 從 `start` 開始遍歷：
   - 若 `i > start` 且 `candidates[i] == candidates[i - 1]`，跳過（避免同層重複）
   - 將 `candidates[i]` 加入 `current`
   - 遞迴呼叫 `Backtrack(i + 1, target - candidates[i], current)`
   - 回溯

**與 Combination Sum 的差異：**
- 遞迴時傳入 `i + 1` 而非 `i`（每個元素只能用一次）
- 需要先排序並跳過同層重複元素

## 時間複雜度

- **時間**: O(2ⁿ) — 最壞情況下需要探索所有子集
- **空間**: O(n) — 遞迴深度最多為 n

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class CombinationSumII
{
    public IList<IList<int>> Solve(int[] candidates, int target)
    {
        Array.Sort(candidates);
        var result = new List<IList<int>>();
        var current = new List<int>();
        Backtrack(candidates, target, 0, current, result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, int start,
                           List<int> current, List<IList<int>> result)
    {
        if (target < 0) return;
        if (target == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (i > start && candidates[i] == candidates[i - 1]) continue;
            current.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
```
