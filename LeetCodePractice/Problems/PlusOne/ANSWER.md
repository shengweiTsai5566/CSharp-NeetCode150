# Plus One

## 解題思路
給定一個以陣列表示的大整數（每個元素為一位數），將其加 1 後回傳。

從陣列的**最低位（最後一位）**開始處理：
1. 從最後一位往前遍歷，將當前位數加 1。
2. 若加 1 後小於 10，則直接回傳結果（無進位）。
3. 若加 1 後等於 10，則將該位設為 0，並繼續往前處理進位。
4. 若遍歷完整個陣列仍有進位（例如 999 → 1000），則建立一個新陣列，第一個元素為 1，其餘為 0。

## 時間複雜度
- **時間**: O(n) — 在最壞情況下需遍歷整個陣列
- **空間**: O(1) — 一般情況為原地修改；只有在全為 9 時需 O(n) 額外空間建立新陣列

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class PlusOne
{
    public int[] Solve(int[] digits)
    {
        int n = digits.Length;

        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }
            digits[i] = 0;
        }

        // 全部為 9，例如 [9,9,9] → [1,0,0,0]
        int[] result = new int[n + 1];
        result[0] = 1;
        return result;
    }
}
```
