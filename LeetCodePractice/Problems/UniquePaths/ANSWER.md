# Unique Paths

## 解題思路

機器人位於 `m x n` 網格的左上角，每次只能向右或向下移動，求到達右下角的不同路徑數量。這是一道經典的**二維動態規劃**問題。

**關鍵思考：**
- 定義 `dp[i][j]` 表示到達位置 `(i, j)` 的不同路徑數量。
- 遞迴關係：`dp[i][j] = dp[i-1][j] + dp[i][j-1]`（從上方來 + 從左方來）。
- 第一行和第一列的所有位置都只有一種路徑可達（只能一直向右或一直向下），因此初始化為 1。
- 可以將二維 DP 壓縮為一維：`dp[j] += dp[j-1]`。

**步驟：**
1. 建立長度為 `n` 的一維陣列 `dp`，初始化所有元素為 1（對應第一行只有一種走法）。
2. 外層迴圈遍歷行數（從第 1 行到第 m-1 行）：
   - 內層迴圈遍歷 `j` 從 1 到 `n-1`：
     - `dp[j] += dp[j-1]`。
3. 回傳 `dp[n-1]`。

## 時間複雜度

- **時間**: O(m × n) — 雙層迴圈
- **空間**: O(n) — 一維 DP 陣列

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class UniquePaths
{
    public int Solve(int m, int n)
    {
        int[] dp = new int[n];
        Array.Fill(dp, 1);

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[n - 1];
    }
}
```
