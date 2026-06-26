# Min Cost Climbing Stairs

## 解題思路
動態規劃 DP。定義 dp[i] 為爬到第 i 階的最小花費，由於可以從第 i-1 階跨 1 步或第 i-2 階跨 2 步到達，遞迴式為 dp[i] = cost[i] + min(dp[i-1], dp[i-2])。最後爬到頂樓（即超過最後一階）的最小花費為 min(dp[n-1], dp[n-2])。使用兩個變數滾動更新，空間可優化至 O(1)。

## 時間複雜度
- **時間**: O(n) — n 為 cost 陣列長度
- **空間**: O(1) — 只使用兩個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class MinCostClimbingStairs
{
    public int Solve(int[] cost)
    {
        int n = cost.Length;
        if (n == 2) return Math.Min(cost[0], cost[1]);

        int prev2 = cost[0];
        int prev1 = cost[1];

        for (int i = 2; i < n; i++)
        {
            int cur = cost[i] + Math.Min(prev1, prev2);
            prev2 = prev1;
            prev1 = cur;
        }

        return Math.Min(prev1, prev2);
    }
}
```
