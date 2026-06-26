# Insert Interval

## 解題思路
使用 **區間合併** 技巧。遍歷原有的非重疊區間，分為三個階段處理：

1. **插入前**：所有 `end < newInterval[0]` 的區間直接加入結果（完全不重疊且在左側）。
2. **合併中**：所有與 `newInterval` 重疊的區間（`start <= newInterval[1]`），持續合併更新 `newInterval` 的起點與終點。
3. **插入後**：將合併後的區間加入結果，再將其餘剩餘區間全部加入。

## 時間/空間複雜度
- **時間複雜度**：O(n) — 一次遍歷所有區間
- **空間複雜度**：O(n) — 儲存結果陣列

## 程式碼

```csharp
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class InsertInterval
{
    public int[][] Solve(int[][] intervals, int[] newInterval)
    {
        var result = new List<int[]>();
        int i = 0;
        int n = intervals.Length;

        // 加入所有在 newInterval 左側且不重疊的區間
        while (i < n && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }

        // 合併所有與 newInterval 重疊的區間
        while (i < n && intervals[i][0] <= newInterval[1])
        {
            newInterval[0] = System.Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = System.Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }
        result.Add(newInterval);

        // 加入剩餘的區間
        while (i < n)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }
}
```
