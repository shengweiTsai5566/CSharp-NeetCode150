# Construct Binary Tree from Preorder and Inorder Traversal

## 解題思路
利用前序走訪（Preorder）和中序走訪（Inorder）的特性：
- 前序的第一個元素是樹的根節點。
- 在中序中找到該根節點的位置，其左側為左子樹節點，右側為右子樹節點。
- 使用一個字典（Dictionary）儲存中序陣列中值與索引的對應關係，以便快速查找。
- 遞迴建立左右子樹，並用索引範圍（inLeft、inRight）來切割中序陣列。

## 時間複雜度
- **時間**: O(n) — 每個節點建立一次
- **空間**: O(n) — 字典儲存 n 個節點的索引 + 遞迴堆疊

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class ConstructBinaryTreeFromPreorderAndInorder
{
    private int preIndex = 0;
    private Dictionary<int, int> inMap = new();

    public TreeNode Solve(int[] preorder, int[] inorder)
    {
        for (int i = 0; i < inorder.Length; i++)
            inMap[inorder[i]] = i;

        return Build(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Build(int[] preorder, int inLeft, int inRight)
    {
        if (inLeft > inRight) return null;

        int rootVal = preorder[preIndex++];
        var root = new TreeNode(rootVal);
        int mid = inMap[rootVal];

        root.left = Build(preorder, inLeft, mid - 1);
        root.right = Build(preorder, mid + 1, inRight);

        return root;
    }
}
```
