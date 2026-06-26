# Kth Smallest Element in a BST

## 解題思路
利用 BST 的中序走訪（Inorder Traversal）會產生遞增排序序列的特性。使用迭代式中序走訪（Stack），每次從 stack 彈出一個節點時計數器加 1，當計數器等於 k 時，該節點的值即為答案。

## 時間複雜度
- **時間**: O(n) — 最壞需走訪 k 個節點
- **空間**: O(h) — h 為樹高（stack 深度），最壞為 O(n)

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class KthSmallestElementInBST
{
    public int Solve(TreeNode root, int k)
    {
        var stack = new Stack<TreeNode>();
        TreeNode curr = root;
        int count = 0;

        while (curr != null || stack.Count > 0)
        {
            while (curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }

            curr = stack.Pop();
            count++;

            if (count == k) return curr.val;

            curr = curr.right;
        }

        return -1;
    }
}
```
