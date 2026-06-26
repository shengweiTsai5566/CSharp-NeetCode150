# Combination Sum

## 解題思路

使用回溯法（Backtracking）找出所有總和等於 target 的組合。與 Subsets 類似，但允許重複選取相同的數字。

**步驟：**
1. 定義遞迴函式 `Backtrack(start, target, current)`：
   - `start`：當前可選擇的起始索引（允許重複，所以遞迴時傳入 `i` 而非 `i + 1`）
   - `target`：剩餘需要湊足的目標值
   - `current`：當前累積的組合
2. 終止條件：
   - 若 `target == 0`：找到一組解，將 `current` 加入結果
   - 若 `target < 0`：超出目標，直接返回（剪枝）
3. 從 `start` 開始遍歷 candidates：
   - 將 `candidates[i]` 加入 `current`
   - 遞迴呼叫 `Backtrack(i, target - candidates[i], current)`
   - 回溯：移除最後加入的元素

由於 candidates 都是正整數，當 target 小於 0 時可以提前終止。

## 時間複雜度

- **時間**: O(N^(T/M + 1)) — N 為 candidates 長度，T 為 target，M 為最小值；實際複雜度取決於組合數量
- **空間**: O(T/M) — 遞迴深度最多為 target / min(candidates)

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class CombinationSum
{
    public IList<IList<int>> Solve(int[] candidates, int target)
    {
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
            current.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
```
