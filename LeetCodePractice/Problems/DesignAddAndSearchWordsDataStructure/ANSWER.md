# Design Add and Search Words Data Structure

**LeetCode：** [211. Design Add and Search Words Data Structure](https://leetcode.com/problems/design-add-and-search-words-data-structure/) (Medium)

**NeetCode 150：** 第 57 題

---

## 解題思路

本題是 Trie 的延伸變化，搜尋時支援 `'.'` 萬用字元，可以匹配任意字母。

### 核心概念

使用 Trie 儲存所有單字，主要難點在於 Search 操作中遇到 `'.'` 時需要 **遞迴/DFS** 嘗試所有可能的子節點。

### 資料結構

- **TrieNode**：與標準 Trie 相同，包含長度 26 的子節點陣列和 `IsEnd` 標記。
- **AddWord**：標準 Trie 插入。
- **Search**：
  - 對每個字元進行走訪。
  - 若字元為 `'.'`，則對當前節點所有非空的子節點進行遞迴搜尋。
  - 若任一條遞迴路徑成功找到完整單字，回傳 `true`。

### 時間/空間複雜度

- **AddWord：** O(L)，L 為單字長度。
- **Search（無萬用字元）：** O(L)。
- **Search（含萬用字元）：** 最差 O(26^K × L)，K 為 `'.'` 的數量。題目限制最多 2 個 `'.'`，因此效能可接受。
- **空間複雜度：** O(N × L)，N 為單字總數。

---

## 完整 C# 解答

```csharp
public class DesignAddAndSearchWordsDataStructure
{
    private class TrieNode
    {
        public TrieNode[] Children { get; set; }
        public bool IsEnd { get; set; }

        public TrieNode()
        {
            Children = new TrieNode[26];
            IsEnd = false;
        }
    }

    private readonly TrieNode _root;

    public DesignAddAndSearchWordsDataStructure()
    {
        _root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var node = _root;
        foreach (char c in word)
        {
            int index = c - 'a';
            if (node.Children[index] == null)
            {
                node.Children[index] = new TrieNode();
            }
            node = node.Children[index];
        }
        node.IsEnd = true;
    }

    public bool Search(string word)
    {
        return SearchHelper(_root, word, 0);
    }

    private bool SearchHelper(TrieNode node, string word, int index)
    {
        if (node == null) return false;

        // 已走訪完整個單字，檢查是否為完整單字
        if (index == word.Length)
        {
            return node.IsEnd;
        }

        char c = word[index];

        if (c == '.')
        {
            // 萬用字元：嘗試所有 26 個子節點
            for (int i = 0; i < 26; i++)
            {
                if (node.Children[i] != null)
                {
                    if (SearchHelper(node.Children[i], word, index + 1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        else
        {
            // 一般字元：直接走訪對應子節點
            int childIndex = c - 'a';
            return SearchHelper(node.Children[childIndex], word, index + 1);
        }
    }
}
```

---

## 重點提醒

- `'.'` 萬用字元必須使用遞迴處理，不能直接迭代。
- 因為題目限制 `word` 長度最多 25 且 `'.'` 最多 2 個，遞迴深度可控，不會堆疊溢位。
- 若無 `'.'` 限制，可考慮將所有單字依長度分組，搭配 HashSet 做精確匹配加速。
