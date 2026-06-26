# Generate Parentheses

## 解題思路
使用回溯法（Backtracking / DFS）來生成所有合法的括號組合。

定義一個遞迴函式，參數包含：
- `current`：當前已組建的字串
- `open`：已使用的左括號 `(` 數量
- `close`：已使用的右括號 `)` 數量

遞迴規則：
1. 如果 `open < n`，可以加入左括號 `(`。
2. 如果 `close < open`，可以加入右括號 `)`（這樣才能保證括號是合法匹配的）。
3. 當 `current.Length == 2 * n` 時，表示已生成一組完整合法的組合，加入結果列表。

這種方式確保只會生成合法的括號組合，無需事後驗證。

## 時間複雜度
- **時間**: O(4^n / sqrt(n)) — 這是第 n 個卡塔蘭數（Catalan number）的時間複雜度，即所有合法組合的數量
- **空間**: O(n) — 遞迴深度最多為 2n，結果空間不計入

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class GenerateParentheses
{
    public IList<string> Solve(int n)
    {
        var result = new List<string>();
        Backtrack(result, "", 0, 0, n);
        return result;
    }

    private void Backtrack(List<string> result, string current, int open, int close, int n)
    {
        if (current.Length == 2 * n)
        {
            result.Add(current);
            return;
        }

        if (open < n)
            Backtrack(result, current + "(", open + 1, close, n);

        if (close < open)
            Backtrack(result, current + ")", open, close + 1, n);
    }
}
```
