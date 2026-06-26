# Rotting Oranges

## 解題思路
使用廣度優先搜尋（BFS）模擬腐爛的擴散過程。

1. 遍歷網格，將所有一開始就是腐爛的橘子（值為 `2`）的位置加入佇列，並計算新鮮橘子（值為 `1`）的數量。
2. 使用 BFS 逐層擴散：每一層代表一分鐘，從當前腐爛橘子往四個方向擴散，將遇到的新鮮橘子變成腐爛並加入佇列。
3. 每過一分鐘（每一層處理完），時間計數加一。
4. BFS 結束後，檢查是否還有新鮮橘子未被感染。如果有，回傳 `-1`；否則回傳經過的分鐘數。

## 時間複雜度
- **時間**: O(m × n) — 每個格子最多被訪問一次
- **空間**: O(m × n) — 最差情況下佇列大小為整個網格大小

## 程式碼

```csharp
public class RottingOranges
{
    public int Solve(int[][] grid)
    {
        int rows = grid.Length, cols = grid[0].Length;
        var queue = new Queue<(int r, int c)>();
        int fresh = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] == 2)
                    queue.Enqueue((r, c));
                else if (grid[r][c] == 1)
                    fresh++;
            }
        }

        if (fresh == 0) return 0;

        int minutes = 0;
        int[][] dirs = new int[][] { new[] { -1, 0 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { 0, 1 } };

        while (queue.Count > 0)
        {
            int size = queue.Count;
            bool rotted = false;

            for (int i = 0; i < size; i++)
            {
                var (r, c) = queue.Dequeue();

                foreach (var dir in dirs)
                {
                    int nr = r + dir[0], nc = c + dir[1];
                    if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == 1)
                    {
                        grid[nr][nc] = 2;
                        queue.Enqueue((nr, nc));
                        fresh--;
                        rotted = true;
                    }
                }
            }

            if (rotted) minutes++;
        }

        return fresh == 0 ? minutes : -1;
    }
}
```
