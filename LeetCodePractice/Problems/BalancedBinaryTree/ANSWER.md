# Balanced Binary Tree

## 解題思路
使用遞迴判斷二元樹是否為高度平衡（每個節點的左右子樹高度差不超過 1）。實作一個輔助函式 `CheckHeight`，該函式回傳子樹的高度，若不平衡則回傳 -1：

1. 若節點為 null，回傳高度 0。
2. 遞迴計算左子樹高度，若為 -1 表示不平衡，直接向上傳遞。
3. 遞迴計算右子樹高度，若為 -1 表示不平衡，直接向上傳遞。
4. 若左右子樹高度差 > 1，回傳 -1 表示不平衡。
5. 否則回傳 `1 + max(leftHeight, rightHeight)`。

主函式只需判斷 `CheckHeight(root) != -1`。此方法在計算高度的同時檢查平衡性，避免重複遍歷。

## 時間複雜度
- **時間**: O(n) — 每個節點僅訪問一次
- **空間**: O(h) — 遞迴深度，h 為樹的高度，最壞情況下為 O(n)

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class BalancedBinaryTree
{
    public bool Solve(TreeNode root)
    {
        return CheckHeight(root) != -1;
    }

    private int CheckHeight(TreeNode node)
    {
        if (node == null) return 0;

        int leftHeight = CheckHeight(node.left);
        if (leftHeight == -1) return -1;

        int rightHeight = CheckHeight(node.right);
        if (rightHeight == -1) return -1;

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
```
