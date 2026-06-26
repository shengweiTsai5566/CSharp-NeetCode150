# 3Sum

## 解題思路

先將陣列排序，然後固定一個數字 `nums[i]`，再使用**雙指針**在剩餘的右側範圍內尋找兩個數字，使三者之和為 0，本質上是對每個位置執行一次 **Two Sum II**。

關鍵步驟：
1. **排序**陣列，方便跳過重複數字與使用雙指針。
2. 遍歷 `i` 從 0 到 `n-3`：
   - 若 `nums[i] > 0`，因為排序後右側都更大，和不可能為 0，直接 break。
   - 若 `nums[i] == nums[i-1]`，跳過重複以避免相同 triplets。
3. 對每個 `i`，用 `left = i + 1`、`right = n - 1` 尋找兩個數使和為 `-nums[i]`：
   - 找到時紀錄，並跳過左右指針的重複值。
   - 和小則左指針右移，和大則右指針左移。

## 時間複雜度

- **時間**: O(n²) — 排序 O(n log n) + 雙指針 O(n²)
- **空間**: O(1) 或 O(n) 取決於排序實作（不計輸出空間）

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class ThreeSum
{
    public IList<IList<int>> Solve(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // 排序後第一個數大於 0 就不可能和為 0
            if (nums[i] > 0) break;
            // 跳過重複的 nums[i]
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1, right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // 跳過重複的 nums[left] 和 nums[right]
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;

                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }
}
```
