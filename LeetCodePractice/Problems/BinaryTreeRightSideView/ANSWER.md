# Binary Tree Right Side View

## 解題思路
使用 BFS 層序遍歷，在每一層中記錄最右側節點的值（即該層最後一個出佇列的節點）。將這些值依序加入結果列表即為從右側看到的節點值。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好走訪一次
- **空間**: O(n) — 佇列最多儲存一層的節點

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class BinaryTreeRightSideView
{
    public IList<int> Solve(TreeNode root)
    {
        var result = new List<int>();
        if (root == null) return result;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int levelSize = queue.Count;
            int rightMostValue = 0;

            for (int i = 0; i < levelSize; i++)
            {
                var node = queue.Dequeue();
                rightMostValue = node.val;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            result.Add(rightMostValue);
        }

        return result;
    }
}
```
