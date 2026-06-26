# Group Anagrams

## 解題思路
使用 Dictionary 將字串分組，key 為字串排序後的結果。遍歷每個字串，將其字元排序後作為 key，若 key 已存在則將原字串加入對應的列表，否則建立新的列表。最後將 Dictionary 中的所有 values 轉為 IList<IList<string>> 回傳。

## 時間複雜度
- **時間**: O(n × k log k) — n 為字串數量，k 為最長字串長度，排序每個字串需要 O(k log k)
- **空間**: O(n × k) — 需要儲存所有字串

## 程式碼

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodePractice.Problems;

public class GroupAnagrams
{
    public IList<IList<string>> Solve(string[] strs)
    {
        var map = new Dictionary<string, IList<string>>();

        foreach (string s in strs)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);
            string key = new string(chars);

            if (!map.ContainsKey(key))
                map[key] = new List<string>();

            map[key].Add(s);
        }

        return map.Values.ToList();
    }
}
```
