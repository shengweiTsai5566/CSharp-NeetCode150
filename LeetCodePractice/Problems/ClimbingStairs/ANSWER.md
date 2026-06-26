# Climbing Stairs

## 解題思路
經典的 Fibonacci 數列 DP 問題。爬到第 n 階的方法數等於爬到第 n-1 階（再爬 1 步）加上爬到第 n-2 階（再爬 2 步）的方法數。使用兩個變數滾動更新，無需完整的 DP 陣列，空間可優化至 O(1)。

## 時間複雜度
- **時間**: O(n) — 只需一次迴圈
- **空間**: O(1) — 只使用兩個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ClimbingStairs
{
    public int Solve(int n)
    {
        if (n <= 2) return n;

        int one = 1, two = 2;
        for (int i = 3; i <= n; i++)
        {
            int cur = one + two;
            one = two;
            two = cur;
        }

        return two;
    }
}
```
