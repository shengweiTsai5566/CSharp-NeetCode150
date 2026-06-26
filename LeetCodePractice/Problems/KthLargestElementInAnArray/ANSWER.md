# Kth Largest Element in an Array

**LeetCode：** [215. Kth Largest Element in an Array](https://leetcode.com/problems/kth-largest-element-in-an-array/) (Medium)

**NeetCode 150：** 第 62 題

---

## 解題思路

給定一個整數陣列，找出第 K 大的元素（注意是排序後的第 K 大，不是第 K 個不重複元素）。

### 解法一：Min-Heap（最小堆積）

- 建立一個大小為 K 的 Min-Heap。
- 遍歷陣列，將元素加入堆積。
- 若堆積大小超過 K，彈出最小的元素（堆頂）。
- 最後堆積頂端就是第 K 大的元素。

### 解法二：QuickSelect（快速選擇）

- 類似 QuickSort 的 Partition 策略。
- 每次 Partition 後，pivot 會落在其最終排序位置。
- 若 pivot 位置等於 `k-1`（0-indexed），則找到答案。
- 若 pivot 位置小於 `k-1`，往右半邊搜尋；否則往左半邊。

### 時間/空間複雜度

- **Heap 解法：** O(N log K)，空間 O(K)。
- **QuickSelect 解法：** 平均 O(N)，最差 O(N²)，空間 O(1)。

---

## 完整 C# 解答（Min-Heap 解法）

```csharp
using System.Collections.Generic;

public class KthLargestElementInAnArray
{
    public int Solve(int[] nums, int k)
    {
        var minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}
```

---

## 完整 C# 解答（QuickSelect 解法）

```csharp
using System;

public class KthLargestQuickSelect
{
    public int Solve(int[] nums, int k)
    {
        int left = 0, right = nums.Length - 1;
        int targetIndex = nums.Length - k; // 第 K 大 = 第 (N-K) 小（0-indexed）

        while (left <= right)
        {
            int pivotIndex = Partition(nums, left, right);

            if (pivotIndex == targetIndex)
                return nums[pivotIndex];
            else if (pivotIndex < targetIndex)
                left = pivotIndex + 1;
            else
                right = pivotIndex - 1;
        }

        return -1;
    }

    private int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];
        int i = left;

        for (int j = left; j < right; j++)
        {
            if (nums[j] <= pivot)
            {
                Swap(nums, i, j);
                i++;
            }
        }
        Swap(nums, i, right);
        return i;
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
```

---

## 補充說明

- 題目要求「不排序（without sorting）」，Heap 和 QuickSelect 均符合條件。
- 若要處理**第 K 大**，在 QuickSelect 中轉換成找第 **(N - K) 小** 更方便。
- QuickSelect 在極端情況（已排序陣列 + 每次選最後一個當 pivot）會退化成 O(N²)，可透過隨機選 pivot 來規避。
