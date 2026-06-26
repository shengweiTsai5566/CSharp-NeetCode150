# Minimum Interval to Include Each Query

## 解題思路
給定一組區間 `intervals` 和一組查詢點 `queries`，對每個查詢點找出能包含它的最小區間長度（若無則回傳 -1）。

核心思路是**離線查詢（Offline Query）搭配最小堆**：
1. 將區間依照**大小**排序（從小到大）。
2. 將查詢點依照數值排序，並記錄原始索引以便輸出。
3. 遍歷每個查詢點（小到大），將所有「左邊界 <= 當前查詢點」的區間加入最小堆（以右邊界為排序鍵）。
4. 彈出堆中所有「右邊界 < 當前查詢點」的區間（已不包含該點）。
5. 若堆不為空，堆頂即為包含當前查詢點的最小區間（因為是依照區間大小加入的，堆頂即為最小長度）。

## 時間複雜度
- **時間**: O((n + m) log n) — 排序區間和查詢各需 O(n log n + m log m)，每個區間和查詢進出堆各一次 O(log n)
- **空間**: O(n + m) — 儲存區間、查詢結果與堆

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MinimumIntervalToIncludeEachQuery
{
    public int[] Solve(int[][] intervals, int[] queries)
    {
        int n = intervals.Length;
        int m = queries.Length;

        // 將區間依照大小 (right - left + 1) 排序
        Array.Sort(intervals, (a, b) =>
            (a[1] - a[0] + 1).CompareTo(b[1] - b[0] + 1));

        // 將查詢點與原始索引配對，並依數值排序
        var sortedQueries = new (int val, int idx)[m];
        for (int i = 0; i < m; i++)
            sortedQueries[i] = (queries[i], i);
        Array.Sort(sortedQueries, (a, b) => a.val.CompareTo(b.val));

        var result = new int[m];
        // 預設為 -1（找不到包含的區間）
        Array.Fill(result, -1);

        // 最小堆：以右邊界為排序鍵，儲存 { 區間大小, 右邊界 }
        var minHeap = new PriorityQueue<(int size, int right), int>();
        int idx = 0;

        foreach (var (qVal, qIdx) in sortedQueries)
        {
            // 將所有左邊界 <= 當前查詢點的區間加入堆
            while (idx < n && intervals[idx][0] <= qVal)
            {
                int size = intervals[idx][1] - intervals[idx][0] + 1;
                int right = intervals[idx][1];
                minHeap.Enqueue((size, right), size);
                idx++;
            }

            // 移除所有右邊界 < 當前查詢點的區間
            while (minHeap.Count > 0 && minHeap.Peek().right < qVal)
            {
                minHeap.Dequeue();
            }

            if (minHeap.Count > 0)
            {
                result[qIdx] = minHeap.Peek().size;
            }
        }

        return result;
    }
}
```
