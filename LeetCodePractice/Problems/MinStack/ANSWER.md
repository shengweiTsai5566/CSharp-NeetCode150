# Min Stack

## 解題思路
為了在常數時間內取得最小值，可以使用兩個堆疊來實作：

1. **主堆疊（`_stack`）**：儲存所有 push 進來的元素。
2. **最小值堆疊（`_minStack`）**：同步記錄當前的最小值。

每次 `Push(val)` 時：
- 將 `val` 推入 `_stack`。
- 如果 `_minStack` 為空，或 `val` 小於等於當前最小值，則也將 `val` 推入 `_minStack`。

每次 `Pop()` 時：
- 從 `_stack` 彈出元素。
- 如果彈出的元素等於 `_minStack` 的頂端（即當前最小值），則也將 `_minStack` 頂端彈出。

這樣 `GetMin()` 只需回傳 `_minStack` 頂端的值即可，保證所有操作皆為 O(1)。

## 時間複雜度
- **時間**: O(1) — 每個操作均為常數時間
- **空間**: O(n) — 需要兩個堆疊，總共最多儲存 2n 個元素

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class MinStack
{
    private readonly Stack<int> _stack;
    private readonly Stack<int> _minStack;

    public MinStack()
    {
        _stack = new Stack<int>();
        _minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        _stack.Push(val);
        if (_minStack.Count == 0 || val <= _minStack.Peek())
            _minStack.Push(val);
    }

    public void Pop()
    {
        if (_stack.Count == 0) return;
        if (_stack.Pop() == _minStack.Peek())
            _minStack.Pop();
    }

    public int Top()
    {
        return _stack.Peek();
    }

    public int GetMin()
    {
        return _minStack.Peek();
    }
}
```
