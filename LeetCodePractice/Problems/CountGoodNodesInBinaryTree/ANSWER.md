# Count Good Nodes in Binary Tree

## 解題思路
使用 DFS 遍歷二元樹，並在遞迴過程中追蹤從根節點到當前節點路徑上的最大值。若當前節點的值大於等於此路徑最大值，則該節點即為 Good Node，計數加 1。遞迴左右子樹時，更新最大值為 `Math.Max(currentMax, node.val)`。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好走訪一次
- **空間**: O(h) — h 為樹高（遞迴堆疊深度），最壞為 O(n)

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class CountGoodNodesInBinaryTree
{
    public int Solve(TreeNode root)
    {
        return Dfs(root, root.val);
    }

    private int Dfs(TreeNode node, int maxSoFar)
    {
        if (node == null) return 0;

        int count = 0;
        if (node.val >= maxSoFar)
            count = 1;

        maxSoFar = Math.Max(maxSoFar, node.val);
        count += Dfs(node.left, maxSoFar);
        count += Dfs(node.right, maxSoFar);

        return count;
    }
}
```
