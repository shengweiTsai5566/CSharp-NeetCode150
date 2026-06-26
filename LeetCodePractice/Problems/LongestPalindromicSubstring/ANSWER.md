# Longest Palindromic Substring

## 解題思路
使用中心擴展法（Expand Around Center）。遍歷字串的每個字元（及兩個字元之間的空隙）作為回文中心，向左右兩側擴展直到不再構成回文為止。記錄最長回文的起始位置與長度。由於回文長度可為奇數（單一中心）或偶數（雙中心），需分別處理。

## 時間複雜度
- **時間**: O(n²) — n 為字串長度，每個中心最多擴展 O(n)
- **空間**: O(1) — 只使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class LongestPalindromicSubstring
{
    public string Solve(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";

        int start = 0, maxLen = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // 奇數長度回文
            int len1 = Expand(s, i, i);
            // 偶數長度回文
            int len2 = Expand(s, i, i + 1);

            int len = Math.Max(len1, len2);
            if (len > maxLen)
            {
                maxLen = len;
                start = i - (len - 1) / 2;
            }
        }

        return s.Substring(start, maxLen);
    }

    private int Expand(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }

        return right - left - 1;
    }
}
```
