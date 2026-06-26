# Largest Rectangle in Histogram

## 解題思路
使用單調遞增堆疊（Monotonic Increasing Stack）來找出每個長條可以延伸的最大寬度，從而計算最大的矩形面積。

核心概念：對於每個長條 `heights[i]`，找出其**左邊第一個比它矮的位置**和**右邊第一個比它矮的位置**，則以該長條高度所能形成的最大矩形寬度即為 `right - left - 1`。

實作方式：
- 堆疊中儲存索引，且保持對應的高度為遞增。
- 在原始陣列末端加入一個高度為 0 的虛擬長條，以強制在最後將所有長條彈出計算。
- 遍歷每個長條：
  - 當目前高度 `heights[i]` 小於堆疊頂端索引對應的高度時，表示找到了右邊界：
    - 彈出堆疊頂端索引 `hIndex`，高度為 `heights[hIndex]`。
    - 寬度為 `i - (stack.Count > 0 ? stack.Peek() : -1) - 1`。
    - 計算面積並更新最大值。
  - 將當前索引推入堆疊。

## 時間複雜度
- **時間**: O(n) — 每個索引最多被 push 和 pop 一次
- **空間**: O(n) — 需要一個堆疊

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class LargestRectangleInHistogram
{
    public int Solve(int[] heights)
    {
        int n = heights.Length;
        var stack = new Stack<int>();
        int maxArea = 0;

        // 在陣列末端加入高度為 0 的虛擬長條
        var extended = new int[n + 1];
        Array.Copy(heights, extended, n);
        extended[n] = 0;

        for (int i = 0; i <= n; i++)
        {
            while (stack.Count > 0 && extended[i] < extended[stack.Peek()])
            {
                int h = extended[stack.Pop()];
                int left = stack.Count > 0 ? stack.Peek() : -1;
                int width = i - left - 1;
                maxArea = Math.Max(maxArea, h * width);
            }
            stack.Push(i);
        }

        return maxArea;
    }
}
```
