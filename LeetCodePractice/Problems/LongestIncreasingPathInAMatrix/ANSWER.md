# Longest Increasing Path in a Matrix

## 解題思路

使用 **DFS + Memoization（記憶化搜尋）** 來解此題。

- 對矩陣中的每個 cell 進行 DFS，尋找從該 cell 開始的最長遞增路徑長度
- 使用 `memo[i][j]` 記錄已計算過的结果，避免重複計算
- 從每個 cell 往四個方向探索，只移動到值比當前 cell 大的相鄰 cell
- 路徑長度 = 1（目前 cell）+ 四個方向中最大的遞增路徑長度

**關鍵思維**：因為只能從較小值移動到較大值，所以不會有循環問題，天然形成一個 DAG（有向無環圖），非常適合用 DP + DFS 解決。

## 時間複雜度

- **時間**: O(m × n) — 每個 cell 只會被計算一次
- **空間**: O(m × n) — memo 陣列與遞迴呼叫棧

## 程式碼

```csharp
public class LongestIncreasingPathInAMatrix
{
    private readonly int[][] _dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];

    public int Solve(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int[][] memo = new int[m][];
        for (int i = 0; i < m; i++)
            memo[i] = new int[n];

        int result = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                result = Math.Max(result, Dfs(matrix, i, j, memo));
            }
        }

        return result;
    }

    private int Dfs(int[][] matrix, int i, int j, int[][] memo)
    {
        if (memo[i][j] != 0)
            return memo[i][j];

        int maxLen = 1;
        foreach (var dir in _dirs)
        {
            int ni = i + dir[0], nj = j + dir[1];
            if (ni >= 0 && ni < matrix.Length &&
                nj >= 0 && nj < matrix[0].Length &&
                matrix[ni][nj] > matrix[i][j])
            {
                maxLen = Math.Max(maxLen, 1 + Dfs(matrix, ni, nj, memo));
            }
        }

        memo[i][j] = maxLen;
        return maxLen;
    }
}
```
