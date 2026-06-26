# Missing Number

## 解題思路
給定一個長度為 n 的陣列，包含範圍 `[0, n]` 中 n 個不同的數字，找出缺少的那一個數字。

方法一：**XOR 運算**
- 將陣列中所有數字與 `0` 到 `n` 的所有數字進行 XOR。
- 因為 `a ^ a = 0`，且 XOR 滿足交換律，出現的數字會互相抵消，最後剩下的即為缺失的數字。

方法二：**數學公式**
- 計算 `0 + 1 + ... + n` 的總和（等差級數 `n * (n + 1) / 2`）。
- 減去陣列中所有數字的總和，差值即為缺失的數字。
- 需注意溢位問題，但本題 n ≤ 10⁴ 在安全範圍內。

此處使用 XOR 解法實作。

## 時間複雜度
- **時間**: O(n) — 只需遍歷一次陣列
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class MissingNumber
{
    public int Solve(int[] nums)
    {
        int result = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            result ^= i ^ nums[i];
        }

        return result;
    }
}
```
