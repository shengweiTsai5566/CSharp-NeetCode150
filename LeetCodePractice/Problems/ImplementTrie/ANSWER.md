# Implement Trie (Prefix Tree)

**LeetCode：** [208. Implement Trie (Prefix Tree)](https://leetcode.com/problems/implement-trie-prefix-tree/) (Medium)

**NeetCode 150：** 第 56 題

---

## 解題思路

Trie（前綴樹）是一種專門處理字串集合的樹狀資料結構，常用於自動完成、拼字檢查等場景。

### 核心概念

每個節點代表一個字元，並包含：
- **子節點陣列**：長度 26（對應 a~z），指向下一個字元。
- **是否為單字結尾**：標記從根到此節點的路徑是否構成一個完整的單字。

### 操作說明

1. **Insert（插入）**：
   - 從根節點開始，依序走訪單字的每個字元。
   - 若該字元的子節點不存在，則建立一個新節點。
   - 走到最後一個字元時，將該節點的 `IsEnd` 標記為 `true`。

2. **Search（搜尋）**：
   - 從根節點開始，依序走訪單字的每個字元。
   - 若途中任何字元的子節點不存在，回傳 `false`。
   - 最後檢查最後一個節點的 `IsEnd` 是否為 `true`。

3. **StartsWith（前綴檢查）**：
   - 與 Search 類似，但最後不需要檢查 `IsEnd`，只要前綴路徑存在即回傳 `true`。

### 時間/空間複雜度

- **Insert：** O(L)，L 為單字長度。
- **Search：** O(L)，L 為單字長度。
- **StartsWith：** O(L)，L 為前綴長度。
- **空間複雜度：** O(N × L)，N 為單字數，L 為平均單字長度（最差情況下）。

---

## 完整 C# 解答

```csharp
public class ImplementTrie
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

    public ImplementTrie()
    {
        _root = new TrieNode();
    }

    public void Insert(string word)
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
        var node = _root;
        foreach (char c in word)
        {
            int index = c - 'a';
            if (node.Children[index] == null)
            {
                return false;
            }
            node = node.Children[index];
        }
        return node.IsEnd;
    }

    public bool StartsWith(string prefix)
    {
        var node = _root;
        foreach (char c in prefix)
        {
            int index = c - 'a';
            if (node.Children[index] == null)
            {
                return false;
            }
            node = node.Children[index];
        }
        return true;
    }
}
```

---

## 進階思考

- 若字元包含大寫字母或數字，可以改用 Dictionary 取代固定長度陣列。
- Trie 也可用於實作自動補完（Auto-complete），只需 DFS 走訪所有 `IsEnd = true` 的路徑。
- 空間最佳化可考慮使用壓縮 Trie（Radix Tree / Patricia Trie）。
