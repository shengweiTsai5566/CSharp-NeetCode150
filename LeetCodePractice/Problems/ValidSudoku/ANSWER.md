# Valid Sudoku

## 解題思路
使用三個 HashSet 陣列分別追蹤每一行、每一列和每一個 3×3 方塊中出現的數字。遍歷 9×9 的棋盤，當遇到數字（非 '.'）時，檢查該數字是否已在對應的行、列或方塊中出現過。若出現重複則回傳 false，否則將數字加入對應的集合中。

## 時間複雜度
- **時間**: O(9²) = O(1) — 棋盤大小固定為 9×9
- **空間**: O(9²) = O(1) — 使用固定大小的集合

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class ValidSudoku
{
    public bool Solve(char[][] board)
    {
        var rows = new HashSet<char>[9];
        var cols = new HashSet<char>[9];
        var boxes = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            rows[i] = new HashSet<char>();
            cols[i] = new HashSet<char>();
            boxes[i] = new HashSet<char>();
        }

        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char val = board[r][c];
                if (val == '.') continue;

                int boxIndex = (r / 3) * 3 + (c / 3);

                if (rows[r].Contains(val) ||
                    cols[c].Contains(val) ||
                    boxes[boxIndex].Contains(val))
                {
                    return false;
                }

                rows[r].Add(val);
                cols[c].Add(val);
                boxes[boxIndex].Add(val);
            }
        }

        return true;
    }
}
```
