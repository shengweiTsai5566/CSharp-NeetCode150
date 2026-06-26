# Word Search II

**LeetCode：** [212. Word Search II](https://leetcode.com/problems/word-search-ii/) (Hard)

**NeetCode 150：** 第 58 題

---

## 解題思路

給定一個 `m × n` 字母棋盤和一個字串陣列 `words`，找出所有可以在棋盤上相鄰（上下左右）拼接而成的單字。**同一格不能重複使用。**

### 核心策略：Trie + Backtracking (DFS)

暴力法是對每個單字分別做 DFS，時間複雜度會是 O(N × m × n × 4^L) 非常慢。更好的作法是先將所有單字建立成 **Trie**，然後在棋盤上進行一次 DFS，同時比對 Trie 中的所有單字。

### 演算法步驟

1. **建立 Trie**：將所有 `words` 插入 Trie，並在每個 TrieNode 中儲存該節點對應的完整單字（方便找到時直接記錄）。
2. **棋盤 DFS**：
   - 對棋盤上每一個格子作為起點，進行 DFS。
   - 若當前字元不在 Trie 的子節點中，直接剪枝（Prune）。
   - 若當前節點是單字結尾，將該單字加入結果集，並標記 `IsEnd = false`（避免重複加入）。
   - 暫存當前格子字元，標記為 `'#'`（或使用 `visited` 陣列）以防止重複使用。
   - 往四個方向繼續遞迴。
   - 回溯時還原字元。

### 時間/空間複雜度

- **時間複雜度：** O(m × n × 4^L)，其中 L 為最長單字長度。但 Trie 的剪枝效果讓實際執行遠低於此上限。
- **空間複雜度：** O(N × L)（Trie 儲存空間）+ O(L)（遞迴深度）。

---

## 完整 C# 解答

```csharp
using System.Collections.Generic;

public class WordSearchII
{
    private class TrieNode
    {
        public TrieNode[] Children { get; set; }
        public string Word { get; set; } // 若為單字結尾則儲存完整單字

        public TrieNode()
        {
            Children = new TrieNode[26];
            Word = null;
        }
    }

    public IList<string> Solve(char[][] board, string[] words)
    {
        var result = new List<string>();

        // 1. 建立 Trie
        var root = new TrieNode();
        foreach (var word in words)
        {
            var node = root;
            foreach (char c in word)
            {
                int index = c - 'a';
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }
                node = node.Children[index];
            }
            node.Word = word;
        }

        // 2. 對每個格子進行 DFS
        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Dfs(board, r, c, root, result);
            }
        }

        return result;
    }

    private void Dfs(char[][] board, int r, int c, TrieNode node, List<string> result)
    {
        if (r < 0 || r >= board.Length || c < 0 || c >= board[0].Length)
            return;

        char ch = board[r][c];
        if (ch == '#' || node.Children[ch - 'a'] == null)
            return;

        node = node.Children[ch - 'a'];

        // 找到完整單字
        if (node.Word != null)
        {
            result.Add(node.Word);
            node.Word = null; // 避免重複加入
        }

        // 標記已訪問
        board[r][c] = '#';

        // 四個方向 DFS
        Dfs(board, r - 1, c, node, result);
        Dfs(board, r + 1, c, node, result);
        Dfs(board, r, c - 1, node, result);
        Dfs(board, r, c + 1, node, result);

        // 回溯還原
        board[r][c] = ch;
    }
}
```

---

## 重點提醒

- **Trie 剪枝**是這題效能的關鍵，避免對每個單字分別做 DFS。
- 在 TrieNode 中直接儲存完整單字 (`Word`)，DFS 到底時可直接記錄，節省 StringBuilder 的開銷。
- 使用 `board[r][c] = '#'` 修改原始棋盤來標記訪問過，節省 `visited` 陣列的空間。
- 找到單字後設 `node.Word = null` 防止結果中有重複。
