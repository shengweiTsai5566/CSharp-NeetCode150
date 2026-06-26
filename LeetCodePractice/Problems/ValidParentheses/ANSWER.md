# Valid Parentheses

## 解題思路
使用堆疊（Stack）來匹配括號。遍歷字串中的每個字元：

- 當遇到左括號 `(`, `{`, `[` 時，將其對應的右括號 `)`, `}`, `]` 推入堆疊。
- 當遇到右括號時，檢查堆疊頂端是否為相同類型的括號：
  - 若堆疊為空或頂端不匹配，則回傳 `false`。
  - 若匹配，則將堆疊頂端彈出。
- 遍歷結束後，若堆疊為空則表示所有括號都有正確匹配，回傳 `true`；否則回傳 `false`。

## 時間複雜度
- **時間**: O(n) — 只需遍歷一次字串
- **空間**: O(n) — 最壞情況下堆疊需要儲存 n 個左括號

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class ValidParentheses
{
    public bool Solve(string s)
    {
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(')
                stack.Push(')');
            else if (c == '{')
                stack.Push('}');
            else if (c == '[')
                stack.Push(']');
            else if (stack.Count == 0 || stack.Pop() != c)
                return false;
        }

        return stack.Count == 0;
    }
}
```
