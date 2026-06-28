using System;
using System.Collections.Generic;

namespace LeetCodePractice.Problems;

/// <summary>
/// Wafer Scan Optimizer
/// 對應 LeetCode：LC 56 Merge Intervals / LC 57 Insert Interval 延伸變形
/// 
/// 面試情境：
/// 在光學檢測（AOI）設備中，相機會回傳多個發現缺陷的曝光區間（Bounding Box）。
/// 為了優化後續電子束（E-beam）進行精細複檢的移動路徑，我們必須將重疊或連續的
/// 檢測區間進行合併，避免重複掃描。
/// 
/// 題目描述：
/// 請實作一個方法，輸入一組二維空間中的曝光區間陣列 intervals，
/// 其中 intervals[i] = [start_x, end_x]，請將所有重疊的區間合併，
/// 並回傳合併後的區間陣列。
/// 
/// 面試官會要求您考慮記憶體優化（Zero-allocation 意識）。
/// </summary>
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
    // 面試官會檢視：您是否使用了 struct 避免 GC 壓力？是否在原地（In-place）或以高效方式處理？
    public List<ScanInterval> MergeScanZones(List<ScanInterval> intervals)
    {
        // TODO: 實作區間合併演算法
        // 1. 處理 null 或空輸入
        // 2. 依 StartX 排序
        // 3. 遍歷區間，合併重疊或相鄰的區間
        // 3.1 如果合併區間的STARTX 大於先前區間的 ENDX, 且當區間的ENDX小於等於合併區間的ENDX，則表示當前區間完全被包含在合併區間中，直接跳過
        // 3.2 前述為否的狀況下, 果當前區間的STARTX 大於合併區間的 ENDX, 則擴展合併區間的ENDX為當前區間的ENDX
        // 3.3 前述條件都為否的狀況下, 儲存合併區間至LIST, 並將合併區間更新為當前區間
        // 4. 回傳合併後的 List<ScanInterval>
        
        var currentIntervals = new ScanInterval(-1,-1);
        List<ScanInterval> mergedIntervals = new List<ScanInterval>();
        if(intervals!=null && intervals.Count > 0)
        {
            
            intervals.Sort((a,b)=>a.StartX.CompareTo(b.StartX));
            for(int i = 0; i < intervals.Count; i++){
                if(currentIntervals.StartX < 0 && currentIntervals.EndX < 0)
                {
                    currentIntervals = intervals[i];
                }
                else
                {
                    if(intervals[i].StartX <= currentIntervals.EndX && currentIntervals.EndX>= intervals[i].EndX)
                    {
                        continue;
                    }else if(intervals[i].StartX <= currentIntervals.EndX )
                    {
                        currentIntervals.EndX = intervals[i].EndX;
                    }else if(intervals[i].StartX > currentIntervals.EndX)
                    {
                        mergedIntervals.Add(currentIntervals);
                        currentIntervals = intervals[i];
                    }
                    
                }
            }
            if(mergedIntervals.Contains(currentIntervals) == false)
            {
                mergedIntervals.Add(currentIntervals);
            }    
        } 
         return mergedIntervals;
    }

    /// <summary>
    /// 高階加分：考慮使用 Span&lt;T&gt; 或 Memory&lt;T&gt; 處理大量資料
    /// Span&lt;T&gt; 版本 — Zero-allocation 進階實作
    /// 傳入要掃描的區間與輸出緩衝區，回傳合併後的數量
    /// </summary>
    /// <example>
    /// // 方式一：stackalloc（資料量小，在堆疊上）
    /// Span&lt;ScanInterval&gt; buffer = stackalloc ScanInterval[intervals.Count];
    /// int count = optimizer.MergeScanZones(intervals, buffer);
    /// for (int i = 0; i &lt; count; i++) { var zone = buffer[i]; }
    ///
    /// // 方式二：ArrayPool（資料量大，避免堆疊溢位）
    /// ScanInterval[] poolArray = ArrayPool&lt;ScanInterval&gt;.Shared.Rent(intervals.Length);
    /// var result = poolArray.AsSpan(0, intervals.Length);
    /// int count2 = optimizer.MergeScanZones(data, result);
    /// // ... 使用 result[0..count2] ...
    /// ArrayPool&lt;ScanInterval&gt;.Shared.Return(poolArray);
    /// </example>
    public int MergeScanZones(Span<ScanInterval> intervals, Span<ScanInterval> result)
    {
        if (intervals.IsEmpty) return 0;

        intervals.Sort((a, b) => a.StartX.CompareTo(b.StartX));

        int writeIdx = 0;
        result[writeIdx] = intervals[0];

        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i].StartX <= result[writeIdx].EndX)
            {
                if (intervals[i].EndX > result[writeIdx].EndX)
                    result[writeIdx].EndX = intervals[i].EndX;
            }
            else
            {
                writeIdx++;
                result[writeIdx] = intervals[i];
            }
        }

        return writeIdx + 1;
    }

    /// <summary>
    /// 示範如何從呼叫端使用 Span&lt;T&gt; 版本（僅供參考，不會被正式呼叫）
    /// </summary>
    public static void DemoCallSpanVersion()
    {
        var optimizer = new WaferScanOptimizer();
        var data = new ScanInterval[]
        {
            new(1, 3), new(2, 6), new(8, 10), new(15, 18)
        };

        // ----- 方式一：stackalloc（小量資料，零 GC） -----
        Span<ScanInterval> stackBuf = stackalloc ScanInterval[data.Length];
        int count1 = optimizer.MergeScanZones(data, stackBuf);
        Console.WriteLine($"stackalloc 結果 ({count1} 筆):");
        for (int i = 0; i < count1; i++)
            Console.WriteLine($"  [{stackBuf[i].StartX}, {stackBuf[i].EndX}]");

        // ----- 方式二：ArrayPool（大量資料，避免 StackOverflow） -----
        ScanInterval[] rented = System.Buffers.ArrayPool<ScanInterval>.Shared.Rent(data.Length);
        var poolBuf = rented.AsSpan(0, data.Length);
        int count2 = optimizer.MergeScanZones(data, poolBuf);
        Console.WriteLine($"ArrayPool 結果 ({count2} 筆):");
        for (int i = 0; i < count2; i++)
            Console.WriteLine($"  [{poolBuf[i].StartX}, {poolBuf[i].EndX}]");
        System.Buffers.ArrayPool<ScanInterval>.Shared.Return(rented);
    }
}

