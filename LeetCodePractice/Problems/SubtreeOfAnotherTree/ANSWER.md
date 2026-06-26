# Subtree of Another Tree

## 解題思路
利用「Same Tree」的檢查邏輯，遍歷 `root` 的每個節點，判斷以該節點為根的子樹是否與 `subRoot` 完全相同。若相同則回傳 true；否則繼續遞迴檢查左右子樹。

## 時間複雜度
- **時間**: O(m × n) — 最壞情況下，`root` 的每個節點都需與 `subRoot` 比較
- **空間**: O(m + n) — 遞迴堆疊深度

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class SubtreeOfAnotherTree
{
    public bool Solve(TreeNode root, TreeNode subRoot)
    {
        if (root == null) return false;

        if (IsSameTree(root, subRoot)) return true;

        return Solve(root.left, subRoot) || Solve(root.right, subRoot);
    }

    private bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        if (p.val != q.val) return false;

        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
```
