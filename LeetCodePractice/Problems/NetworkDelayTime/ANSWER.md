# Network Delay Time

## 解題思路
使用 Dijkstra 最短路徑演算法。建立鄰接表後，從起始節點 k 出發，用最小堆（PriorityQueue）依序取出當前最短距離的節點，更新其鄰居的距離。當所有可到達的節點都被訪問過後，檢查是否所有 n 個節點都已收到信號。如果是，回傳最遠節點的距離；否則回傳 -1。

## 時間複雜度
- **時間**: O(E log V) — E 為邊的數量，V 為節點數量
- **空間**: O(V + E) — 鄰接表與距離陣列

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class NetworkDelayTime
{
    public int Solve(int[][] times, int n, int k)
    {
        var graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new List<(int, int)>();

        foreach (var t in times)
            graph[t[0]].Add((t[1], t[2]));

        var dist = new int[n + 1];
        Array.Fill(dist, int.MaxValue);
        dist[k] = 0;

        var pq = new PriorityQueue<int, int>();
        pq.Enqueue(k, 0);

        while (pq.Count > 0)
        {
            var u = pq.Dequeue();
            foreach (var (v, w) in graph[u])
            {
                if (dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }

        int maxDist = 0;
        for (int i = 1; i <= n; i++)
        {
            if (dist[i] == int.MaxValue) return -1;
            if (dist[i] > maxDist) maxDist = dist[i];
        }

        return maxDist;
    }
}
```
