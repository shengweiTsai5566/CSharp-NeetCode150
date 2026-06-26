# Maximum Product Subarray

## 解題思路

給定一個整數陣列，找出乘積最大的連續子陣列。由於負數的存在，最大值可能來自兩個負數相乘（負負得正），因此需要同時追蹤**當前最大值**和**當前最小值**。

**關鍵思考：**
- 遍歷陣列時，對於每個元素 `nums[i]`：
  - 當前最大乘積 `curMax` 可能來自：`curMax * nums[i]`、`curMin * nums[i]`（兩個負數相乘）或 `nums[i]` 本身。
  - 當前最小乘積 `curMin` 同理，需要考慮負數相乘的可能。
- 使用 `Math.Max` 和 `Math.Min` 來更新這兩個值。
- 用全域變數 `result` 記錄過程中出現的最大值。

**步驟：**
1. 初始化 `result = nums[0]`、`curMax = nums[0]`、`curMin = nums[0]`。
2. 從 `i = 1` 開始遍歷：
   - 暫存 `curMax` 舊值，避免被覆蓋。
   - 更新 `curMax = Max(nums[i], curMax * nums[i], curMin * nums[i])`。
   - 更新 `curMin = Min(nums[i], temp * nums[i], curMin * nums[i])`。
   - 更新 `result = Max(result, curMax)`。
3. 回傳 `result`。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class MaximumProductSubarray
{
    public int Solve(int[] nums)
    {
        int result = nums[0];
        int curMax = nums[0];
        int curMin = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            int temp = curMax;
            curMax = Math.Max(nums[i], Math.Max(curMax * nums[i], curMin * nums[i]));
            curMin = Math.Min(nums[i], Math.Min(temp * nums[i], curMin * nums[i]));
            result = Math.Max(result, curMax);
        }

        return result;
    }
}
```
