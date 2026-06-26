# Coin Change II

## 解題思路

這是一個典型的**無限背包（Unbounded Knapsack）**問題。目標是計算湊出指定金額的方法數，每種硬幣可以使用無限次。

使用 **1D DP 陣列**：定義 `dp[i]` 為湊出金額 `i` 的方法數。

- 初始化 `dp[0] = 1`（湊出金額 0 只有一種方法：不使用任何硬幣）
- 外層迴圈遍歷每種硬幣，內層迴圈從該硬幣面額到 `amount`，更新 `dp[j] += dp[j - coin]`
- 外層先遍歷硬幣（而不是先遍歷金額），這樣確保每種組合只被計算一次（組合數而非排列數）

**關鍵思維**：先遍歷硬幣再遍歷金額，確保每種組合是唯一的（不同順序視為同一種組合）。

## 時間複雜度

- **時間**: O(n × amount) — n 為硬幣種類數，amount 為目標金額
- **空間**: O(amount) — 使用 1D DP 陣列

## 程式碼

```csharp
public class CoinChangeII
{
    public int Solve(int amount, int[] coins)
    {
        int[] dp = new int[amount + 1];
        dp[0] = 1;

        foreach (int coin in coins)
        {
            for (int j = coin; j <= amount; j++)
            {
                dp[j] += dp[j - coin];
            }
        }

        return dp[amount];
    }
}
```
