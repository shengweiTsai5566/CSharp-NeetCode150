# Same Tree

## 解題思路
使用遞迴（DFS）來比較兩棵二元樹是否相同。基本情況：若兩節點皆為 null，回傳 true；若其中之一為 null 或兩者值不同，回傳 false。接著遞迴比較左子樹和右子樹是否相同。

## 時間複雜度
- **時間**: O(min(p, q)) — 最壞情況下需走訪所有節點
- **空間**: O(min(p, q)) — 遞迴呼叫的堆疊深度（樹的高度）

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class SameTree
{
    public bool Solve(TreeNode p, TreeNode q)
    {
        if (p == null && q == null) return true;
        if (p == null || q == null) return false;
        if (p.val != q.val) return false;

        return Solve(p.left, q.left) && Solve(p.right, q.right);
    }
}
```
