# Valid Parenthesis String

## 解題思路
使用 **Greedy（貪心）** 策略，維護兩個變數 `min` 和 `max`，分別代表當前未匹配左括號的最小可能數量和最大可能數量。

遍歷字串：
- 遇到 `'('`：`min++`、`max++`
- 遇到 `')'`：`min--`、`max--`
- 遇到 `'*'`：可作為 `'('`、`')'` 或空字串，所以 `min--`（當作 `)`）、`max++`（當作 `(`）

過程中若 `max < 0` 則回傳 `false`。若 `min < 0`，將其重置為 0（因為不能有負數個未匹配左括號）。最後檢查 `min == 0`。

## 時間/空間複雜度
- **時間複雜度**：O(n) — 一次遍歷
- **空間複雜度**：O(1) — 只使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class ValidParenthesisString
{
    public bool Solve(string s)
    {
        int min = 0, max = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                min++;
                max++;
            }
            else if (c == ')')
            {
                min--;
                max--;
            }
            else // '*'
            {
                min--;
                max++;
            }

            if (max < 0) return false;
            if (min < 0) min = 0;
        }

        return min == 0;
    }
}
```
