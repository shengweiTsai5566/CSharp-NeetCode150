# Coin Change

## 解題思路

給定不同面額的硬幣和一個總金額，找出能湊成該金額所需的最少硬幣數量。這是一道經典的**完全背包（Unbounded Knapsack）動態規劃**問題。

**關鍵思考：**
- 定義 `dp[i]` 表示湊成金額 `i` 所需的最少硬幣數量。
- 初始化 `dp[0] = 0`（湊成金額 0 不需要任何硬幣），其餘 `dp[i] = amount + 1`（一個大於可能最大值的數，表示無法湊出）。
- 對於每個金額 `i`，遍歷所有硬幣面額 `coin`：
  - 若 `coin <= i`，則 `dp[i] = min(dp[i], dp[i - coin] + 1)`。
- 最終若 `dp[amount] > amount`，表示無法湊出，回傳 `-1`。

**步驟：**
1. 建立長度為 `amount + 1` 的 DP 陣列，初始化為 `amount + 1`。
2. 設定 `dp[0] = 0`。
3. 遍歷金額 `i` 從 1 到 `amount`：
   - 對每個硬幣面額 `coin`，若 `coin <= i`，嘗試更新 `dp[i]`。
4. 回傳 `dp[amount] > amount ? -1 : dp[amount]`。

## 時間複雜度

- **時間**: O(amount × coins.length) — 雙層迴圈
- **空間**: O(amount) — 一維 DP 陣列

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class CoinChange
{
    public int Solve(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (coin <= i)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        return dp[amount] > amount ? -1 : dp[amount];
    }
}
```
