# Median of Two Sorted Arrays

## 解題思路
這題要求在兩個已排序陣列中找出中位數，時間複雜度需為 O(log(m+n))。最經典的解法是**二分搜尋分割點（Binary Search Partition）**。

核心概念：
1. 確保 `nums1` 是較短的陣列（若不是則交換），以減少二分搜尋範圍
2. 對 `nums1` 做二分搜尋，決定一個分割點 `partition1`
3. `partition2 = (m + n + 1) / 2 - partition1`（確保左半邊元素數量 >= 右半邊）
4. 檢查分割是否正確：`maxLeft1 <= minRight2` 且 `maxLeft2 <= minRight1`
   - 若成立，則找到正確分割點，根據總長度奇偶計算中位數
   - 若 `maxLeft1 > minRight2`，則 partition1 需左移
   - 若 `maxLeft2 > minRight1`，則 partition1 需右移

分割正確時：
- 總長度為奇數：中位數 = `max(maxLeft1, maxLeft2)`
- 總長度為偶數：中位數 = `(max(maxLeft1, maxLeft2) + min(minRight1, minRight2)) / 2`

## 時間/空間複雜度
- **時間**: O(log(min(m, n)))
- **空間**: O(1)

## 程式碼

```csharp
public class MedianOfTwoSortedArrays
{
    public double Solve(int[] nums1, int[] nums2)
    {
        // 確保 nums1 是較短的陣列
        if (nums1.Length > nums2.Length)
            return Solve(nums2, nums1);

        int m = nums1.Length, n = nums2.Length;
        int left = 0, right = m;

        while (left <= right)
        {
            int partition1 = left + (right - left) / 2;
            int partition2 = (m + n + 1) / 2 - partition1;

            int maxLeft1 = partition1 == 0 ? int.MinValue : nums1[partition1 - 1];
            int minRight1 = partition1 == m ? int.MaxValue : nums1[partition1];
            int maxLeft2 = partition2 == 0 ? int.MinValue : nums2[partition2 - 1];
            int minRight2 = partition2 == n ? int.MaxValue : nums2[partition2];

            if (maxLeft1 <= minRight2 && maxLeft2 <= minRight1)
            {
                if ((m + n) % 2 == 0)
                    return (Math.Max(maxLeft1, maxLeft2) + Math.Min(minRight1, minRight2)) / 2.0;
                else
                    return Math.Max(maxLeft1, maxLeft2);
            }
            else if (maxLeft1 > minRight2)
            {
                right = partition1 - 1;
            }
            else
            {
                left = partition1 + 1;
            }
        }

        throw new ArgumentException("Input arrays are not sorted.");
    }
}
```
