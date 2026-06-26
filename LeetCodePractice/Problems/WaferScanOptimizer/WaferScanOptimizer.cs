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
        // 4. 回傳合併後的 List<ScanInterval>
        // 高階加分：考慮使用 Span<T> 或 Memory<T> 處理大量資料
        throw new NotImplementedException();
    }
}

