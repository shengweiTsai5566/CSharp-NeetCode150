# Two Sum

## 解題思路
使用 Dictionary（哈希表）儲存已遍歷的元素與其索引。遍歷陣列時，計算 complement = target - nums[i]，若 complement 存在於字典中，即找到解答。此方法只需遍歷一次陣列。

## 時間複雜度
- **時間**: O(n) — 只需遍歷一次陣列
- **空間**: O(n) — 需要一個 Dictionary 儲存 n 個元素

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class TwoSum
{
    public int[] Solve(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.TryGetValue(complement, out int index))
            {
                return new[] { index, i };
            }

            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = i;
            }
        }

        return Array.Empty<int>();
    }
}
```
