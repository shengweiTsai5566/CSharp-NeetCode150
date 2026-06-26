# Maximum Depth of Binary Tree

## 解題思路
使用遞迴計算二元樹的最大深度。一棵樹的最大深度定義為根節點到最遠葉節點的路徑上的節點數。公式為：`1 + max(leftDepth, rightDepth)`。基本情況：若節點為 null，深度為 0。此為經典的 DFS（Depth-First Search）後序遍歷。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好訪問一次
- **空間**: O(h) — 遞迴深度，h 為樹的高度，最壞情況下為 O(n)

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class MaximumDepthOfBinaryTree
{
    public int Solve(TreeNode root)
    {
        if (root == null) return 0;

        int leftDepth = Solve(root.left);
        int rightDepth = Solve(root.right);

        return 1 + Math.Max(leftDepth, rightDepth);
    }
}
```
