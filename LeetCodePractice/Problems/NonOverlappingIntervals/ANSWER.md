# Non-overlapping Intervals

## 解題思路
使用 **Greedy（貪心）** 策略，先按區間的**終點**排序。選擇最早結束的區間可以為後續區間留下最大空間。

遍歷排序後的區間，維護上一個被選取區間的終點 `end`。若當前區間起點 ≥ `end`，則不重疊，更新 `end` 為當前區間終點；否則表示重疊，需要移除（計數加一）。

等價於：計算最多能保留多少個不重疊區間（活動選擇問題），再用總數減去該值即為最少移除數。

## 時間/空間複雜度
- **時間複雜度**：O(n log n) — 排序花費
- **空間複雜度**：O(1) — 除排序外只使用常數空間（若排序使用 in-place）

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class NonOverlappingIntervals
{
    public int Solve(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;

        Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));

        int count = 0;
        int end = intervals[0][1];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] >= end)
            {
                end = intervals[i][1];
            }
            else
            {
                count++;
            }
        }

        return count;
    }
}
```
