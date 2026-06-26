# Invert Binary Tree

## 解題思路
使用遞迴的方式翻轉二元樹。對於每個節點，交換其左右子節點，然後遞迴地對左右子樹進行相同操作。基本情況：若節點為 null，直接回傳 null。此方法採用後序（post-order）遍歷，先處理子樹再處理當前節點，但前序（先交換、再遞迴）也可行。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好訪問一次
- **空間**: O(h) — 遞迴深度，h 為樹的高度，最壞情況下為 O(n)

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class InvertBinaryTree
{
    public TreeNode Solve(TreeNode root)
    {
        if (root == null) return null!;

        // Swap left and right children
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;

        // Recursively invert subtrees
        Solve(root.left);
        Solve(root.right);

        return root;
    }
}
```
