# Validate Binary Search Tree

## 解題思路
使用 DFS 搭配上下界範圍進行驗證。遞迴時傳入允許的最小值 `min` 和最大值 `max`：
- 左子樹的所有節點值必須小於根節點值（更新上界為 `root.val`）。
- 右子樹的所有節點值必須大於根節點值（更新下界為 `root.val`）。
若任一節點違反範圍限制，則不是有效的 BST。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好走訪一次
- **空間**: O(h) — h 為樹高（遞迴堆疊深度）

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ValidateBinarySearchTree
{
    public bool Solve(TreeNode root)
    {
        return Dfs(root, long.MinValue, long.MaxValue);
    }

    private bool Dfs(TreeNode node, long min, long max)
    {
        if (node == null) return true;
        if (node.val <= min || node.val >= max) return false;

        return Dfs(node.left, min, node.val) && Dfs(node.right, node.val, max);
    }
}
```
