# Last Stone Weight

**LeetCode：** [1046. Last Stone Weight](https://leetcode.com/problems/last-stone-weight/) (Easy)

**NeetCode 150：** 第 60 題

---

## 解題思路

給定一組石頭重量，每次選取最重的兩顆撞擊，若重量相同兩顆都消失；若不同則保留差值（較重減較輕）。重複直到只剩一顆或零顆石頭。

### 核心概念：Max-Heap（最大堆積）

每次需要取出「最重」的兩顆石頭，這是典型的 **最大堆積（Max-Heap）** 應用場景。

C# 的 `PriorityQueue` 預設是 Min-Heap，我們可以透過 **權重取負值** 來模擬 Max-Heap。

### 演算法步驟

1. 將所有石頭重量加入 Max-Heap（實際存入負值或使用自訂比較器）。
2. 當堆積中還有超過 1 個元素時：
   - 取出最重的 `y`，再取出次重的 `x`（`x <= y`）。
   - 若 `x != y`，將 `y - x` 加回堆積。
3. 最後若堆積為空則回傳 `0`，否則回傳剩下的那顆石頭重量。

### 時間/空間複雜度

- **時間複雜度：** O(N log N)，N 為石頭數量。每次取出和插入都是 O(log N)，最多進行 N 次操作。
- **空間複雜度：** O(N)，堆積需要 N 個元素。

---

## 完整 C# 解答

```csharp
using System.Collections.Generic;

public class LastStoneWeight
{
    public int Solve(int[] stones)
    {
        // C# PriorityQueue 預設為 Min-Heap，使用負值模擬 Max-Heap
        var maxHeap = new PriorityQueue<int, int>();

        foreach (int stone in stones)
        {
            maxHeap.Enqueue(stone, -stone);
        }

        while (maxHeap.Count > 1)
        {
            int y = maxHeap.Dequeue(); // 最重的
            int x = maxHeap.Dequeue(); // 次重的

            if (x != y)
            {
                int diff = y - x;
                maxHeap.Enqueue(diff, -diff);
            }
        }

        return maxHeap.Count == 0 ? 0 : maxHeap.Peek();
    }
}
```

---

## 簡易版（使用排序 + List）

若不想用 Heap，也可用 List + 排序逐步模擬，但時間複雜度會退化到 O(N² log N)，不建議用於大量資料。

```csharp
public int SolveWithList(int[] stones)
{
    var list = new List<int>(stones);
    while (list.Count > 1)
    {
        list.Sort();
        int y = list[^1]; // 最大
        int x = list[^2]; // 次大
        list.RemoveAt(list.Count - 1);
        list.RemoveAt(list.Count - 1);
        if (x != y)
        {
            list.Add(y - x);
        }
    }
    return list.Count == 0 ? 0 : list[0];
}
```
