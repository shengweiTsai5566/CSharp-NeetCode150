# Decode Ways

## 解題思路

給定一個由數字組成的字串，計算有多少種方式可以將其解碼成字母（A-Z 對應 1-26）。這是一道典型的**一維動態規劃**問題。

**關鍵思考：**
- 定義 `dp[i]` 表示字串前 `i` 個字元（`s[0..i-1]`）的解碼方式數量。
- 轉移方式：
  1. **單獨解碼**：若 `s[i-1]` 是 '1' ~ '9'，則可單獨解碼為一個字母，`dp[i] += dp[i-1]`。
  2. **雙字元解碼**：若 `s[i-2..i-1]` 組成的兩位數在 10~26 之間，則可合併解碼，`dp[i] += dp[i-2]`。
- 初始條件：`dp[0] = 1`（空字串有一種解碼方式），`dp[1]` 取決於第一個字元是否為 '0'。
- 若遇到無法解碼的情況（如 '0' 開頭且無法與前一個字元組成有效兩位數），則 `dp[i] = 0`。

**步驟：**
1. 建立長度為 `n + 1` 的 DP 陣列。
2. 設定 `dp[0] = 1`。
3. 遍歷 `i` 從 1 到 `n`：
   - 若 `s[i-1] != '0'`，則 `dp[i] += dp[i-1]`。
   - 若 `i >= 2` 且 `s[i-2..i-1]` 在 10~26 之間，則 `dp[i] += dp[i-2]`。
4. 回傳 `dp[n]`。

## 時間複雜度

- **時間**: O(n) — 一次遍歷
- **空間**: O(n) — 可優化為 O(1) 只用兩個變數

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class DecodeWays
{
    public int Solve(string s)
    {
        if (string.IsNullOrEmpty(s) || s[0] == '0') return 0;

        int n = s.Length;
        int prev2 = 1; // dp[i-2]
        int prev1 = 1; // dp[i-1]

        for (int i = 2; i <= n; i++)
        {
            int cur = 0;

            // 單獨解碼當前字元
            if (s[i - 1] != '0')
                cur += prev1;

            // 雙字元解碼
            int twoDigit = int.Parse(s.Substring(i - 2, 2));
            if (twoDigit >= 10 && twoDigit <= 26)
                cur += prev2;

            prev2 = prev1;
            prev1 = cur;
        }

        return prev1;
    }
}
```
