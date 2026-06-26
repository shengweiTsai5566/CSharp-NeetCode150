# Find Median from Data Stream

**LeetCode：** [295. Find Median from Data Stream](https://leetcode.com/problems/find-median-from-data-stream/) (Hard)

**NeetCode 150：** 第 64 題

---

## 解題思路

設計一個資料結構，支援動態加入整數，並能隨時取得所有數字的中位數。

### 核心概念：雙堆積（Two Heaps）

使用 **兩個堆積** 來維護資料流：
- **Max-Heap（左半邊）**：存放較小的一半數字，堆頂是這半邊的最大值。
- **Min-Heap（右半邊）**：存放較大的一半數字，堆頂是這半邊的最小值。

這樣中位數就永遠是兩個堆頂的平均值（偶數個）或 Max-Heap 的堆頂（奇數個）。

### 維護規則

1. 新數字加入時，先加入 Max-Heap。
2. 若 Max-Heap 的堆頂 > Min-Heap 的堆頂，將 Max-Heap 堆頂移到 Min-Heap。
3. 平衡兩邊大小：Max-Heap 最多比 Min-Heap 多一個，否則將 Max-Heap 堆頂移到 Min-Heap；若 Min-Heap 比 Max-Heap 多，則將 Min-Heap 堆頂移到 Max-Heap。

### 中位數計算

- 若兩邊大小相同：`(maxHeap.Peek() + minHeap.Peek()) / 2.0`
- 若 Max-Heap 較多：`maxHeap.Peek()`

### 時間/空間複雜度

- **時間複雜度：** O(log N) per Add，O(1) per FindMedian
- **空間複雜度：** O(N)

---

## 完整 C# 解答

```csharp
using System.Collections.Generic;

public class FindMedianFromDataStream
{
    // Max-Heap（存放較小的一半），使用負值模擬
    private readonly PriorityQueue<int, int> _maxHeap;
    // Min-Heap（存放較大的一半）
    private readonly PriorityQueue<int, int> _minHeap;

    public FindMedianFromDataStream()
    {
        _maxHeap = new PriorityQueue<int, int>();
        _minHeap = new PriorityQueue<int, int>();
    }

    public void AddNum(int num)
    {
        // 1. 先加入 Max-Heap
        _maxHeap.Enqueue(num, -num);

        // 2. 確保 Max-Heap 的所有元素 <= Min-Heap 的所有元素
        if (_maxHeap.Count > 0 && _minHeap.Count > 0 &&
            _maxHeap.Peek() > _minHeap.Peek())
        {
            int val = _maxHeap.Dequeue();
            _minHeap.Enqueue(val, val);
        }

        // 3. 平衡大小：Max-Heap 最多比 Min-Heap 多 1 個
        if (_maxHeap.Count > _minHeap.Count + 1)
        {
            int val = _maxHeap.Dequeue();
            _minHeap.Enqueue(val, val);
        }
        else if (_minHeap.Count > _maxHeap.Count)
        {
            int val = _minHeap.Dequeue();
            _maxHeap.Enqueue(val, -val);
        }
    }

    public double FindMedian()
    {
        if (_maxHeap.Count == _minHeap.Count)
        {
            // 偶數個：取兩堆頂的平均值
            return (_maxHeap.Peek() + _minHeap.Peek()) / 2.0;
        }
        else
        {
            // 奇數個：Max-Heap 多一個，回傳 Max-Heap 堆頂
            return _maxHeap.Peek();
        }
    }
}
```

---

## Follow-Up 解答

### 1. 所有數字範圍在 [0, 100]

可使用 **Counting Sort（計數排序）**：
- 用長度 101 的陣列記錄每個數字出現次數。
- 維護元素總數，每次找中位數時遍歷計數陣列累計次數直到找到中位數位置。
- **時間：** O(101) = O(1) per FindMedian，O(1) per AddNum

### 2. 99% 數字範圍在 [0, 100]

可使用 **Counting Sort + 兩個 List**：
- 對 [0, 100] 內的數字使用計數陣列。
- 對超出範圍的數字用兩個 List 分別儲存極大值與極小值。
- 追蹤各區段的元素數量，中位數位置判斷落在哪個區段即可。

---

## 重點提醒

- 雙堆積法是資料流中位數的經典解法，必須熟練掌握。
- C# 的 `PriorityQueue<TElement, TPriority>` 預設是 Min-Heap，Max-Heap 需透過負值或自訂比較器。
- 注意 `FindMedian` 回傳值型別是 `double`，偶數個時需要除以 `2.0`。
