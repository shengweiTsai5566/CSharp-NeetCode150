# Reconstruct Itinerary

## 解題思路
使用 Hierholzer 演算法（後序 DFS）來找出歐拉路徑（Eulerian Path）。由於題目保證至少有一條有效路徑且必須從 "JFK" 出發，我們先將機票建立成鄰接表（adjacency list），並使用 `SortedSet` 或 `MinHeap`（PriorityQueue）來維護目的地的最小字典序。DFS 時，從當前機場取出字典序最小的目的地繼續遞迴，當所有邊都走完後將當前節點加入結果列表，最後反轉即為答案。

## 時間複雜度
- **時間**: O(E log E) — E 為機票數量，每個目的地排序需 O(log E)
- **空間**: O(V + E) — V 為機場數量，E 為機票數量

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class ReconstructItinerary
{
    public IList<string> Solve(IList<IList<string>> tickets)
    {
        var graph = new Dictionary<string, List<string>>();
        foreach (var ticket in tickets)
        {
            if (!graph.ContainsKey(ticket[0]))
                graph[ticket[0]] = new List<string>();
            graph[ticket[0]].Add(ticket[1]);
        }

        foreach (var key in graph.Keys)
            graph[key].Sort();

        var result = new List<string>();
        Dfs("JFK", graph, result);
        result.Reverse();
        return result;
    }

    private void Dfs(string airport, Dictionary<string, List<string>> graph, List<string> result)
    {
        if (graph.ContainsKey(airport))
        {
            var destinations = graph[airport];
            while (destinations.Count > 0)
            {
                var next = destinations[0];
                destinations.RemoveAt(0);
                Dfs(next, graph, result);
            }
        }
        result.Add(airport);
    }
}
```
