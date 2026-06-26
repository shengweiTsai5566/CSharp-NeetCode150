# Valid Anagram

## 解題思路
若兩字串長度不同，則直接回傳 false。使用一個長度為 26 的整數陣列（對應 26 個小寫字母）來計數。遍歷字串 s 時將對應字母計數加一，遍歷字串 t 時將計數減一。最後檢查陣列中是否所有值都為 0。

## 時間複雜度
- **時間**: O(n) — 需要遍歷兩個字串各一次
- **空間**: O(1) — 使用固定大小的陣列（26 個整數）

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ValidAnagram
{
    public bool Solve(string s, string t)
    {
        if (s.Length != t.Length) return false;

        var count = new int[26];

        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a']++;
            count[t[i] - 'a']--;
        }

        foreach (int c in count)
        {
            if (c != 0) return false;
        }

        return true;
    }
}
```
