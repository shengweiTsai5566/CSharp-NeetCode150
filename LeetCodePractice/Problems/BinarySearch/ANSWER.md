# Binary Search

## 解題思路
經典的二元搜尋法（Binary Search）。因為 `nums` 已是升序排列，定義兩個指標：

- `left = 0`，`right = nums.Length - 1`。
- 每次取中間索引 `mid = left + (right - left) / 2`（避免溢位）。
- 如果 `nums[mid] == target`，直接回傳 `mid`。
- 如果 `nums[mid] < target`，表示目標在右半邊，將 `left` 更新為 `mid + 1`。
- 如果 `nums[mid] > target`，表示目標在左半邊，將 `right` 更新為 `mid - 1`。
- 若 `left > right` 時仍找不到，則回傳 `-1`。

## 時間複雜度
- **時間**: O(log n) — 每次迭代將搜尋範圍縮小一半
- **空間**: O(1) — 只需幾個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class BinarySearch
{
    public int Solve(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
                return mid;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}
```
