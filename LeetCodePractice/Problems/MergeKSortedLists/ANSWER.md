# Merge k Sorted Lists

## 解題思路
使用 **最小堆積（Min-Heap / Priority Queue）** 來有效率地合併 k 個已排序鏈結串列：

1. 將每個鏈結串列的头節點加入最小堆積（依節點值排序）。
2. 每次從堆積中取出最小值節點，接到結果串列的尾部。
3. 若該節點有 next 節點，則將其 next 加入堆積。
4. 重複直到堆積為空。

使用 dummy head 簡化邊界處理。此方法每次只需比較 k 個头節點，而非逐一比較所有節點。

## 時間複雜度
- **時間**: O(n log k) — n 為所有節點總數，k 為鏈結串列數量，每次堆積操作 O(log k)
- **空間**: O(k) — 最小堆積最多存放 k 個節點

## 程式碼

```csharp
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MergeKSortedLists
{
    public ListNode Solve(ListNode[] lists)
    {
        var minHeap = new PriorityQueue<ListNode, int>();

        foreach (var node in lists)
        {
            if (node != null)
                minHeap.Enqueue(node, node.val);
        }

        var dummy = new ListNode(0);
        var curr = dummy;

        while (minHeap.Count > 0)
        {
            var node = minHeap.Dequeue();
            curr.next = node;
            curr = curr.next;

            if (node.next != null)
                minHeap.Enqueue(node.next, node.next.val);
        }

        return dummy.next;
    }
}
```
