# Serialize and Deserialize Binary Tree

**LeetCode：** [297. Serialize and Deserialize Binary Tree](https://leetcode.com/problems/serialize-and-deserialize-binary-tree/) (Hard)

**NeetCode 150：** 第 55 題

---

## 解題思路

序列化（Serialize）是將二元樹轉換為字串，反序列化（Deserialize）是將字串還原回原本的二元樹結構。

### BFS（層序走訪）法

1. **序列化（Serialize）**：
   - 使用 BFS 搭配 Queue 層序走訪二元樹。
   - 遇到節點就記錄其值，遇到 `null` 就記錄 `"null"`。
   - 最後用分隔符（如 `","`）組合成字串。

2. **反序列化（Deserialize）**：
   - 將字串以分隔符拆分成節點值陣列。
   - 第一個值就是根節點，將根節點入隊。
   - 使用指針 `i` 依序指向子節點，每次從 Queue 取出一個節點，就設定其左右子節點（若值不為 `"null"` 則建立節點並入隊，否則設為 `null`）。

### DFS（前序走訪）法

另一種常見作法是用 DFS 前序走訪（Root → Left → Right），遇到 `null` 時用特殊標記記錄，反序列化時遞迴重建。

### 時間/空間複雜度

- **時間複雜度：** O(N)，其中 N 是節點總數（每個節點訪問一次）。
- **空間複雜度：** O(N)，Queue / 遞迴堆疊與結果字串需要 O(N) 空間。

---

## 完整 C# 解答 (BFS 層序)

```csharp
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class SerializeAndDeserializeBinaryTree
{
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root)
    {
        if (root == null) return "null";

        var sb = new StringBuilder();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == null)
            {
                sb.Append("null,");
            }
            else
            {
                sb.Append(node.val + ",");
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }

        // 移除結尾多餘的逗號
        sb.Length--;
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data)
    {
        if (data == "null") return null;

        var values = data.Split(',');
        var root = new TreeNode(int.Parse(values[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (queue.Count > 0 && i < values.Length)
        {
            var node = queue.Dequeue();

            // 處理左子節點
            if (values[i] != "null")
            {
                node.left = new TreeNode(int.Parse(values[i]));
                queue.Enqueue(node.left);
            }
            i++;

            // 處理右子節點
            if (i < values.Length && values[i] != "null")
            {
                node.right = new TreeNode(int.Parse(values[i]));
                queue.Enqueue(node.right);
            }
            i++;
        }

        return root;
    }
}
```

---

## DFS 前序解法（遞迴版）

```csharp
using System.Text;
using System.Collections.Generic;

public class CodecDFS
{
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root)
    {
        var sb = new StringBuilder();
        SerializeHelper(root, sb);
        return sb.ToString();
    }

    private void SerializeHelper(TreeNode node, StringBuilder sb)
    {
        if (node == null)
        {
            sb.Append("null,");
            return;
        }
        sb.Append(node.val + ",");
        SerializeHelper(node.left, sb);
        SerializeHelper(node.right, sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data)
    {
        var queue = new Queue<string>(data.Split(','));
        return DeserializeHelper(queue);
    }

    private TreeNode DeserializeHelper(Queue<string> queue)
    {
        var val = queue.Dequeue();
        if (val == "null") return null;

        var node = new TreeNode(int.Parse(val));
        node.left = DeserializeHelper(queue);
        node.right = DeserializeHelper(queue);
        return node;
    }
}
```
