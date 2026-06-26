# Merge Intervals

## 解題思路
使用 **排序 + 貪心合併**。先將區間按起點排序，然後遍歷所有區間。若當前區間的起點 ≤ 上一個合併區間的終點，表示重疊，更新終點為兩者較大值；否則，將上一個合併區間加入結果，並開始新的合併區間。

排序是關鍵步驟，確保合併過程只需一次線性掃描。

## 時間/空間複雜度
- **時間複雜度**：O(n log n) — 排序花費 O(n log n)，合併花費 O(n)
- **空間複雜度**：O(n) — 儲存結果陣列（若排序不使用額外空間則可視為 O(log n)）

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MergeIntervals
{
    public int[][] Solve(int[][] intervals)
    {
        if (intervals.Length == 0) return Array.Empty<int[]>();

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var result = new List<int[]>();
        int[] current = intervals[0];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= current[1])
            {
                current[1] = Math.Max(current[1], intervals[i][1]);
            }
            else
            {
                result.Add(current);
                current = intervals[i];
            }
        }

        result.Add(current);
        return result.ToArray();
    }
}
```
