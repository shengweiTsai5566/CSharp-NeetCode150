# Max Area of Island

## 解題思路
使用深度優先搜尋（DFS）遍歷網格。當遇到 `1` 時，進行 DFS 計算該島嶼的面積（相連的 1 的數量），並將訪問過的格子設為 `0` 以避免重複計算。記錄並更新最大面積，最後回傳最大面積值。

也可以使用 BFS 搭配佇列來實作，概念相同。

## 時間複雜度
- **時間**: O(m × n) — 每個格子最多被訪問一次
- **空間**: O(m × n) — 最差情況下遞迴深度（或佇列大小）為整個網格大小

## 程式碼

```csharp
public class MaxAreaOfIsland
{
    public int Solve(int[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;

        int rows = grid.Length, cols = grid[0].Length;
        int maxArea = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 1)
                {
                    maxArea = Math.Max(maxArea, Dfs(grid, r, c));
                }
            }
        }

        return maxArea;
    }

    private int Dfs(int[][] grid, int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[0].Length || grid[r][c] != 1)
            return 0;

        grid[r][c] = 0; // 標記為已訪問
        int area = 1;

        area += Dfs(grid, r - 1, c);
        area += Dfs(grid, r + 1, c);
        area += Dfs(grid, r, c - 1);
        area += Dfs(grid, r, c + 1);

        return area;
    }
}
```
