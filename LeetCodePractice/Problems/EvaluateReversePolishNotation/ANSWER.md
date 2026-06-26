# Evaluate Reverse Polish Notation

## 解題思路
使用堆疊（Stack）來計算逆波蘭表達式（後序表達式）。遍歷 tokens：

- 如果當前 token 是運算子 `+`, `-`, `*`, `/`，則從堆疊中彈出兩個數字進行計算，再將結果推回堆疊。
  - 注意：先彈出的是**右運算元**，後彈出的是**左運算元**。
  - 除法需要向零截斷（truncate toward zero）：C# 中整數除法對正數會自動截斷，但對負數需用 `(int)((double)a / b)` 處理。
- 如果當前 token 是數字，則轉換為整數後推入堆疊。
- 遍歷結束後，堆疊頂端即為最終結果。

## 時間複雜度
- **時間**: O(n) — 只需遍歷一次 tokens
- **空間**: O(n) — 堆疊最多儲存 n 個數字

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class EvaluateReversePolishNotation
{
    public int Solve(string[] tokens)
    {
        var stack = new Stack<int>();

        foreach (string token in tokens)
        {
            if (token is "+" or "-" or "*" or "/")
            {
                int b = stack.Pop();
                int a = stack.Pop();

                int result = token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b, // C# 整數除法已向零截斷
                    _ => 0
                };

                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }
}
```
