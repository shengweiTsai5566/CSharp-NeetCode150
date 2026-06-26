# Longest Common Subsequence

## 解題思路

給定兩個字串，找出它們的最長公共子序列（LCS）的長度。子序列不要求連續，但必須保持相對順序。這是一道經典的**二維動態規劃**問題。

**關鍵思考：**
- 定義 `dp[i][j]` 表示 `text1[0..i-1]` 和 `text2[0..j-1]` 的最長公共子序列長度。
- 遞迴關係：
  - 若 `text1[i-1] == text2[j-1]`，則 `dp[i][j] = dp[i-1][j-1] + 1`（找到一個匹配字元）。
  - 若不相同，則 `dp[i][j] = max(dp[i-1][j], dp[i][j-1])`（取兩者中較長的 LCS）。
- 初始條件：`dp[0][j] = 0`、`dp[i][0] = 0`（任一空字串的 LCS 長度為 0）。
- 可以將二維 DP 壓縮為一維（使用 `prev` 變數記錄左上角值）。

**步驟：**
1. 取得兩個字串的長度 `m` 和 `n`。
2. 建立長度為 `n + 1` 的一維陣列 `dp`。
3. 雙層迴圈遍歷兩個字串：
   - 用 `prev` 記錄 `dp[j-1]` 的舊值（即左上角的值）。
   - 若字元相同，`dp[j] = prev + 1`。
   - 若不同，`dp[j] = Math.Max(dp[j], dp[j-1])`。
4. 回傳 `dp[n]`。

## 時間複雜度

- **時間**: O(m × n) — 雙層迴圈
- **空間**: O(min(m, n)) — 可優化為一維陣列

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class LongestCommonSubsequence
{
    public int Solve(string text1, string text2)
    {
        int m = text1.Length, n = text2.Length;
        int[] dp = new int[n + 1];

        for (int i = 1; i <= m; i++)
        {
            int prev = 0;
            for (int j = 1; j <= n; j++)
            {
                int temp = dp[j];
                if (text1[i - 1] == text2[j - 1])
                    dp[j] = prev + 1;
                else
                    dp[j] = Math.Max(dp[j], dp[j - 1]);
                prev = temp;
            }
        }

        return dp[n];
    }
}
```
