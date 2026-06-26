# Sliding Window Maximum

## 解題思路
使用雙向佇列（Deque）搭配單調遞減佇列（Monotonic Queue）的技巧來維護滑動視窗內的最大值。

- 遍歷陣列時，將每個元素的**索引**加入 Deque 中。
- 當 Deque 的第一個索引已超出視窗範圍時（即 `index < i - k + 1`），將其從前端移除。
- 當新元素大於 Deque 尾端所對應的元素時，將尾端索引移除（因為它們不可能是當前或以後視窗的最大值）。
- 這樣 Deque 會始終維持前端為當前視窗的最大值的索引。
- 當 `i >= k - 1` 時，將 Deque 前端對應的值加入結果陣列。

這種方法確保每個元素最多被加入與移除 Deque 各一次，達到 O(n) 的時間複雜度。

## 時間複雜度
- **時間**: O(n) — 每個元素最多被 push 和 pop 一次
- **空間**: O(k) — Deque 最多儲存 k 個索引

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class SlidingWindowMaximum
{
    public int[] Solve(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var deque = new LinkedList<int>(); // 儲存索引，保持單調遞減
        int idx = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            // 移除超出視窗範圍的索引
            if (deque.First != null && deque.First.Value < i - k + 1)
                deque.RemoveFirst();

            // 移除所有比目前元素小的尾端索引（因為它們不可能再成為最大值）
            while (deque.Last != null && nums[deque.Last.Value] < nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            // 當視窗已形成時，記錄最大值
            if (i >= k - 1)
                result[idx++] = nums[deque.First.Value];
        }

        return result;
    }
}
```
