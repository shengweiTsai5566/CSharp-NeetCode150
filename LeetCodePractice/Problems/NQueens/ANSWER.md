# N-Queens

## 解題思路

使用回溯法，在 n × n 的棋盤上放置 n 個皇后，使它們不會互相攻擊（即任意兩個皇后不在同一行、同一列或同一對角線上）。

**核心思想：**
由於每列只能放一個皇后，我們可以逐列放置，並使用集合來記錄被佔用的欄位和對角線。

**步驟：**
1. 定義遞迴函式 `Backtrack(row, board, result)`：
   - `row`：目前要放置皇后的列數
   - `board`：目前棋盤狀態（字元陣列）
2. 終止條件：若 `row == n`，表示所有皇后都放置成功，將棋盤轉換為所需格式後加入結果。
3. 對於當前列的每一欄：
   - 檢查該位置是否安全（沒有其他皇后在同一欄、主對角線或副對角線）
   - 若是，放置皇后並記錄佔用狀態
   - 遞迴處理下一列
   - 回溯：移除皇后並釋放佔用狀態

**檢查衝突的最佳化：**
使用三個 HashSet 來記錄：
- `cols`：已被佔用的欄
- `diag1`：已被佔用的主對角線（`row - col` 為常數）
- `diag2`：已被佔用的副對角線（`row + col` 為常數）

這樣可以在 O(1) 時間內完成衝突檢查。

## 時間複雜度

- **時間**: O(n!) — 第一列有 n 個選擇，第二列最多 n-1 個，以此類推
- **空間**: O(n²) — 棋盤空間加上遞迴深度

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class NQueens
{
    public IList<IList<string>> Solve(int n)
    {
        var result = new List<IList<string>>();
        var board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            Array.Fill(board[i], '.');
        }

        var cols = new HashSet<int>();
        var diag1 = new HashSet<int>();
        var diag2 = new HashSet<int>();

        Backtrack(n, 0, board, cols, diag1, diag2, result);
        return result;
    }

    private void Backtrack(int n, int row, char[][] board,
                           HashSet<int> cols, HashSet<int> diag1, HashSet<int> diag2,
                           List<IList<string>> result)
    {
        if (row == n)
        {
            var solution = new List<string>();
            foreach (var r in board)
                solution.Add(new string(r));
            result.Add(solution);
            return;
        }

        for (int col = 0; col < n; col++)
        {
            if (cols.Contains(col) ||
                diag1.Contains(row - col) ||
                diag2.Contains(row + col))
                continue;

            board[row][col] = 'Q';
            cols.Add(col);
            diag1.Add(row - col);
            diag2.Add(row + col);

            Backtrack(n, row + 1, board, cols, diag1, diag2, result);

            board[row][col] = '.';
            cols.Remove(col);
            diag1.Remove(row - col);
            diag2.Remove(row + col);
        }
    }
}
```
