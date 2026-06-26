# Kth Largest Element in a Stream

**LeetCode：** [703. Kth Largest Element in a Stream](https://leetcode.com/problems/kth-largest-element-in-a-stream/) (Easy)

**NeetCode 150：** 第 59 題

---

## 解題思路

設計一個類別，在串流資料中不斷加入新數字，並能隨時回傳第 K 大的元素。

### 核心概念：Min-Heap（最小堆積）

維護一個大小為 K 的 **最小堆積（Min-Heap）**：
- 堆積頂端永遠是目前第 K 大的元素（也就是堆積中最小的那個）。
- 每當加入新數字時：
  1. 將數字加入堆積。
  2. 若堆積大小超過 K，彈出最小的元素（確保堆積中只保留最大的 K 個數字）。
  3. 回傳堆積頂端（即第 K 大元素）。

### 舉例說明

假設 `k = 3`，初始陣列 `[4, 5, 8, 2]`：

- 加入 `4` → 堆積 `[4]`（未滿 K）
- 加入 `5` → 堆積 `[4, 5]`（未滿 K）
- 加入 `8` → 堆積 `[4, 5, 8]`（滿 K）
- 加入 `2` → 堆積 `[4, 5, 8]`（`2` 比堆頂 `4` 小，被移除）→ 第 K 大 = `4`
- 加入 `3` → 堆積 `[4, 5, 8]`（`3` 比堆頂 `4` 小，被移除）→ 第 K 大 = `4`
- 加入 `5` → 堆積 `[5, 5, 8]`（`5` 加入後移除 `4`）→ 第 K 大 = `5`

### 時間/空間複雜度

- **時間複雜度：** O(N log K)（初始建堆）+ O(log K)（每次 Add）
- **空間複雜度：** O(K)

---

## 完整 C# 解答

```csharp
using System.Collections.Generic;

public class KthLargestElementInAStream
{
    private readonly int _k;
    private readonly PriorityQueue<int, int> _minHeap;

    public KthLargestElementInAStream(int k, int[] nums)
    {
        _k = k;
        _minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            _minHeap.Enqueue(num, num);
            if (_minHeap.Count > _k)
            {
                _minHeap.Dequeue();
            }
        }
    }

    public int Add(int val)
    {
        _minHeap.Enqueue(val, val);
        if (_minHeap.Count > _k)
        {
            _minHeap.Dequeue();
        }
        return _minHeap.Peek();
    }
}
```

> **注意：** 在 `Add` 方法中，即使堆積尚未滿 K 個，`Peek()` 仍然會回傳堆頂的最小值，也就是目前第 K 大的元素。

---

## 替代方案

若 K 很大或串流資料很多，也可以考慮使用 **有序集合（SortedSet）** 搭配雙指標，但 PriorityQueue 是此題最簡潔高效的解法。
