# Meeting Rooms II

## 解題思路
給定一系列會議時間區間 `intervals[i] = [start, end]`，求最少需要多少間會議室才能容納所有會議。

使用**最小堆（Min-Heap）**來追蹤正在進行的會議的結束時間：
1. 先將所有區間依照開始時間排序。
2. 遍歷每個會議，將當前會議的開始時間與堆頂（最早結束的會議）比較：
   - 若當前會議開始時間 >= 堆頂結束時間，表示有空出的會議室，彈出堆頂。
   - 將當前會議的結束時間加入堆中。
3. 最終堆的大小即為所需的最少會議室數量。

這個方法等價於掃描線（Sweep Line）的概念，每當一個會議開始就 +1，結束就 -1，取過程中的最大值。

## 時間複雜度
- **時間**: O(n log n) — 排序需要 O(n log n)，每個會議進出堆各一次 O(log n)
- **空間**: O(n) — 堆中最多同時有 n 個會議

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MeetingRoomsII
{
    public int Solve(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;

        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        var minHeap = new PriorityQueue<int, int>();

        foreach (var interval in intervals)
        {
            int start = interval[0];
            int end = interval[1];

            if (minHeap.Count > 0 && minHeap.Peek() <= start)
            {
                minHeap.Dequeue();
            }

            minHeap.Enqueue(end, end);
        }

        return minHeap.Count;
    }
}
```
