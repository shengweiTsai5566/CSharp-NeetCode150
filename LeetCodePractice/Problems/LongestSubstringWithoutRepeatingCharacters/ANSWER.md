# Longest Substring Without Repeating Characters

## 解題思路

使用**滑動視窗（Sliding Window）** 搭配 HashSet 來維護一個不含重複字符的子字串。

方法：
1. 使用 `left` 指針標記視窗的左邊界，`right` 指針向右擴展。
2. 用一個 `HashSet<char>` 記錄當前視窗內出現過的字符。
3. 當 `right` 指向的字符不在集合中時，加入集合並更新最大長度。
4. 當遇到重複字符時，從左邊界開始逐步移除字符並移動 `left`，直到重複字符被移除為止。
5. 重複直到 `right` 遍歷完整個字串。

另一種更高效的變體是使用 Dictionary 記錄每個字符最近出現的位置，可以直接將 left 跳到重複位置的下一個，無需逐步移除。

## 時間複雜度

- **時間**: O(n) — 每個字符最多被訪問兩次（一次加入、一次移除）
- **空間**: O(min(m, n)) — m 為字符集大小，n 為字串長度

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class LongestSubstringWithoutRepeatingCharacters
{
    public int Solve(string s)
    {
        var charSet = new HashSet<char>();
        int left = 0, maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            // 如果遇到重複字符，移動左指針直到重複被移除
            while (charSet.Contains(s[right]))
            {
                charSet.Remove(s[left]);
                left++;
            }

            charSet.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
```
