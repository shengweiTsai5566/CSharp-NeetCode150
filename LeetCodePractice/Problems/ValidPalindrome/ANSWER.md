# Valid Palindrome

## 解題思路

使用**雙指針（Two Pointers）** 從字串的頭尾向中間遍歷。跳過所有非字母數字的字符（包括空格、標點符號等），然後將字母轉為小寫進行比對。如果任何一次比對不相等，則回傳 `false`；若指針相遇則表示所有字符都匹配，回傳 `true`。

此方法只需一次遍歷且不使用額外空間（不建立新的字串），符合題目的要求。

## 時間複雜度

- **時間**: O(n) — 每個字符最多被訪問一次
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ValidPalindrome
{
    public bool Solve(string s)
    {
        int left = 0, right = s.Length - 1;

        while (left < right)
        {
            // 跳過左邊的非字母數字字符
            while (left < right && !char.IsLetterOrDigit(s[left]))
                left++;
            // 跳過右邊的非字母數字字符
            while (left < right && !char.IsLetterOrDigit(s[right]))
                right--;

            // 比對（忽略大小寫）
            if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }
}
```
