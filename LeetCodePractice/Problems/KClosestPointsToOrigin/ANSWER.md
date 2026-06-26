# K Closest Points to Origin

**LeetCode：** [973. K Closest Points to Origin](https://leetcode.com/problems/k-closest-points-to-origin/) (Medium)

**NeetCode 150：** 第 61 題

---

## 解題思路

給定一組平面座標點，找出距離原點 `(0, 0)` 最近的 K 個點。

### 核心概念

歐幾里得距離公式：distance² = x² + y²（由於只需要比較大小，可以省略開根號以提升效能）。

### 解法一：Max-Heap（最大堆積）

- 建立一個大小為 K 的 **Max-Heap**。
- 遍歷所有點，將點加入堆積（以距離作為優先級）。
- 若堆積超過 K 個，彈出距離最遠的點（堆頂）。
- 最後堆積中留下的就是 K 個最近的點。

### 解法二：QuickSelect（快速選擇）

- 使用類似 QuickSort 的 Partition 方法。
- 平均時間 O(N)，最差 O(N²)。

### 時間/空間複雜度（Heap 解法）

- **時間複雜度：** O(N log K)，N 為總點數，K 為要求的最近點數。
- **空間複雜度：** O(K)，堆積最多存放 K 個點。

---

## 完整 C# 解答（Max-Heap 解法）

```csharp
using System.Collections.Generic;

public class KClosestPointsToOrigin
{
    public int[][] Solve(int[][] points, int k)
    {
        // Max-Heap：以距離作為優先級，取負值模擬 Max-Heap
        var maxHeap = new PriorityQueue<int[], double>();

        foreach (var point in points)
        {
            double dist = point[0] * point[0] + point[1] * point[1];
            maxHeap.Enqueue(point, -dist); // 負值讓最大距離在堆頂

            if (maxHeap.Count > k)
            {
                maxHeap.Dequeue(); // 彈出最遠的點
            }
        }

        var result = new int[k][];
        int i = 0;
        while (maxHeap.Count > 0)
        {
            result[i++] = maxHeap.Dequeue();
        }

        return result;
    }
}
```

---

## 完整 C# 解答（QuickSelect 解法）

```csharp
using System;

public class KClosestQuickSelect
{
    public int[][] Solve(int[][] points, int k)
    {
        int left = 0, right = points.Length - 1;

        while (left <= right)
        {
            int pivotIndex = Partition(points, left, right);
            if (pivotIndex == k)
                break;
            else if (pivotIndex < k)
                left = pivotIndex + 1;
            else
                right = pivotIndex - 1;
        }

        var result = new int[k][];
        Array.Copy(points, result, k);
        return result;
    }

    private int Partition(int[][] points, int left, int right)
    {
        int[] pivot = points[right];
        int pivotDist = pivot[0] * pivot[0] + pivot[1] * pivot[1];
        int i = left;

        for (int j = left; j < right; j++)
        {
            int dist = points[j][0] * points[j][0] + points[j][1] * points[j][1];
            if (dist <= pivotDist)
            {
                Swap(points, i, j);
                i++;
            }
        }
        Swap(points, i, right);
        return i;
    }

    private void Swap(int[][] points, int i, int j)
    {
        var temp = points[i];
        points[i] = points[j];
        points[j] = temp;
    }
}
```
