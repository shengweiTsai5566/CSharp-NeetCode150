# Distinct Subsequences

## 解題思路

使用 **2D DP** 計算字串 `s` 中有多少個不同的子序列等於 `t`。

定義 `dp[i][j]` 表示 `s[0..i-1]` 中有多少個子序列等於 `t[0..j-1]`。

**轉移方程式**：
- 若 `s[i-1] == t[j-1]`：`dp[i][j] = dp[i-1][j-1]（選 s[i-1]）+ dp[i-1][j]（不選 s[i-1]）`
- 若 `s[i-1] != t[j-1]`：`dp[i][j] = dp[i-1][j]`（只能不選）

**邊界條件**：
- `dp[i][0] = 1`（空字串是任何字串的子序列）
- `dp[0][j] = 0` for j > 0（空字串無法產生非空子序列）

**優化**：可壓縮為 1D DP，從右向左更新以避免覆蓋。

## 時間複雜度

- **時間**: O(m × n) — m = s.Length, n = t.Length
- **空間**: O(n) — 可優化為 1D DP

## 程式碼

```csharp
public class DistinctSubsequences
{
    public int Solve(string s, string t)
    {
        int m = s.Length, n = t.Length;
        int[] dp = new int[n + 1];
        dp[0] = 1;

        for (int i = 1; i <= m; i++)
        {
            int prev = dp[0];
            for (int j = 1; j <= n; j++)
            {
                int temp = dp[j];
                if (s[i - 1] == t[j - 1])
                {
                    dp[j] = prev + dp[j];
                }
                prev = temp;
            }
        }

        return dp[n];
    }
}
```
