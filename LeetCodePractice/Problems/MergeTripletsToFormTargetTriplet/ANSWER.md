# Merge Triplets to Form Target Triplet

## 解題思路
使用 **Greedy（貪心）** 策略。關鍵觀察：合併操作只會取每個位置的最大值，所以我們只能得到每個位置不大於原始值中最大值的結果。

遍歷所有 triplets，篩選出「每個元素都不超過 target 對應值」的 triplets（即不會引入超出 target 的值）。對於這些合格的 triplets，逐步記錄每個位置能達到的最大值。若最終三個位置都能達到 target 的值，則回傳 `true`；否則回傳 `false`。

## 時間/空間複雜度
- **時間複雜度**：O(n) — 只需一次遍歷
- **空間複雜度**：O(1) — 只使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class MergeTripletsToFormTargetTriplet
{
    public bool Solve(int[][] triplets, int[] target)
    {
        int x = 0, y = 0, z = 0;

        foreach (var t in triplets)
        {
            if (t[0] <= target[0] && t[1] <= target[1] && t[2] <= target[2])
            {
                x = Math.Max(x, t[0]);
                y = Math.Max(y, t[1]);
                z = Math.Max(z, t[2]);
            }
        }

        return x == target[0] && y == target[1] && z == target[2];
    }
}
```
