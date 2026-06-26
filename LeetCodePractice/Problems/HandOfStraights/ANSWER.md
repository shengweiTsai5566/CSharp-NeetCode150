# Hand of Straights

## 解題思路
使用 **Greedy（貪心）** + **有序字典（SortedDictionary）**。若牌數無法被 `groupSize` 整除，直接回傳 `false`。

否則，統計每張牌的出現次數到 `SortedDictionary` 中。每次從最小的牌開始，嘗試組成連續 `groupSize` 張牌的群組。若缺少任一需要的牌，則回傳 `false`；否則將對應的計數減一，若計數歸零則移除該鍵值。

另一種解法是使用最小堆（Min-Heap）來取得最小值，但 C# 的 `SortedDictionary` 可直接取得最小鍵值，更方便。

## 時間/空間複雜度
- **時間複雜度**：O(n log n) — 排序或使用有序映射
- **空間複雜度**：O(n) — 儲存每張牌的計數

## 程式碼

```csharp
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class HandOfStraights
{
    public bool Solve(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0) return false;

        var count = new SortedDictionary<int, int>();
        foreach (int card in hand)
        {
            count.TryGetValue(card, out int c);
            count[card] = c + 1;
        }

        foreach (var key in count.Keys.ToList())
        {
            if (count[key] == 0) continue;

            int freq = count[key];
            for (int i = 0; i < groupSize; i++)
            {
                int cur = key + i;
                if (!count.ContainsKey(cur) || count[cur] < freq)
                    return false;
                count[cur] -= freq;
            }
        }

        return true;
    }
}
```
