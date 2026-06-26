# Minimum Window Substring

## 解題思路

使用**滑動視窗（Sliding Window）** 搭配兩個計數器來尋找包含 `t` 所有字符（含重複）的最短子字串。

方法：
1. 先用一個 Dictionary（或長度 128 的陣列）記錄 `t` 中各字符的需求量 `need`。
2. 用 `have` 變數追蹤當前視窗中已滿足多少種字符的需求。
3. 右指針 `right` 向右擴展視窗：
   - 若當前字符在 `need` 中，則增加 `windowCount`，當該字符的視窗計數達到需求時，`have++`。
4. 當 `have == need.Count`（所有字符都滿足）時，嘗試收縮左指針 `left`：
   - 更新最小長度和起始位置。
   - 移出左邊字符，若該字符在 `need` 中且計數低於需求，`have--`。
5. 最終回傳最短子字串；若未找到則回傳空字串。

此法時間複雜度 O(n + m)，空間複雜度 O(k)，其中 k 為字符集大小。

## 時間複雜度

- **時間**: O(n + m) — n 為 s 長度，m 為 t 長度
- **空間**: O(k) — k 為不同字符數（最多 128）

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MinimumWindowSubstring
{
    public string Solve(string s, string t)
    {
        if (string.IsNullOrEmpty(t)) return "";

        var need = new Dictionary<char, int>();
        foreach (char c in t)
        {
            if (need.ContainsKey(c))
                need[c]++;
            else
                need[c] = 1;
        }

        var window = new Dictionary<char, int>();
        int have = 0, needCount = need.Count;
        int left = 0, minLen = int.MaxValue, start = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];

            if (window.ContainsKey(c))
                window[c]++;
            else
                window[c] = 1;

            if (need.ContainsKey(c) && window[c] == need[c])
                have++;

            // 嘗試收縮視窗
            while (have == needCount)
            {
                int curLen = right - left + 1;
                if (curLen < minLen)
                {
                    minLen = curLen;
                    start = left;
                }

                char leftChar = s[left];
                window[leftChar]--;

                if (need.ContainsKey(leftChar) && window[leftChar] < need[leftChar])
                    have--;

                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
    }
}
```
