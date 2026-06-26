# Multiply Strings

## 解題思路
給定兩個以字串表示的非負整數（不可使用 BigInteger 或直接轉為整數），回傳其乘積的字串。

模擬**直式乘法**：
1. 建立一個長度為 `len(num1) + len(num2)` 的整數陣列 `result` 來存放每一位的乘積（乘積的位數最多為兩數位數之和）。
2. 從 num1 和 num2 的**最低位（最右邊）**開始雙層遍歷：
   - `product = (num1[i] - '0') * (num2[j] - '0')`
   - 將 product 加到 `result[i + j + 1]` 位置。
   - 處理進位：`result[i + j] += result[i + j + 1] / 10`，`result[i + j + 1] %= 10`。
3. 跳過結果陣列前導的 0，將剩餘部分轉為字串回傳。
4. 若結果為空（全部是 0），則回傳 "0"。

## 時間複雜度
- **時間**: O(m × n) — m 和 n 分別為兩字串的長度
- **空間**: O(m + n) — 存放乘積結果的陣列

## 程式碼

```csharp
using System;
using System.Text;

namespace LeetCodePractice.Problems;

public class MultiplyStrings
{
    public string Solve(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        int m = num1.Length, n = num2.Length;
        int[] result = new int[m + n];

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                int product = (num1[i] - '0') * (num2[j] - '0');
                int sum = product + result[i + j + 1];
                result[i + j + 1] = sum % 10;
                result[i + j] += sum / 10;
            }
        }

        var sb = new StringBuilder();
        int idx = 0;
        while (idx < result.Length && result[idx] == 0)
            idx++;

        while (idx < result.Length)
            sb.Append(result[idx++]);

        return sb.Length == 0 ? "0" : sb.ToString();
    }
}
```
