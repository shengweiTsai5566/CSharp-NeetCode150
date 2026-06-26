# Burst Balloons

## 解題思路

這是一道經典的**區間 DP（Divide and Conquer DP）**問題。

關鍵思維：**反過來思考**——不要想先戳破哪個氣球，而是想最後戳破哪個氣球。最後戳破的氣球，其左右邊界是固定的（一開始是 `1` 和 `1`），然後遞迴處理左右兩側的子區間。

為了方便處理邊界，在原陣列前後各加上一個 `1`，得到新陣列 `nums`（長度為 `n + 2`）。

定義 `dp[i][j]` 為戳破區間 `(i, j)`（不包含 i 和 j）內所有氣球能獲得的最大金幣數。

**轉移方程式**（假設 k 是在區間 (i, j) 中最後戳破的氣球）：
```
dp[i][j] = max(dp[i][j], nums[i] * nums[k] * nums[j] + dp[i][k] + dp[k][j])
```

最後答案為 `dp[0][n+1]`。

## 時間複雜度

- **時間**: O(n³) — 三層迴圈：區間長度、起點、最後戳破的氣球位置
- **空間**: O(n²) — DP 表格

## 程式碼

```csharp
public class BurstBalloons
{
    public int Solve(int[] nums)
    {
        int n = nums.Length;
        int[] padded = new int[n + 2];
        padded[0] = padded[n + 1] = 1;
        for (int i = 0; i < n; i++)
            padded[i + 1] = nums[i];

        int[,] dp = new int[n + 2, n + 2];

        for (int len = 2; len <= n + 1; len++)
        {
            for (int i = 0; i + len <= n + 1; i++)
            {
                int j = i + len;
                for (int k = i + 1; k < j; k++)
                {
                    dp[i, j] = Math.Max(dp[i, j],
                        padded[i] * padded[k] * padded[j] + dp[i, k] + dp[k, j]);
                }
            }
        }

        return dp[0, n + 1];
    }
}
```
