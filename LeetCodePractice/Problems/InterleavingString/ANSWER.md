# Interleaving String

## 解題思路

使用 **2D DP** 判斷字串 `s3` 是否由 `s1` 和 `s2` 交錯組成。

定義 `dp[i][j]` 表示 `s1[0..i-1]` 和 `s2[0..j-1]` 是否能交錯組成 `s3[0..i+j-1]`。

**轉移方程式**：
- `dp[i][j] = (dp[i-1][j] && s1[i-1] == s3[i+j-1]) || (dp[i][j-1] && s2[j-1] == s3[i+j-1])`

**邊界條件**：
- `dp[0][0] = true`（空字串可組成空字串）
- 初始化第一行與第一列，分別對應只使用 `s1` 或只使用 `s2` 的情況

**優化**：可壓縮為 1D DP，只保留上一列的結果，達到 `O(s2.length)` 空間複雜度。

## 時間複雜度

- **時間**: O(m × n) — m = s1.Length, n = s2.Length
- **空間**: O(n) — 可優化為 1D DP

## 程式碼

```csharp
public class InterleavingString
{
    public bool Solve(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
            return false;

        bool[] dp = new bool[s2.Length + 1];

        for (int i = 0; i <= s1.Length; i++)
        {
            for (int j = 0; j <= s2.Length; j++)
            {
                if (i == 0 && j == 0)
                {
                    dp[j] = true;
                }
                else if (i == 0)
                {
                    dp[j] = dp[j - 1] && s2[j - 1] == s3[i + j - 1];
                }
                else if (j == 0)
                {
                    dp[j] = dp[j] && s1[i - 1] == s3[i + j - 1];
                }
                else
                {
                    dp[j] = (dp[j] && s1[i - 1] == s3[i + j - 1]) ||
                            (dp[j - 1] && s2[j - 1] == s3[i + j - 1]);
                }
            }
        }

        return dp[s2.Length];
    }
}
```
