# Swim in Rising Water

## 解題思路
使用 Dijkstra 風格的最小堆（PriorityQueue）演算法，或 Union-Find 搭配時間二分搜尋。本解法採用最小堆：從 (0, 0) 開始，每次從堆中取出當前可到達且海拔最低的格子，並更新經過路徑上的最大海拔值（即所需時間）。抵達 (n-1, n-1) 時回傳該最大值。由於水位隨時間 t 上升，我們要找的是能從左上到右下的最小 t，而堆演算法保證我們總是優先探索低海拔的路徑。

## 時間複雜度
- **時間**: O(n² log n) — n 為網格邊長
- **空間**: O(n²) — 訪問陣列與堆空間

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class SwimInRisingWater
{
    public int Solve(int[][] grid)
    {
        int n = grid.Length;
        var visited = new bool[n, n];
        int[] dirs = { 0, 1, 0, -1, 0 };

        var pq = new PriorityQueue<(int, int, int), int>();
        pq.Enqueue((0, 0, grid[0][0]), grid[0][0]);

        while (pq.Count > 0)
        {
            var (r, c, maxVal) = pq.Dequeue();
            if (visited[r, c]) continue;
            visited[r, c] = true;

            if (r == n - 1 && c == n - 1)
                return maxVal;

            for (int d = 0; d < 4; d++)
            {
                int nr = r + dirs[d];
                int nc = c + dirs[d + 1];
                if (nr < 0 || nr >= n || nc < 0 || nc >= n || visited[nr, nc])
                    continue;
                int newMax = Math.Max(maxVal, grid[nr][nc]);
                pq.Enqueue((nr, nc, newMax), newMax);
            }
        }

        return -1;
    }
}
```
