# Longest Increasing Subsequence

## 解題思路

給定一個整數陣列，找出最長嚴格遞增子序列的長度。此處提供兩種解法：

### 解法一：DP（O(n²)）
- 定義 `dp[i]` 表示以 `nums[i]` 結尾的最長遞增子序列長度。
- 初始化所有 `dp[i] = 1`（至少包含自身）。
- 對於每個 `i`，遍歷所有 `j < i`，若 `nums[j] < nums[i]`，則 `dp[i] = max(dp[i], dp[j] + 1)`。

### 解法二：Patience Sorting + Binary Search（O(n log n)）
- 維護一個陣列 `tails`，其中 `tails[i]` 表示長度為 `i+1` 的遞增子序列的最小結尾元素。
- 對於每個 `num`，使用二分搜尋找到它在 `tails` 中的位置：
  - 若 `num` 大於 `tails` 中所有元素，則追加到末尾。
  - 否則，取代第一個大於等於 `num` 的元素。
- 最終 `tails` 的長度即為 LIS 長度。
- ⚠️ `tails` 中的序列**不一定是真正的 LIS**，但長度正確。

## 時間複雜度

- **時間**: O(n log n) — 二分搜尋優化（解法二）
- **空間**: O(n) — tails 陣列

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class LongestIncreasingSubsequence
{
    public int Solve(int[] nums)
    {
        int[] tails = new int[nums.Length];
        int size = 0;

        foreach (int num in nums)
        {
            int left = 0, right = size;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (tails[mid] < num)
                    left = mid + 1;
                else
                    right = mid;
            }
            tails[left] = num;
            if (left == size)
                size++;
        }

        return size;
    }
}
```
