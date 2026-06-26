# Single Number

## 解題思路
給定一個非空整數陣列，除了某個元素只出現一次外，其餘每個元素都出現兩次。找出那個只出現一次的元素。

使用 **XOR（互斥或）** 運算：
- XOR 的性質：
  - `a ^ a = 0`（相同數字 XOR 為 0）
  - `a ^ 0 = a`（任何數字與 0 XOR 為其本身）
  - XOR 滿足交換律和結合律
- 因此將所有數字 XOR 起來，出現兩次的數字會互相抵消為 0，最後剩下的就是只出現一次的數字。

這個方法滿足題目要求的線性時間複雜度和常數空間。

## 時間複雜度
- **時間**: O(n) — 只需遍歷一次陣列
- **空間**: O(1) — 僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class SingleNumber
{
    public int Solve(int[] nums)
    {
        int result = 0;
        foreach (int num in nums)
        {
            result ^= num;
        }
        return result;
    }
}
```
