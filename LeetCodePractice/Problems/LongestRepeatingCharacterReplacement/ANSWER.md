# Longest Repeating Character Replacement

## 解題思路

使用**滑動視窗（Sliding Window）**，維護一個視窗內出現次數最多的字符頻率 `maxFreq`，視窗的大小減去 `maxFreq` 即為需要替換的字符數量。只要這個數量 ≤ k，視窗就是有效的。

方法：
1. 使用長度 26 的陣列記錄視窗內每個大寫字母的出現次數。
2. 右指針 `right` 向右擴展，每次加入新字符時更新 `maxFreq`。
3. 如果當前視窗大小 `(right - left + 1) - maxFreq > k`，表示需要替換的字符超過了 k 個，則移動左指針 `left` 縮小視窗。
4. 每一步都更新最大長度。

請注意：`maxFreq` 在歷史上的最大值即使因為視窗縮小而減少，我們也不會主動降低它。因為我們只關心**能達到的最大視窗長度**，而降低 `maxFreq` 只會讓條件更嚴格，不會幫助我們找到更大的視窗。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(1) — 固定大小的陣列（26 個字母）

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class LongestRepeatingCharacterReplacement
{
    public int Solve(string s, int k)
    {
        int[] count = new int[26];
        int left = 0, maxFreq = 0, maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            count[s[right] - 'A']++;
            maxFreq = Math.Max(maxFreq, count[s[right] - 'A']);

            // 需要替換的字符數超過 k，縮小視窗
            while ((right - left + 1) - maxFreq > k)
            {
                count[s[left] - 'A']--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}
```
