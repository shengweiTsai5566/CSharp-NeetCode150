# Lowest Common Ancestor of a Binary Search Tree

## 解題思路
利用二元搜尋樹（BST）的性質：左子樹所有節點值 < 根節點值 < 右子樹所有節點值。從根節點開始走訪：
- 若 `p` 和 `q` 的值都小於當前節點，則 LCA 在左子樹。
- 若 `p` 和 `q` 的值都大於當前節點，則 LCA 在右子樹。
- 否則，當前節點即為 LCA（因為 `p` 和 `q` 分別在左右子樹或其中之一就是當前節點）。

## 時間複雜度
- **時間**: O(h) — h 為樹高，最壞為 O(n)
- **空間**: O(1) — 迭代法不需額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class LowestCommonAncestorOfBST
{
    public TreeNode Solve(TreeNode root, TreeNode p, TreeNode q)
    {
        TreeNode curr = root;

        while (curr != null)
        {
            if (p.val < curr.val && q.val < curr.val)
                curr = curr.left;
            else if (p.val > curr.val && q.val > curr.val)
                curr = curr.right;
            else
                return curr;
        }

        return null;
    }
}
```
