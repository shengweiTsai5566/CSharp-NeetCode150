# Encode and Decode Strings

## 解題思路
設計一個演算法將字串列表編碼為單一字串，再將其解碼回原始的字串列表。

使用**長度前綴（Length Prefix）**編碼方式：
- **編碼**：對每個字串，將其長度與一個分隔符（如 `"#"`）作為前綴，再接上字串本身。例如 `["hello", "world"]` → `"5#hello5#world"`。
- **解碼**：遍歷編碼後的字串，解析出長度（直到遇到 `"#"`），然後根據長度讀取對應的字元數作為一個字串。重複直到處理完整個字串。

這種方式可以處理包含任何字元的字串（包括 `"#"` 本身），因為長度資訊精確地告訴我們每個字串的邊界。

## 時間複雜度
- **時間**: O(n) — n 為所有字串的總長度
- **空間**: O(1) — 不計輸出，僅使用常數額外空間

## 程式碼

```csharp
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodePractice.Problems;

public class EncodeAndDecodeStrings
{
    public string Encode(IList<string> strs)
    {
        var sb = new StringBuilder();
        foreach (var str in strs)
        {
            sb.Append(str.Length);
            sb.Append('#');
            sb.Append(str);
        }
        return sb.ToString();
    }

    public List<string> Decode(string s)
    {
        var result = new List<string>();
        int i = 0;

        while (i < s.Length)
        {
            // 找到 '#' 的位置
            int delimiterPos = s.IndexOf('#', i);
            int length = int.Parse(s.Substring(i, delimiterPos - i));

            // 讀取字串內容
            string str = s.Substring(delimiterPos + 1, length);
            result.Add(str);

            // 移動到下一個字串的起始位置
            i = delimiterPos + 1 + length;
        }

        return result;
    }
}
```
