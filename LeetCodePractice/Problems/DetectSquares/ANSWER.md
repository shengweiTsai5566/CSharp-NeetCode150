# Detect Squares

## 解題思路
設計一個資料結構來新增點並計算能與查詢點形成**軸對齊正方形**的點組合數量。

核心思路：
1. 使用一個巢狀字典（`Dictionary<int, Dictionary<int, int>>`）來儲存每個 x 座標下各 y 座標的出現次數。
2. **新增點**：將點加入字典，增加對應的計數。
3. **查詢計數**：
   - 遍歷與查詢點 `(px, py)` 在同一 x 座標上的所有點（即所有與查詢點 x 相同的點 `(px, y)`）。
   - 計算邊長 `sideLen = |py - y|`（必須大於 0）。
   - 以 `(px, py)` 和 `(px, y)` 作為正方形的一條邊，往左右兩個方向延伸出正方形：
     - 右邊正方形：檢查 `(px + sideLen, py)` 和 `(px + sideLen, y)` 的存在次數。
     - 左邊正方形：檢查 `(px - sideLen, py)` 和 `(px - sideLen, y)` 的存在次數。
   - 將找到的點的計數相乘並累加（因為重複點視為不同）。

## 時間複雜度
- **時間**:
  - `Add`: O(1)
  - `Count`: O(n) — n 為與查詢點 x 座標相同的點的數量
- **空間**: O(n) — n 為不同點的數量

## 程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public class DetectSquares
{
    private readonly Dictionary<int, Dictionary<int, int>> _points;

    public DetectSquares()
    {
        _points = new Dictionary<int, Dictionary<int, int>>();
    }

    public void Add(int[] point)
    {
        int x = point[0], y = point[1];
        if (!_points.ContainsKey(x))
            _points[x] = new Dictionary<int, int>();

        _points[x][y] = _points[x].GetValueOrDefault(y, 0) + 1;
    }

    public int Count(int[] point)
    {
        int px = point[0], py = point[1];
        int total = 0;

        if (!_points.ContainsKey(px))
            return 0;

        foreach (var (y, cntY) in _points[px])
        {
            int sideLen = Math.Abs(py - y);
            if (sideLen == 0) continue;

            // 右邊正方形
            int x1 = px + sideLen;
            if (_points.ContainsKey(x1))
            {
                int cnt1 = _points[x1].GetValueOrDefault(py, 0);
                int cnt2 = _points[x1].GetValueOrDefault(y, 0);
                total += cntY * cnt1 * cnt2;
            }

            // 左邊正方形
            int x2 = px - sideLen;
            if (_points.ContainsKey(x2))
            {
                int cnt1 = _points[x2].GetValueOrDefault(py, 0);
                int cnt2 = _points[x2].GetValueOrDefault(y, 0);
                total += cntY * cnt1 * cnt2;
            }
        }

        return total;
    }
}
```
