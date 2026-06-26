# Binary Tree Level Order Traversal

## 解題思路
使用廣度優先搜尋（BFS）搭配佇列（Queue）。每次處理一層的所有節點：將當前層的節點值加入結果列表，並將其左右子節點加入下一層的佇列中。重複直到所有層級處理完畢。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好走訪一次
- **空間**: O(n) — 佇列最多儲存一層的節點，最壞為 O(n)

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class BinaryTreeLevelOrderTraversal
{
    public IList<IList<int>> Solve(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            var level = new List<int>();

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(level);
        }

        return result;
    }
}
```
