# Product of Array Except Self

## 解題思路
使用前綴乘積與後綴乘積的概念，不需使用除法。建立一個結果陣列，第一次從左到右遍歷，計算每個位置左側所有元素的乘積。第二次從右到左遍歷，乘上每個位置右側所有元素的乘積。如此 answer[i] 即為 nums[i] 以外所有元素的乘積。

## 時間複雜度
- **時間**: O(n) — 只需遍歷陣列兩次
- **空間**: O(1) — 除輸出陣列外僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ProductOfArrayExceptSelf
{
    public int[] Solve(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        // 計算左側乘積
        result[0] = 1;
        for (int i = 1; i < n; i++)
        {
            result[i] = result[i - 1] * nums[i - 1];
        }

        // 乘上右側乘積
        int rightProduct = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] *= rightProduct;
            rightProduct *= nums[i];
        }

        return result;
    }
}
```
