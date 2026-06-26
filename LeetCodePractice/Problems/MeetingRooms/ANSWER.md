# Meeting Rooms

## 解題思路
使用 **排序 + Greedy** 策略。先將所有區間按開始時間排序，然後遍歷檢查是否有重疊。若相鄰兩個區間中，前一個的結束時間 > 後一個的開始時間，則表示有衝突，無法參加所有會議。

等價於檢查排序後的區間是否有任何重疊。

## 時間/空間複雜度
- **時間複雜度**：O(n log n) — 排序花費
- **空間複雜度**：O(1) — 除排序外只使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class MeetingRooms
{
    public bool Solve(int[][] intervals)
    {
        if (intervals.Length == 0) return true;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i - 1][1] > intervals[i][0])
                return false;
        }

        return true;
    }
}
```
