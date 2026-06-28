namespace LeetCodePractice.Problems;

/// <summary>
/// LRU Cache
/// 對應 LeetCode：LC 146
/// 來源：NeetCode 150
/// 難度：Medium
///
/// Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
/// 
/// Implement the `LRUCache` class:
/// 
/// 	  - `LRUCache(int capacity)` Initialize the LRU cache with positive size `capacity`.
/// 
/// 	  - `int get(int key)` Return the value of the `key` if the key exists, otherwise return `-1`.
/// 
/// 	  - `void put(int key, int value)` Update the value of the `key` if the `key` exists. Otherwise, add the `key-value` pair to the cache. If the number of keys exceeds the `capacity` from this operation, evict the least recently used key.
/// 
/// The functions `get` and `put` must each run in `O(1)` average time complexity.
/// 
///  
/// 
/// Example 1:
/// 
/// Input
/// ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
/// [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
/// Output
/// [null, null, null, 1, null, -1, null, -1, 3, 4]
/// 
/// Explanation
/// LRUCache lRUCache = new LRUCache(2);
/// lRUCache.put(1, 1); // cache is {1=1}
/// lRUCache.put(2, 2); // cache is {1=1, 2=2}
/// lRUCache.get(1);    // return 1
/// lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
/// lRUCache.get(2);    // returns -1 (not found)
/// lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
/// lRUCache.get(1);    // return -1 (not found)
/// lRUCache.get(3);    // return 3
/// lRUCache.get(4);    // return 4
/// 
///  
/// 
/// Constraints:
/// 
/// 	  - `1 <= capacity <= 3000`
/// 
/// 	  - `0 <= key <= 104`
/// 
/// 	  - `0 <= value <= 105`
/// 
/// 	  - At most `2 * 105` calls will be made to `get` and `put`.
///
/// 
///
/// 🌍 現實應用場景 (Real-World Applications)：
///
/// 1️⃣ 瀏覽器快取 (Browser Cache)
///    瀏覽器暫存圖片/CSS/JS，空間滿了淘汰最久沒看的網站資源。
///    Browsers cache images, CSS, JS files; evicts least recently used resources when full.
///
/// 2️⃣ Redis / Memcached
///    記憶體資料庫用 LRU 淘汰舊資料（如 Redis 的 allkeys-lru 策略）。
///    In-memory databases use LRU to evict old data (e.g., Redis allkeys-lru policy).
///
/// 3️⃣ 資料庫 Buffer Pool（MySQL InnoDB）
///    快取常查詢的資料頁，滿了淘汰最久沒用的頁面。
///    Caches frequently queried data pages; evicts least recently used pages when full.
///
/// 4️⃣ 作業系統頁面置換 (OS Page Replacement)
///    RAM 不足時決定哪些記憶體頁面搬到 swap。
///    Decides which memory pages to swap out when RAM is full.
///
/// 5️⃣ 後端 API 快取 (Backend API Cache)
///    自己寫的熱門商品/資料快取，避免每次都查資料庫。
///    Custom cache for hot products or data to avoid DB queries every time.
///
/// 💡 為什麼選 LRU？(Why LRU?)
///    LRU 利用「時間局部性（Temporal Locality）」：剛剛用過的資料很可能馬上再用。
///    比其他策略（FIFO、LFU、Random）更適合大多數快取場景。
///    LRU leverages Temporal Locality: recently accessed data is likely to be accessed again soon.
///    It outperforms FIFO, LFU, and Random in most caching scenarios.
/// </summary>
public class LRUCache
{
    // TODO: 實作你的解法
    int _capacity = 0;
    Dictionary<int, DLinkedNode> _cache = new Dictionary<int, DLinkedNode>();
    DLinkedNode _head = new DLinkedNode();
    DLinkedNode _tail = new DLinkedNode();



    public int Get(int key)
    {
        if (_cache.TryGetValue(key, out var node))  // ✅ 安全查找
        {
            MoveToHead(node);    // 移到 head 後，變成最新用過的
            return node.value;
        }
        return -1;

    }

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _head = new DLinkedNode();
        _tail = new DLinkedNode();
        _head.next = _tail;
        _tail.prev = _head;

    }
    public void Put(int key, int value)
    {

        if (_cache.TryGetValue(key, out var node))  // ✅ 安全查找
        {
            node.value = value;
            MoveToHead(node);
        }
        else
        {
            DLinkedNode nodeNew = new DLinkedNode();
            nodeNew.key = key;
            nodeNew.value = value;
            _cache[key] = nodeNew;
            AddToHead(nodeNew);
            if (_cache.Count > _capacity)
            {
                var tail = RemoveTail();   // 移除串列尾巴（最久沒用）
                _cache.Remove(tail.key);   // 也從 Dictionary 刪掉
            }
        }
    }

    // ===== 雙向鏈結串列輔助方法 =====

    // (A) 將節點加到 _head 後面（最新位置）
    private void AddToHead(DLinkedNode node)
    {
        // TODO: 實作
        node.next = _head.next;
        node.prev = _head;
        node.next.prev = node;
        node.prev.next = node;

    }

    // (B) 將節點從串列中移除
    private void RemoveNode(DLinkedNode node)
    {
        // TODO: 實作
        node.prev.next = node.next;   // 前面的跳過 node，指向後面的
        node.next.prev = node.prev;   // 後面的跳過 node，指回前面的

    }

    // (C) 把節點移到頭部 = RemoveNode + AddToHead
    private void MoveToHead(DLinkedNode node)
    {
        // TODO: 實作
        RemoveNode(node);   // 先從原來的位置拆掉
        AddToHead(node);    // 再插到 head 後面（最新位置）
    }

    // (D) 移除並回傳最久沒用的節點（_tail 前面的那個）
    private DLinkedNode RemoveTail()
    {
        // TODO: 實作
        var tail_ = _tail.prev;
        RemoveNode(_tail.prev);
        return tail_;
    }

    // 內部類別：雙向鏈結節點
    private class DLinkedNode
    {
        public int key;
        public int value;
        public DLinkedNode prev;
        public DLinkedNode next;
    }
}



