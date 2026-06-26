# Surrounded Regions

## 解題思路
從邊界反向思考：任何與邊界相連的 `'O'` 都不會被 `'X'` 包圍，因此不會被取代。

1. 遍歷四條邊界上的所有細胞，對每個 `'O'` 進行 DFS，將其標記為特殊記號（如 `'#'`），表示這些是與邊界相連、不會被包圍的區域。
2. 遍歷整個棋盤：
   - 將所有 `'O'` 改為 `'X'`（被包圍的區域）。
   - 將所有 `'#'` 恢復為 `'O'`（與邊界相連的區域）。

## 時間複雜度
- **時間**: O(m × n) — 每個格子最多被訪問兩次（邊界 DFS 和最後遍歷）
- **空間**: O(m × n) — 最差情況下遞迴深度為整個網格大小

## 程式碼

```csharp
public class SurroundedRegions
{
    public void Solve(char[][] board)
    {
        if (board == null || board.Length == 0) return;

        int rows = board.Length, cols = board[0].Length;

        // 標記所有與邊界相連的 'O'
        for (int c = 0; c < cols; c++)
        {
            if (board[0][c] == 'O') Dfs(board, 0, c);
            if (board[rows - 1][c] == 'O') Dfs(board, rows - 1, c);
        }

        for (int r = 0; r < rows; r++)
        {
            if (board[r][0] == 'O') Dfs(board, r, 0);
            if (board[r][cols - 1] == 'O') Dfs(board, r, cols - 1);
        }

        // 翻轉：'O' → 'X'，'#' → 'O'
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (board[r][c] == 'O')
                    board[r][c] = 'X';
                else if (board[r][c] == '#')
                    board[r][c] = 'O';
            }
        }
    }

    private void Dfs(char[][] board, int r, int c)
    {
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length || board[r][c] != 'O')
            return;

        board[r][c] = '#'; // 標記為與邊界相連

        Dfs(board, r - 1, c);
        Dfs(board, r + 1, c);
        Dfs(board, r, c - 1);
        Dfs(board, r, c + 1);
    }
}
```
