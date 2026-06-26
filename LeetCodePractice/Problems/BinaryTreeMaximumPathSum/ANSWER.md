# Binary Tree Maximum Path Sum

## 解題思路
使用 DFS 後序走訪（Postorder）計算每個節點的最大貢獻值。對於每個節點：
1. 計算左右子樹能提供的最大「單邊」路徑和（若為負數則取 0，表示不取該子樹）。
2. 透過該節點的最大路徑和為 `node.val + leftGain + rightGain`，並更新全域最大值。
3. 回傳給父節點的貢獻值為 `node.val + Math.Max(leftGain, rightGain)`，表示只能選擇其中一邊。

## 時間複雜度
- **時間**: O(n) — 每個節點恰好走訪一次
- **空間**: O(h) — h 為樹高（遞迴堆疊深度）

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class BinaryTreeMaximumPathSum
{
    private int maxSum = int.MinValue;

    public int Solve(TreeNode root)
    {
        Dfs(root);
        return maxSum;
    }

    private int Dfs(TreeNode node)
    {
        if (node == null) return 0;

        int leftGain = Math.Max(Dfs(node.left), 0);
        int rightGain = Math.Max(Dfs(node.right), 0);

        int currentPathSum = node.val + leftGain + rightGain;
        maxSum = Math.Max(maxSum, currentPathSum);

        return node.val + Math.Max(leftGain, rightGain);
    }
}
```
