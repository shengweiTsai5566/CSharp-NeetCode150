# Word Search

## 解題思路

使用深度優先搜尋（DFS）搭配回溯法，在棋盤上尋找是否存在目標單詞。

**步驟：**
1. 遍歷棋盤的每個格子，以每個格子為起點進行 DFS。
2. 定義遞迴函式 `Dfs(row, col, index)`：
   - `row, col`：當前位置
   - `index`：目前要匹配的單詞字元索引
3. 終止條件：
   - `index == word.Length`：所有字元都匹配成功，回傳 `true`
   - 超出邊界或字元不匹配或該格子已使用：回傳 `false`
4. 將當前格子標記為已使用（例如改成 `'#'`），再往四個方向遞迴探索。
5. 回溯：將格子恢復原狀。
6. 若任一方向找到完整單詞則回傳 `true`。

**最佳化（Follow-up）：**
- 可在開始前先檢查單詞中每個字元的出現次數是否不超過棋盤中的次數（預剪枝）。
- 若單詞長度大於棋盤格子總數，可直接回傳 `false`。

## 時間複雜度

- **時間**: O(m × n × 3^L) — m、n 為棋盤維度，L 為單詞長度；每個格子最多有 3 個方向（不含回頭方向）
- **空間**: O(L) — 遞迴深度最多為單詞長度

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class WordSearch
{
    public bool Solve(char[][] board, string word)
    {
        int m = board.Length, n = board[0].Length;

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (Dfs(board, word, i, j, 0))
                    return true;
            }
        }

        return false;
    }

    private bool Dfs(char[][] board, string word, int row, int col, int index)
    {
        if (index == word.Length) return true;
        if (row < 0 || row >= board.Length ||
            col < 0 || col >= board[0].Length ||
            board[row][col] != word[index])
            return false;

        char temp = board[row][col];
        board[row][col] = '#'; // 標記已使用

        bool found = Dfs(board, word, row + 1, col, index + 1) ||
                     Dfs(board, word, row - 1, col, index + 1) ||
                     Dfs(board, word, row, col + 1, index + 1) ||
                     Dfs(board, word, row, col - 1, index + 1);

        board[row][col] = temp; // 回溯
        return found;
    }
}
```
