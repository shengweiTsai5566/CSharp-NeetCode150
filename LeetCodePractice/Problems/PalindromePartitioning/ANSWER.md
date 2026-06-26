# Palindrome Partitioning

## 解題思路

使用回溯法，將字串分割成若干個子字串，使得每個子字串都是回文。

**步驟：**
1. 定義遞迴函式 `Backtrack(start, current)`：
   - `start`：當前處理的起始索引
   - `current`：當前累積的回文子字串列表
2. 終止條件：若 `start == s.Length`，表示已完整分割，將 `current` 加入結果。
3. 從 `start` 到字串結尾，嘗試所有可能的子字串：
   - 檢查 `s[start..i+1]` 是否為回文
   - 若是，將該子字串加入 `current`，遞迴處理 `i + 1`
   - 回溯：移除最後加入的子字串
4. 回文判斷輔助函式：使用雙指標從兩端向中間檢查。

**最佳化：**
- 可以使用 DP 預先計算所有子字串是否為回文，將判斷時間降到 O(1)，但對於 n ≤ 16 的約束，即時判斷已足夠。

## 時間複雜度

- **時間**: O(n × 2ⁿ) — 最壞情況下每個字元間都可以切割
- **空間**: O(n) — 遞迴深度最多為 n

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class PalindromePartitioning
{
    public IList<IList<string>> Solve(string s)
    {
        var result = new List<IList<string>>();
        var current = new List<string>();
        Backtrack(s, 0, current, result);
        return result;
    }

    private void Backtrack(string s, int start, List<string> current, List<IList<string>> result)
    {
        if (start == s.Length)
        {
            result.Add(new List<string>(current));
            return;
        }

        for (int i = start; i < s.Length; i++)
        {
            if (IsPalindrome(s, start, i))
            {
                current.Add(s.Substring(start, i - start + 1));
                Backtrack(s, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] != s[right]) return false;
            left++;
            right--;
        }
        return true;
    }
}
```
