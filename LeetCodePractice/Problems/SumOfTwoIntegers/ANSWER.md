# Sum of Two Integers

## 解題思路
給定兩個整數 a 和 b，在不使用 `+` 和 `-` 運算子的情況下計算兩數之和。

使用**位元運算**模擬加法：
1. **XOR（`a ^ b`）**：計算無進位的加法。
2. **AND 左移一位（`(a & b) << 1`）**：計算進位。
3. 將 XOR 結果作為新的 a，進位結果作為新的 b，重複直到進位為 0。

以 `a = 2 (010), b = 3 (011)` 為例：
- 第一次：`xor = 001`, `carry = 100` → a = 1, b = 4
- 第二次：`xor = 101`, `carry = 000` → a = 5, b = 0 → 回傳 5

需注意 C# 中整數為帶號補數，左移負數進位可能導致無窮迴圈，因此需將進位轉為無號整數處理。

## 時間複雜度
- **時間**: O(1) — 最多 32 次迭代（固定位數）
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class SumOfTwoIntegers
{
    public int Solve(int a, int b)
    {
        while (b != 0)
        {
            int carry = (a & b) << 1;
            a ^= b;
            b = carry;
        }
        return a;
    }
}
```
