# Number of Islands

## 解題思路
使用深度優先搜尋（DFS）來遍歷網格。當遇到 `'1'`（陸地）時，表示發現一個新的島嶼，島嶼計數加一，然後透過 DFS 將與該陸地相連的所有陸地都標記為已訪問（設為 `'0'`），避免重複計算。遍歷完整個網格後，回傳島嶼總數。

另一種方式是使用 BFS，每次遇到 `'1'` 時以佇列進行廣度優先搜尋來標記相連陸地。

## 時間複雜度
- **時間**: O(m × n) — 每個格子最多被訪問一次
- **空間**: O(m × n) — 最差情況下遞迴深度（或佇列大小）為整個網格大小

## 程式碼

```csharp
public class NumberOfIslands
{
    public int Solve(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;

        int rows = grid.Length, cols = grid[0].Length;
        int count = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == '1')
                {
                    count++;
                    Dfs(grid, r, c);
                }
            }
        }

        return count;
    }

    private void Dfs(char[][] grid, int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] != '1')
            return;

        grid[r][c] = '0'; // 標記為已訪問

        Dfs(grid, r - 1, c);
        Dfs(grid, r + 1, c);
        Dfs(grid, r, c - 1);
        Dfs(grid, r, c + 1);
    }
}
```
