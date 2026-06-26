# Partition Labels

## 解題思路
使用 **Greedy（貪心）** + **兩次掃描**。先遍歷字串一次，記錄每個字母最後出現的位置。然後再次遍歷字串，維護當前段落的結束邊界 `end`。對於當前位置 `i`，將 `end` 更新為 `max(end, last[s[i]])`。當 `i == end` 時，表示當前段落已完整，將段落長度加入結果並重置起點。

這個策略保證每個字母只會出現在同一個段落中，且段落數量最大化。

## 時間/空間複雜度
- **時間複雜度**：O(n) — 兩次遍歷，n 為字串長度
- **空間複雜度**：O(1) — 固定大小的陣列（26 個小寫字母）

## 程式碼

```csharp
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class PartitionLabels
{
    public IList<int> Solve(string s)
    {
        var last = new int[26];
        for (int i = 0; i < s.Length; i++)
            last[s[i] - 'a'] = i;

        var result = new List<int>();
        int start = 0, end = 0;

        for (int i = 0; i < s.Length; i++)
        {
            end = System.Math.Max(end, last[s[i] - 'a']);

            if (i == end)
            {
                result.Add(i - start + 1);
                start = i + 1;
            }
        }

        return result;
    }
}
```
