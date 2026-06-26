# Car Fleet

## 解題思路
將車輛按位置從大到小（靠近目標到遠離目標）排序，然後從最近到最遠依序計算每輛車到達目標所需的時間。

- 對每輛車計算其到達目標所需的時間：`time = (target - position) / speed`。
- 從最靠近目標的車開始往後遍歷：
  - 如果當前車的到達時間大於堆疊頂端（前一輛車的到達時間），則表示它無法追上前面那輛車，因此會形成一個新的車隊。
  - 否則，它會追上前面那輛車並與之合併為同一車隊（速度由較慢的車決定）。
- 可以用堆疊來實作，堆疊的大小即為車隊的數量。

簡化版本：不需真正用堆疊，只需一個變數記錄前一輛車的到達時間，並計算車隊數量即可。

## 時間複雜度
- **時間**: O(n log n) — 排序需要 O(n log n)
- **空間**: O(n) — 需要儲存 position-speed 配對

## 程式碼

```csharp
using System;

namespace LeetCodePractice.Problems;

public class CarFleet
{
    public int Solve(int target, int[] position, int[] speed)
    {
        int n = position.Length;
        var cars = new (int pos, double time)[n];

        for (int i = 0; i < n; i++)
        {
            cars[i] = (position[i], (double)(target - position[i]) / speed[i]);
        }

        // 按位置從大到小排序（離目標最近的優先）
        Array.Sort(cars, (a, b) => b.pos.CompareTo(a.pos));

        int fleets = 0;
        double currentMaxTime = 0;

        foreach (var (_, time) in cars)
        {
            // 如果當前車到達時間比前面車隊更長，表示它無法追上，形成新車隊
            if (time > currentMaxTime)
            {
                fleets++;
                currentMaxTime = time;
            }
            // 否則會合併到前一個車隊
        }

        return fleets;
    }
}
```
