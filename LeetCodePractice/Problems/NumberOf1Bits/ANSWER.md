# Number of 1 Bits

## 解題思路
給定一個正整數，計算其二進位表示中 1 的個數（又稱漢明重量）。

方法一：**逐位檢查**（最直觀）
- 逐位檢查 n 的最低位是否為 1，然後右移一位，重複 32 次。

方法二：**`n & (n - 1)` 優化**
- `n & (n - 1)` 會將 n 的最低位的 1 翻轉為 0。
- 重複此操作直到 n 為 0，操作的次數即為 1 的個數。
- 當 1 的數量遠少於位數時效率更高。

此處使用方法二實作。

## 時間複雜度
- **時間**: O(k) — k 為 1 的位元個數，最多 32
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class NumberOf1Bits
{
    public int Solve(int n)
    {
        int count = 0;
        while (n != 0)
        {
            n &= (n - 1);
            count++;
        }
        return count;
    }
}
```
