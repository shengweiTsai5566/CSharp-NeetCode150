# Permutation in String

## 解題思路

使用**滑動視窗（Sliding Window）** 搭配字符計數陣列來判斷 `s2` 中是否存在一個子字串是 `s1` 的排列。

方法：
1. 用一個長度 26 的陣列 `s1Count` 記錄 `s1` 中各字母的出現次數。
2. 用另一個陣列 `s2Count` 記錄 `s2` 中當前滑動視窗內各字母的出現次數。
3. 滑動視窗大小固定為 `s1.Length`：
   - 先初始化前 `s1.Length` 個字符的計數。
   - 如果兩個計數陣列相等，表示找到了排列，回傳 `true`。
   - 每次滑動時，移除左邊字符並加入右邊新字符，更新 `s2Count` 後再次比對。
4. 遍歷結束若未找到則回傳 `false`。

比對兩個長度 26 的陣列是否相等是 O(26) = O(1) 的操作。

## 時間複雜度

- **時間**: O(n) — n 為 s2 的長度，每次滑動 O(1) 更新和比對
- **空間**: O(1) — 兩個固定大小的陣列（26 個字母）

## 程式碼

```csharp
using System;
using System.Linq;

namespace LeetCodePractice.Problems;

public class PermutationInString
{
    public bool Solve(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;

        int[] s1Count = new int[26];
        int[] s2Count = new int[26];

        // 初始化第一個視窗
        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        // 比對第一個視窗
        if (s1Count.SequenceEqual(s2Count)) return true;

        // 滑動視窗
        for (int i = s1.Length; i < s2.Length; i++)
        {
            s2Count[s2[i] - 'a']++;          // 加入右邊新字符
            s2Count[s2[i - s1.Length] - 'a']--; // 移除左邊字符

            if (s1Count.SequenceEqual(s2Count))
                return true;
        }

        return false;
    }
}
```
