# Word Break

## 解題思路

給定一個字串和一個字典，判斷字串是否可以分割成一個或多個字典中的單詞。使用**一維動態規劃**來解決。

**關鍵思考：**
- 定義 `dp[i]` 表示字串 `s[0..i-1]` 是否可以被成功分割。
- `dp[0] = true`（空字串可以被分割）。
- 對於每個位置 `i`，檢查所有 `j < i`：
  - 若 `dp[j] == true` 且 `s[j..i-1]` 存在於字典中，則 `dp[i] = true`。
- 為了加快子字串查詢速度，將字典轉為 `HashSet`。

**步驟：**
1. 將 `wordDict` 轉換為 `HashSet<string>`。
2. 建立長度為 `n + 1` 的 `bool` 陣列 `dp`，`dp[0] = true`。
3. 遍歷 `i` 從 1 到 `n`：
   - 遍歷 `j` 從 0 到 `i - 1`：
     - 若 `dp[j]` 為 `true` 且 `s[j..i]` 在字典中，設定 `dp[i] = true` 並跳出內層迴圈。
4. 回傳 `dp[n]`。

## 時間複雜度

- **時間**: O(n²) — 雙層迴圈；子字串查詢為 O(1)
- **空間**: O(n + m) — n 為 DP 陣列長度，m 為字典大小

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class WordBreak
{
    public bool Solve(string s, IList<string> wordDict)
    {
        HashSet<string> wordSet = new HashSet<string>(wordDict);
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[0] = true;

        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && wordSet.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[n];
    }
}
```
