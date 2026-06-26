# Palindromic Substrings

## 解題思路

計算字串中所有回文子字串的數量。使用**中心擴展法**，遍歷每個可能的回文中心點，向兩側擴展來找出所有回文子字串。

**關鍵思考：**
- 回文中心可以是單一字元（奇數長度）或兩個相鄰字元（偶數長度），因此總共有 `2n - 1` 個中心點。
- 從每個中心點向左右擴展，只要左右字元相等就繼續擴展，每次找到一個回文就計數 +1。
- 這種方法可以在 O(n²) 時間內找出所有回文子字串，且空間複雜度為 O(1)。

**步驟：**
1. 初始化計數器 `count = 0`。
2. 遍歷每個字元位置 `i`：
   - 以 `i` 為中心（奇數長度），向兩側擴展。
   - 以 `i` 和 `i+1` 為中心（偶數長度），向兩側擴展。
3. 每次擴展時比較左右字元，若相等則計數 +1 並繼續擴展。
4. 回傳總計數。

## 時間複雜度

- **時間**: O(n²) — n 為字串長度，每個中心最多擴展 n 次
- **空間**: O(1) — 只使用常數額外空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class PalindromicSubstrings
{
    public int Solve(string s)
    {
        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            // 奇數長度回文（中心為單一字元）
            count += ExpandAroundCenter(s, i, i);
            // 偶數長度回文（中心為兩個相鄰字元）
            count += ExpandAroundCenter(s, i, i + 1);
        }

        return count;
    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        int count = 0;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            count++;
            left--;
            right++;
        }
        return count;
    }
}
```
