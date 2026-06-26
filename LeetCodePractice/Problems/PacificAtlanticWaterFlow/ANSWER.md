# Pacific Atlantic Water Flow

## 解題思路
從邊界反向思考：雨水可以從高處流向低處（或相等高度），與其從每個細胞模擬流向海洋，不如從海洋反向模擬。

1. 建立兩個布林矩陣 `pacific` 和 `atlantic`，分別記錄哪些細胞可以流向太平洋和大西洋。
2. 從上邊界和左邊界（與太平洋相鄰）開始進行 DFS/BFS，標記所有可以流向太平洋的細胞。
3. 從下邊界和右邊界（與大西洋相鄰）開始進行 DFS/BFS，標記所有可以流向大西洋的細胞。
4. 遍歷整個網格，找出同時在 `pacific` 和 `atlantic` 中被標記為 `true` 的細胞。

反向 DFS 的條件：從邊界出發，往高度 **大於等於** 當前細胞的方向擴散（因為水可以從高處往低處流，反向即是從低處往高處走）。

## 時間複雜度
- **時間**: O(m × n) — 每個格子最多被訪問兩次（太平洋和大西洋各一次）
- **空間**: O(m × n) — 需要兩個布林矩陣以及遞迴呼叫棧的空間

## 程式碼

```csharp
public class PacificAtlanticWaterFlow
{
    public IList<IList<int>> Solve(int[][] heights)
    {
        int rows = heights.Length, cols = heights[0].Length;
        bool[][] pacific = new bool[rows][];
        bool[][] atlantic = new bool[rows][];

        for (int i = 0; i < rows; i++)
        {
            pacific[i] = new bool[cols];
            atlantic[i] = new bool[cols];
        }

        // 從邊界開始 DFS
        for (int c = 0; c < cols; c++)
        {
            Dfs(heights, pacific, 0, c, int.MinValue);       // 上邊界（太平洋）
            Dfs(heights, atlantic, rows - 1, c, int.MinValue); // 下邊界（大西洋）
        }

        for (int r = 0; r < rows; r++)
        {
            Dfs(heights, pacific, r, 0, int.MinValue);       // 左邊界（太平洋）
            Dfs(heights, atlantic, r, cols - 1, int.MinValue); // 右邊界（大西洋）
        }

        var result = new List<IList<int>>();
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (pacific[r][c] && atlantic[r][c])
                    result.Add(new List<int> { r, c });
            }
        }

        return result;
    }

    private void Dfs(int[][] heights, bool[][] visited, int r, int c, int prevHeight)
    {
        if (r < 0 || r >= heights.Length || c < 0 || c >= heights[0].Length)
            return;
        if (visited[r][c] || heights[r][c] < prevHeight)
            return;

        visited[r][c] = true;

        Dfs(heights, visited, r - 1, c, heights[r][c]);
        Dfs(heights, visited, r + 1, c, heights[r][c]);
        Dfs(heights, visited, r, c - 1, heights[r][c]);
        Dfs(heights, visited, r, c + 1, heights[r][c]);
    }
}
```
