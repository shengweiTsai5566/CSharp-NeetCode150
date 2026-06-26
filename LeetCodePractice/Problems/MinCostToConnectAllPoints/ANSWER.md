# Min Cost to Connect All Points

## 解題思路
使用 Prim 演算法求最小生成樹（MST）。從任意一點開始，用最小堆（PriorityQueue）維護已訪問集合到未訪問點的最小曼哈頓距離。每次取出距離最小的點加入 MST，並更新其鄰近點到 MST 的距離，直到所有點都加入為止。由於 n ≤ 1000，O(n²) 也能接受，但使用堆優化可達 O(n² log n)。

## 時間複雜度
- **時間**: O(n² log n) — n 為點的數量
- **空間**: O(n) — 用於記錄訪問狀態與最小距離

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MinCostToConnectAllPoints
{
    public int Solve(int[][] points)
    {
        int n = points.Length;
        var visited = new bool[n];
        var minDist = new int[n];
        Array.Fill(minDist, int.MaxValue);
        minDist[0] = 0;

        int result = 0;

        for (int i = 0; i < n; i++)
        {
            int u = -1;
            int min = int.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (!visited[j] && minDist[j] < min)
                {
                    min = minDist[j];
                    u = j;
                }
            }

            if (u == -1) break;
            visited[u] = true;
            result += min;

            for (int v = 0; v < n; v++)
            {
                if (!visited[v])
                {
                    int dist = Math.Abs(points[u][0] - points[v][0])
                             + Math.Abs(points[u][1] - points[v][1]);
                    if (dist < minDist[v])
                        minDist[v] = dist;
                }
            }
        }

        return result;
    }
}
```
