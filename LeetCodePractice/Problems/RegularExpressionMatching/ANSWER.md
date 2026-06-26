# Regular Expression Matching

## 解題思路

使用 **2D DP** 實現正則表達式匹配，支援 `'.'`（匹配任意單一字元）和 `'*'`（匹配零個或多個前一個字元）。

定義 `dp[i][j]` 表示 `s[0..i-1]` 是否與 `p[0..j-1]` 匹配。

**初始化**：
- `dp[0][0] = true`（空字串匹配空模式）
- 處理 `p` 開頭的 `x*` 模式：若 `p[j-1] == '*'`，則 `dp[0][j] = dp[0][j-2]`

**轉移方程式**：
1. 若 `p[j-1] == s[i-1]` 或 `p[j-1] == '.'`：`dp[i][j] = dp[i-1][j-1]`
2. 若 `p[j-1] == '*'`：
   - 匹配零次：`dp[i][j] = dp[i][j-2]`
   - 匹配一次或多次：若 `p[j-2] == s[i-1]` 或 `p[j-2] == '.'`，則 `dp[i][j] |= dp[i-1][j]`

## 時間複雜度

- **時間**: O(m × n) — m = s.Length, n = p.Length
- **空間**: O(m × n) — 可優化為 1D DP

## 程式碼

```csharp
public class RegularExpressionMatching
{
    public bool Solve(string s, string p)
    {
        int m = s.Length, n = p.Length;
        bool[,] dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;

        for (int j = 1; j <= n; j++)
        {
            if (p[j - 1] == '*')
                dp[0, j] = dp[0, j - 2];
        }

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == s[i - 1] || p[j - 1] == '.')
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else if (p[j - 1] == '*')
                {
                    dp[i, j] = dp[i, j - 2];
                    if (p[j - 2] == s[i - 1] || p[j - 2] == '.')
                    {
                        dp[i, j] |= dp[i - 1, j];
                    }
                }
            }
        }

        return dp[m, n];
    }
}
```
