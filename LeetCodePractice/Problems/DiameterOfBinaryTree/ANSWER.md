# Diameter of Binary Tree

## 解題思路
使用遞迴計算二元樹的直徑。直徑定義為樹中任意兩節點間最長路徑的邊數，該路徑不一定經過根節點。

對於每個節點，經過該節點的最長路徑長度為 `leftDepth + rightDepth`（左子樹深度 + 右子樹深度）。使用一個全域變數（或參考變數）記錄遍歷過程中出現的最大值。

遞迴函式回傳該節點的深度（`1 + max(leftDepth, rightDepth)`），供父節點計算使用。此為後序遍歷（post-order DFS）。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好訪問一次
- **空間**: O(h) — 遞迴深度，h 為樹的高度，最壞情況下為 O(n)

## 程式碼

```csharp
namespace LeetCodePractice.Problems;

public class DiameterOfBinaryTree
{
    private int _diameter = 0;

    public int Solve(TreeNode root)
    {
        Depth(root);
        return _diameter;
    }

    private int Depth(TreeNode node)
    {
        if (node == null) return 0;

        int leftDepth = Depth(node.left);
        int rightDepth = Depth(node.right);

        // Update diameter: longest path through this node
        _diameter = Math.Max(_diameter, leftDepth + rightDepth);

        // Return depth to parent
        return 1 + Math.Max(leftDepth, rightDepth);
    }
}
```
