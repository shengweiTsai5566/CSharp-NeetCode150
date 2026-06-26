# Wafer Scan Optimizer（晶圓缺陷區域掃描範圍合併）

**對應 LeetCode：** LC 56 Merge Intervals / LC 57 Insert Interval 延伸變形

**面試難度：** Medium-Hard（硬體整合情境題）

---

## 解題思路

### 問題理解
在 AOI（自動光學檢測）設備中，相機回傳多個發現缺陷的曝光區間 `[start_x, end_x]`。為了優化 E-beam 複檢路徑，需要將重疊或連續的區間合併，避免重複掃描。

### 演算法步驟

1. **處理邊界**：若 `intervals` 為 `null` 或長度 `<= 1`，直接回傳
2. **排序**：依 `StartX` 升序排序（確保可線性合併）
3. **In-place 合併**（面試加分！）：
   - 使用 `writeIndex` 指向當前合併的位置
   - 遍歷每個區間 `readIndex`：
     - 若 `current.StartX <= merged.EndX + 1`（重疊或相鄰），則合併（更新 `EndX`）
     - 否則將當前區間寫入下一個 `writeIndex` 位置
4. **清除多餘空間**：使用 `RemoveRange` 移除未使用的尾端元素

### 面試官重點
- ✅ **使用 `struct` 避免 GC 壓力** — `ScanInterval` 是 struct，分配在 Stack
- ✅ **In-place 操作** — 直接在原 List 上修改，減少記憶體分配
- ✅ **`ReadOnlySpan` 意識** — 可進一步優化大量資料
- ✅ **面試加分追問**：若資料量極大（數百萬點），可使用 `Span<T>` 或 `Memory<T>` 搭配預先配置的陣列

---

## 時間複雜度

| 操作 | 複雜度 |
|------|--------|
| 排序 | **O(n log n)** |
| 合併遍歷 | **O(n)** |
| 總計 | **O(n log n)** |

## 空間複雜度

- **In-place 版本**：**O(1)**（不計排序的額外空間）
- **一般版本**：**O(n)**（需要新 List 儲存結果）

---

## 完整解答程式碼

```csharp
using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

public struct ScanInterval
{
    public int StartX;
    public int EndX;

    public ScanInterval(int start, int end)
    {
        StartX = start;
        EndX = end;
    }
}

public class WaferScanOptimizer
{
    public List<ScanInterval> MergeScanZones(List<ScanInterval> intervals)
    {
        if (intervals == null)
            return new List<ScanInterval>();

        if (intervals.Count <= 1)
            return intervals;

        // 依 StartX 排序
        intervals.Sort((a, b) => a.StartX.CompareTo(b.StartX));

        int writeIndex = 0;

        for (int readIndex = 1; readIndex < intervals.Count; readIndex++)
        {
            ScanInterval current = intervals[readIndex];
            ScanInterval merged = intervals[writeIndex];

            if (current.StartX <= merged.EndX + 1) // 重疊或相鄰
            {
                if (current.EndX > merged.EndX)
                {
                    merged.EndX = current.EndX;
                    intervals[writeIndex] = merged;
                }
            }
            else
            {
                writeIndex++;
                intervals[writeIndex] = current;
            }
        }

        // 移除未使用的尾端元素
        if (writeIndex < intervals.Count - 1)
        {
            intervals.RemoveRange(writeIndex + 1, intervals.Count - writeIndex - 1);
        }

        return intervals;
    }
}
```

---

## 高階優化：Span\<T\> 版本

若資料量極大（數百萬點），可使用 `Span<T>` 避免 List 的 Resize 開銷：

```csharp
public Span<ScanInterval> MergeScanZones(Span<ScanInterval> intervals)
{
    if (intervals.Length <= 1)
        return intervals;

    intervals.Sort((a, b) => a.StartX.CompareTo(b.StartX));

    int writeIndex = 0;

    for (int readIndex = 1; readIndex < intervals.Length; readIndex++)
    {
        ref ScanInterval merged = ref intervals[writeIndex];
        ref ScanInterval current = ref intervals[readIndex];

        if (current.StartX <= merged.EndX + 1)
        {
            if (current.EndX > merged.EndX)
                merged.EndX = current.EndX;
        }
        else
        {
            writeIndex++;
            intervals[writeIndex] = current;
        }
    }

    return intervals.Slice(0, writeIndex + 1);
}
```

> 💡 **面試小提示**：當面試官問到「如何處理數百萬筆資料？」時，提出 `Span<T>` + `ref` 回傳的方案會大幅加分，展示你對 Zero-allocation 與高效能 C# 的掌握度。
