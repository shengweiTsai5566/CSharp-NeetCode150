# Gas Station

## 解題思路
使用 **Greedy（貪心）** 策略。核心觀察：若從站點 `i` 出發，累積油量差（gas[i] - cost[i]）在到達站點 `j` 時變為負數，則 `i` 到 `j` 之間的任一站點都不可能是起點。

遍歷所有站點，維護 `total`（總油量差）與 `current`（當前累積量）。若 `current` 在某一站變負，將起點設為下一站並重置 `current`。最後若 `total >= 0`，則記錄的起點即為答案，否則回傳 -1。

## 時間/空間複雜度
- **時間複雜度**：O(n) — 只需一次遍歷
- **空間複雜度**：O(1) — 只使用常數空間

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class GasStation
{
    public int Solve(int[] gas, int[] cost)
    {
        int total = 0;
        int current = 0;
        int start = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            int diff = gas[i] - cost[i];
            total += diff;
            current += diff;

            if (current < 0)
            {
                start = i + 1;
                current = 0;
            }
        }

        return total >= 0 ? start : -1;
    }
}
```
