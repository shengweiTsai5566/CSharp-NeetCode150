# Reverse Bits

## 解題思路
反轉一個 32 位元無號整數的二進位表示。

逐位處理：
1. 初始化結果 `result = 0`。
2. 迭代 32 次（因為是 32 位元整數）：
   - 將 result 左移 1 位，為新的最低位騰出空間。
   - 取出 n 的最低位（`n & 1`），加到 result 的最低位。
   - 將 n 右移 1 位，處理下一位。
3. 回傳 result。

這個方法直觀且容易理解，每次處理一個位元。

## 時間複雜度
- **時間**: O(1) — 固定 32 次迭代
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ReverseBits
{
    public uint Solve(uint n)
    {
        uint result = 0;

        for (int i = 0; i < 32; i++)
        {
            result <<= 1;
            result |= (n & 1);
            n >>= 1;
        }

        return result;
    }
}
```
