# Subsets

## 解題思路

使用回溯法（Backtracking）產生所有子集合。對於陣列中的每個元素，有兩種選擇：選取或不選取。

**步驟：**
1. 定義一個遞迴函式 `Backtrack(start, current)`，其中 `start` 表示當前可選擇的起始索引，`current` 為當前累積的子集合。
2. 每進入一層遞迴，先將 `current` 的副本加入結果集（表示一個子集合）。
3. 從 `start` 開始遍歷陣列，對於每個元素：
   - 將其加入 `current`
   - 遞迴處理下一個位置（`i + 1`）
   - 回溯：移除最後加入的元素

這樣可以產生所有 2ⁿ 個子集合，且不會重複（因為所有元素都是唯一的）。

## 時間複雜度

- **時間**: O(n × 2ⁿ) — 共有 2ⁿ 個子集合，每個需要 O(n) 時間複製
- **空間**: O(n) — 遞迴深度最多為 n，不含輸出空間

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class Subsets
{
    public IList<IList<int>> Solve(int[] nums)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();
        Backtrack(nums, 0, current, result);
        return result;
    }

    private void Backtrack(int[] nums, int start, List<int> current, List<IList<int>> result)
    {
        result.Add(new List<int>(current));

        for (int i = start; i < nums.Length; i++)
        {
            current.Add(nums[i]);
            Backtrack(nums, i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
```
