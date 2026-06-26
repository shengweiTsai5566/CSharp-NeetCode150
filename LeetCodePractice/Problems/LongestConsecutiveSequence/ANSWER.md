# Longest Consecutive Sequence

## 解題思路
使用 HashSet 儲存所有數字以達到 O(1) 查詢。遍歷每個數字，若該數字的前一個數（num - 1）不存在於集合中，表示它是連續序列的起點。從起點開始向後查找（num + 1、num + 2...），計算當前連續序列的長度，並更新最長長度。

## 時間複雜度
- **時間**: O(n) — 每個元素最多被訪問兩次（一次判斷起點，一次向後延伸）
- **空間**: O(n) — 需要一個 HashSet 儲存所有數字

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class LongestConsecutiveSequence
{
    public int Solve(int[] nums)
    {
        var set = new HashSet<int>(nums);
        int longest = 0;

        foreach (int num in set)
        {
            // 只有當 num 是連續序列的起點時才開始計算
            if (!set.Contains(num - 1))
            {
                int current = num;
                int length = 1;

                while (set.Contains(current + 1))
                {
                    current++;
                    length++;
                }

                longest = Math.Max(longest, length);
            }
        }

        return longest;
    }
}
```
