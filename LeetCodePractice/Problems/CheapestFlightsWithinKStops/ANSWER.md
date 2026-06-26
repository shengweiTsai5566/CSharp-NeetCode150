# Cheapest Flights Within K Stops

## 解題思路
使用 Bellman-Ford 演算法的變體（或 Dijkstra 搭配步數限制）。因為有最多 k 站中轉的限制（即最多 k+1 條邊），我們可以進行 k+1 次鬆弛操作。每次迭代時，基於上一次的距離陣列來更新當前可到達的價格，避免在同一次迭代中重複使用同一條邊（防止超出步數限制）。若最終 dst 的距離仍為無限大，則回傳 -1。

## 時間複雜度
- **時間**: O(k × E) — k 為最大中轉次數，E 為航班數量
- **空間**: O(n) — 距離陣列

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class CheapestFlightsWithinKStops
{
    public int Solve(int n, int[][] flights, int src, int dst, int k)
    {
        int[] dist = new int[n];
        Array.Fill(dist, int.MaxValue);
        dist[src] = 0;

        for (int i = 0; i <= k; i++)
        {
            int[] next = new int[n];
            Array.Copy(dist, next, n);

            foreach (var flight in flights)
            {
                int from = flight[0], to = flight[1], price = flight[2];
                if (dist[from] != int.MaxValue && dist[from] + price < next[to])
                    next[to] = dist[from] + price;
            }

            dist = next;
        }

        return dist[dst] == int.MaxValue ? -1 : dist[dst];
    }
}
```
