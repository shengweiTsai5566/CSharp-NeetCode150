# House Robber II

## 解題思路
與 House Robber 類似，但房屋呈環形排列，第一間與最後一間相鄰。因此將問題拆成兩個子問題：不搶第一間（範圍 [1, n-1]）與不搶最後一間（範圍 [0, n-2]），兩者取最大值即可。每個子問題使用與 House Robber 相同的 DP 解法。

## 時間複雜度
- **時間**: O(n) — n 為房屋數量
- **空間**: O(1) — 只使用兩個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class HouseRobberII
{
    public int Solve(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int robFirst = RobRange(nums, 0, nums.Length - 2);
        int robLast = RobRange(nums, 1, nums.Length - 1);

        return Math.Max(robFirst, robLast);
    }

    private int RobRange(int[] nums, int start, int end)
    {
        int prev2 = 0;
        int prev1 = 0;

        for (int i = start; i <= end; i++)
        {
            int cur = Math.Max(prev1, nums[i] + prev2);
            prev2 = prev1;
            prev1 = cur;
        }

        return prev1;
    }
}
```
