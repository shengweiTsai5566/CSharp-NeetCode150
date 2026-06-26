# Pow(x, n)

## 解題思路
實作 `pow(x, n)` 計算 x 的 n 次方。

使用**快速冪（Binary Exponentiation）**演算法：
1. 若 n 為負數，將問題轉換為計算 `1 / pow(x, -n)`（需注意 n 可能為 int.MinValue 的邊界情況，先轉為 long 避免溢位）。
2. 使用二分法概念：`x^n = (x^(n/2))^2`。
3. 迭代版本：將 n 視為二進位，從最低位開始處理：
   - 若當前位為 1，將 result 乘以當前的冪值。
   - 將冪值平方（x = x * x）。
   - n 右移一位。
4. 重複直到 n 為 0。

## 時間複雜度
- **時間**: O(log n) — 每次迭代 n 減半
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class PowXN
{
    public double Solve(double x, int n)
    {
        long N = n;
        if (N < 0)
        {
            x = 1 / x;
            N = -N;
        }

        double result = 1.0;
        double currentProduct = x;

        while (N > 0)
        {
            if ((N & 1) == 1)
            {
                result *= currentProduct;
            }
            currentProduct *= currentProduct;
            N >>= 1;
        }

        return result;
    }
}
```
