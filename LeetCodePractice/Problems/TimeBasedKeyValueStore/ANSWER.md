# Time Based Key-Value Store

## 解題思路
設計一個時間戳記版本的鍵值儲存。對於每個 key，儲存一個 `(value, timestamp)` 的列表。由於題目保證 `set` 的 timestamp 是嚴格遞增的，所以每個 key 對應的列表天然有序。

`get(key, timestamp)` 需要在該 key 的列表中，找到 `timestamp_prev <= timestamp` 中最大的 timestamp 對應的 value。這正是二分搜尋（upper bound）的應用：
- 在列表中二分搜尋，找到最後一個 timestamp `<=` 給定 timestamp 的位置
- 若找不到則回傳空字串 `""`

## 時間/空間複雜度
- **時間**:
  - `set`: O(1)（列表尾端插入）
  - `get`: O(log n)（二分搜尋）
- **空間**: O(n)，n 為所有 set 操作次數

## 程式碼

```csharp
public class TimeBasedKeyValueStore
{
    private readonly Dictionary<string, List<(string value, int timestamp)>> _map = new();

    public void Set(string key, string value, int timestamp)
    {
        if (!_map.ContainsKey(key))
            _map[key] = new List<(string, int)>();

        _map[key].Add((value, timestamp));
    }

    public string Get(string key, int timestamp)
    {
        if (!_map.ContainsKey(key))
            return "";

        var list = _map[key];
        int left = 0, right = list.Count - 1;

        // 二分搜尋：找到最後一個 timestamp <= 給定 timestamp
        int index = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (list[mid].timestamp <= timestamp)
            {
                index = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return index >= 0 ? list[index].value : "";
    }
}
```
