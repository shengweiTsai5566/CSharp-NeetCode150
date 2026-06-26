# Contains Duplicate

## 解題思路
使用 HashSet 儲存已遍歷過的元素。遍歷陣列時，若當前元素已存在於 HashSet 中，則表示有重複，回傳 true；否則將元素加入 HashSet。若遍歷完整個陣列都沒有找到重複，則回傳 false。

## 時間複雜度
- **時間**: O(n) — 只需遍歷一次陣列
- **空間**: O(n) — 需要一個 HashSet 儲存最多 n 個不同元素

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class ContainsDuplicate
{
    public bool Solve(int[] nums)
    {
        var set = new HashSet<int>();

        foreach (int num in nums)
        {
            if (set.Contains(num))
                return true;
            set.Add(num);
        }

        return false;
    }
}
```
