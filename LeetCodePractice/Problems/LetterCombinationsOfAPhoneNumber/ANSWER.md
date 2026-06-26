# Letter Combinations of a Phone Number

## 解題思路

使用回溯法，根據電話按鍵的數字到字母的對應關係，產生所有可能的字母組合。

**步驟：**
1. 建立數字到字母的對應表（如 `'2' -> "abc"`）。
2. 定義遞迴函式 `Backtrack(index, current)`：
   - `index`：當前處理的數字位置
   - `current`：當前累積的字串
3. 終止條件：若 `index == digits.Length`，將 `current` 加入結果。
4. 取得 `digits[index]` 對應的所有字母，對每個字母：
   - 將其附加到 `current`
   - 遞迴處理下一個數字
   - 回溯：移除最後加入的字母
5. 邊界處理：若輸入為空字串，直接回傳空串列。

## 時間複雜度

- **時間**: O(4ⁿ) — n 為 digits 長度，每個數字最多對應 4 個字母
- **空間**: O(n) — 遞迴深度最多為 n

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class LetterCombinationsOfAPhoneNumber
{
    private static readonly string[] DigitToLetters = {
        "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"
    };

    public IList<string> Solve(string digits)
    {
        var result = new List<string>();
        if (string.IsNullOrEmpty(digits)) return result;
        Backtrack(digits, 0, "", result);
        return result;
    }

    private void Backtrack(string digits, int index, string current, List<string> result)
    {
        if (index == digits.Length)
        {
            result.Add(current);
            return;
        }

        string letters = DigitToLetters[digits[index] - '0'];
        for (int i = 0; i < letters.Length; i++)
        {
            Backtrack(digits, index + 1, current + letters[i], result);
        }
    }
}
```
