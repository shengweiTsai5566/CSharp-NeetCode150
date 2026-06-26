# Daily Temperatures

## 解題思路
使用單調遞減堆疊（Monotonic Decreasing Stack）來找出每個溫度之後第一個更高的溫度的距離。

- 堆疊中儲存的是**索引**，且保持溫度值從堆疊底到頂端為遞減（即溫度由高到低）。
- 遍歷 `temperatures` 陣列：
  - 當目前溫度 `temperatures[i]` 大於堆疊頂端索引所對應的溫度時，表示找到了該索引的答案：
    - 彈出堆疊頂端索引 `prevIndex`。
    - `answer[prevIndex] = i - prevIndex`。
  - 將當前索引 `i` 推入堆疊。
- 遍歷結束後，堆疊中剩餘的索引皆無法找到更高溫度，其 `answer` 值預設為 0。

這個方法保證每個索引只會被推入和彈出堆疊各一次。

## 時間複雜度
- **時間**: O(n) — 每個索引最多被 push 和 pop 一次
- **空間**: O(n) — 需要一個堆疊和結果陣列

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class DailyTemperatures
{
    public int[] Solve(int[] temperatures)
    {
        int n = temperatures.Length;
        var result = new int[n];
        var stack = new Stack<int>(); // 儲存索引，保持溫度單調遞減

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int prevIndex = stack.Pop();
                result[prevIndex] = i - prevIndex;
            }
            stack.Push(i);
        }

        return result;
    }
}
```
