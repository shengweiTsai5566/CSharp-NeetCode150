# Permutations

## 解題思路
使用回溯法（Backtracking）。維護一個暫存當前排列的列表與一個標記已使用元素的布林陣列。每次遞迴時，依序嘗試將未使用的數字加入當前排列，並繼續遞迴，直到當前排列的長度等於 nums 的長度時，將結果加入答案列表。

## 時間複雜度
- **時間**: O(n × n!) — 共有 n! 種排列，每種需要 O(n) 時間複製
- **空間**: O(n) — 遞迴深度最多為 n，不含輸出空間

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class Permutations
{
    public IList<IList<int>> Solve(int[] nums)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();
        var used = new bool[nums.Length];
        Backtrack(nums, used, current, result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] used, List<int> current, List<IList<int>> result)
    {
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;

            used[i] = true;
            current.Add(nums[i]);
            Backtrack(nums, used, current, result);
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
```
