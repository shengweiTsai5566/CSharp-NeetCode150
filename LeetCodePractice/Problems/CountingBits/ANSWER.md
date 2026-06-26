# Counting Bits

## 解題思路
給定整數 n，回傳長度為 n + 1 的陣列 `ans`，其中 `ans[i]` 為 i 的二進位表示中 1 的個數。

使用**動態規劃（DP）**：觀察二進位中的規律
- 對於任意數字 i，其二進位表示中 1 的個數可以透過 `i >> 1`（即 i/2）來推導：
  - `ans[i] = ans[i >> 1] + (i & 1)`
  - `i >> 1` 是 i 去掉最低位後的數字，其 1 的個數已經計算過。
  - `i & 1` 表示 i 的最低位是否為 1。

例如：
- i = 5 (101)：`ans[5] = ans[2] + 1 = 1 + 1 = 2`
- i = 6 (110)：`ans[6] = ans[3] + 0 = 2 + 0 = 2`

## 時間複雜度
- **時間**: O(n) — 線性時間一次遍歷
- **空間**: O(1) — 不計輸出陣列，僅使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class CountingBits
{
    public int[] Solve(int n)
    {
        int[] ans = new int[n + 1];

        for (int i = 1; i <= n; i++)
        {
            ans[i] = ans[i >> 1] + (i & 1);
        }

        return ans;
    }
}
```
