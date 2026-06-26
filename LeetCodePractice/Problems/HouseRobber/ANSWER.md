# House Robber

## 解題思路
動態規劃 DP。由於相鄰房屋不能同時搶劫，對於第 i 間房屋有兩種選擇：搶（則 i-1 不能搶）或不搶（則 i-1 可搶）。因此 dp[i] = max(dp[i-1], nums[i] + dp[i-2])。使用兩個變數滾動更新，空間可優化至 O(1)。

## 時間複雜度
- **時間**: O(n) — n 為房屋數量
- **空間**: O(1) — 只使用兩個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class HouseRobber
{
    public int Solve(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int prev2 = nums[0];
        int prev1 = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            int cur = Math.Max(prev1, nums[i] + prev2);
            prev2 = prev1;
            prev1 = cur;
        }

        return prev1;
    }
}
```
