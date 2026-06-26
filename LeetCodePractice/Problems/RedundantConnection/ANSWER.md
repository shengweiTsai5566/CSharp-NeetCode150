# Redundant Connection

## 解題思路
使用 **Union-Find（並查集）** 來檢測圖中第一個形成環的邊。

1. 初始化一個大小為 `n + 1` 的並查集（節點從 1 到 n）。
2. 依序遍歷每條邊 `[u, v]`：
   - 如果 `u` 和 `v` 已經屬於同一個集合（即 `Find(u) == Find(v)`），表示加入這條邊會形成環，這條邊即為答案。
   - 否則，將 `u` 和 `v` 所屬的集合合併（`Union(u, v)`）。
3. 回傳最後一條導致形成環的邊（題目保證有解）。

Union-Find 搭配路徑壓縮（Path Compression）和按秩合併（Union by Rank）可以達到接近常數的時間複雜度。

## 時間複雜度
- **時間**: O(n × α(n)) — α(n) 為阿克曼反函數，近似常數
- **空間**: O(n) — 需要 parent 和 rank 陣列

## 程式碼

```csharp
public class RedundantConnection
{
    public int[] Solve(int[][] edges)
    {
        int n = edges.Length;
        var parent = new int[n + 1];
        var rank = new int[n + 1];

        for (int i = 1; i <= n; i++)
            parent[i] = i;

        foreach (var edge in edges)
        {
            int u = edge[0], v = edge[1];
            if (Find(parent, u) == Find(parent, v))
                return edge;
            Union(parent, rank, u, v);
        }

        return new int[0];
    }

    private int Find(int[] parent, int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent, parent[x]); // 路徑壓縮
        return parent[x];
    }

    private void Union(int[] parent, int[] rank, int x, int y)
    {
        int px = Find(parent, x), py = Find(parent, y);
        if (px == py) return;

        if (rank[px] < rank[py])
            parent[px] = py;
        else if (rank[px] > rank[py])
            parent[py] = px;
        else
        {
            parent[py] = px;
            rank[px]++;
        }
    }
}
```
