# Edit Distance

## 解題思路

使用 **2D DP** 計算將 `word1` 轉換為 `word2` 所需的最小操作次數（插入、刪除、替換），即經典的 **Levenshtein Distance**。

定義 `dp[i][j]` 表示將 `word1[0..i-1]` 轉換為 `word2[0..j-1]` 的最小編輯距離。

**轉移方程式**：
- 若 `word1[i-1] == word2[j-1]`：`dp[i][j] = dp[i-1][j-1]`（字元相同，無需操作）
- 若不相同：`dp[i][j] = 1 + min(dp[i-1][j]（刪除）, dp[i][j-1]（插入）, dp[i-1][j-1]（替換）)`

**邊界條件**：
- `dp[i][0] = i`（將 word1[0..i-1] 轉為空字串需要 i 次刪除）
- `dp[0][j] = j`（將空字串轉為 word2[0..j-1] 需要 j 次插入）

**優化**：可壓縮為 1D DP，只保留上一列的結果。

## 時間複雜度

- **時間**: O(m × n) — m = word1.Length, n = word2.Length
- **空間**: O(n) — 可優化為 1D DP

## 程式碼

```csharp
public class EditDistance
{
    public int Solve(string word1, string word2)
    {
        int m = word1.Length, n = word2.Length;
        int[] dp = new int[n + 1];

        for (int j = 0; j <= n; j++)
            dp[j] = j;

        for (int i = 1; i <= m; i++)
        {
            int prev = dp[0];
            dp[0] = i;
            for (int j = 1; j <= n; j++)
            {
                int temp = dp[j];
                if (word1[i - 1] == word2[j - 1])
                {
                    dp[j] = prev;
                }
                else
                {
                    dp[j] = 1 + Math.Min(prev, Math.Min(dp[j], dp[j - 1]));
                }
                prev = temp;
            }
        }

        return dp[n];
    }
}
```
