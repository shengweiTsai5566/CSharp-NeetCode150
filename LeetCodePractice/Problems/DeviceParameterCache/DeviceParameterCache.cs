using System;

namespace LeetCodePractice.Problems;

/// <summary>
/// Device Parameter Cache
/// 對應 LeetCode：LC 146 LRU Cache
/// 
/// 面試情境：
/// 機台在高速運作時，需要頻繁讀取玻璃基板或晶圓的幾何修正參數。
/// 因為從資料庫或底層硬體暫存器讀取太慢，需要建立一個快取機制。
/// 但為了防止記憶體洩漏（Memory Leak）與頻繁 GC，這個快取必須有
/// 容量限制，且嚴禁在更新資料時頻繁 new 物件。
/// 
/// 題目描述：
/// 實作一個 DeviceParameterCache 類別，支援 Get(int key) 和 Put(int key, int value)。
/// 當快取達到容量上限時，應在寫入新資料前，汰換最久未使用（Least Recently Used）的資料。
/// 
/// Senior 實作重點：
/// 普通的 LeetCode 解法會使用 new LinkedListNode 來實作。但在設備控制中，
/// 頻繁的 Put 會導致大量節點物件被 new 出來，引發 GC 停頓。
/// 面試官會期待你用陣列型雙向鏈結串列（Array-based Doubly Linked List）
/// 或物件池（Object Pool）的概念來重用節點。
/// </summary>
public class DeviceParameterCache
{
    // 面試挑戰：如何不使用 .NET 內建的 LinkedList（因為它會產生 Heap 配置）
    // 提示：用預先配置好的 struct 陣列來模擬鏈結串列

    public DeviceParameterCache(int capacity)
    {
        // TODO: 初始化快取，預先配置陣列
        throw new NotImplementedException();
    }

    public int Get(int key)
    {
        // TODO: 回傳 key 對應的 value，若不存在回傳 -1
        // 同時將該 key 標記為最近使用
        throw new NotImplementedException();
    }

    public void Put(int key, int value)
    {
        // TODO: 寫入 key-value，若已存在則更新 value 並標記為最近使用
        // 若快取已滿，淘汰最久未使用的項目後再寫入
        throw new NotImplementedException();
    }
}

