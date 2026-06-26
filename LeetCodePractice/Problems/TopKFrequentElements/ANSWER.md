# Top K Frequent Elements

## 解題思路
先使用 Dictionary 統計每個數字出現的頻率。接著使用桶排序（Bucket Sort）的概念：建立一個頻率陣列 buckets，其索引為頻率，值為對應的數字列表。最後從高頻往低頻遍歷 buckets，取出前 k 個元素。

## 時間複雜度
- **時間**: O(n) — 統計頻率 O(n)，桶排序 O(n)
- **空間**: O(n) — 需要 Dictionary 和桶陣列

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class TopKFrequentElements
{
    public int[] Solve(int[] nums, int k)
    {
        var freqMap = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            freqMap[num] = freqMap.GetValueOrDefault(num, 0) + 1;
        }

        var buckets = new List<int>[nums.Length + 1];
        foreach (var kvp in freqMap)
        {
            int freq = kvp.Value;
            if (buckets[freq] == null)
                buckets[freq] = new List<int>();
            buckets[freq].Add(kvp.Key);
        }

        var result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--)
        {
            if (buckets[i] != null)
            {
                result.AddRange(buckets[i]);
            }
        }

        return result.ToArray();
    }
}
```
