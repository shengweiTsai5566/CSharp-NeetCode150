# Subsets II

## 解題思路

與 Subsets（LC 78）類似，但輸入陣列包含重複元素，需要避免產生重複的子集合。

**關鍵技巧：先排序，跳過重複元素。**

**步驟：**
1. 先將 `nums` 排序，讓相同數字相鄰。
2. 使用回溯法，定義 `Backtrack(start, current)`。
3. 每進入一層遞迴，先將 `current` 加入結果集。
4. 從 `start` 開始遍歷：
   - 若 `i > start` 且 `nums[i] == nums[i - 1]`，則跳過（避免在同一層產生重複子集合）
   - 將 `nums[i]` 加入 `current`
   - 遞迴處理 `i + 1`
   - 回溯

**為什麼跳過條件是 `i > start`？**
因為在同一層遞迴中，若當前元素與前一個相同，則選取它會產生與前一次相同的子集合；但在不同層遞迴中（即已經選取了某個元素後），相同的數字是可以被選取的（如 `[1, 2, 2]` 中的兩個 2）。

## 時間複雜度

- **時間**: O(n × 2ⁿ) — 最壞情況下（無重複）與 Subsets 相同
- **空間**: O(n) — 遞迴深度最多為 n

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class SubsetsII
{
    public IList<IList<int>> Solve(int[] nums)
    {
        Array.Sort(nums);
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
            if (i > start && nums[i] == nums[i - 1]) continue;
            current.Add(nums[i]);
            Backtrack(nums, i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}
```
