# Word Ladder

## 解題思路
使用 **廣度優先搜尋（BFS）** 尋找從 `beginWord` 到 `endWord` 的最短轉換序列長度。

1. 將 `wordList` 轉換為 HashSet 以便快速查詢。
2. 如果 `endWord` 不在 `wordList` 中，直接回傳 0。
3. 使用 BFS：
   - 將 `beginWord` 加入佇列，層數（即序列長度）設為 1。
   - 每次從佇列取出一個單詞，對其每個字元位置嘗試替換為 `'a'` 到 `'z'` 的字母。
   - 如果新單詞存在於 `wordList` 中，將其加入佇列並從集合中移除（避免重複訪問）。
   - 如果新單詞等於 `endWord`，回傳當前層數 + 1。
4. 如果 BFS 結束仍未找到，回傳 0。

### 優化技巧：雙向 BFS（Bidirectional BFS）
可以從 `beginWord` 和 `endWord` 同時進行 BFS，大幅減少搜尋空間。

## 時間複雜度
- **時間**: O(N × L × 26) — N 為 wordList 長度，L 為單詞長度
- **空間**: O(N) — 需要 HashSet 和佇列儲存單詞

## 程式碼

```csharp
public class WordLadder
{
    public int Solve(string beginWord, string endWord, IList<string> wordList)
    {
        var wordSet = new HashSet<string>(wordList);
        if (!wordSet.Contains(endWord)) return 0;

        var queue = new Queue<string>();
        queue.Enqueue(beginWord);
        int level = 1;

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                string curr = queue.Dequeue();
                char[] chars = curr.ToCharArray();

                for (int j = 0; j < chars.Length; j++)
                {
                    char original = chars[j];
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        if (ch == original) continue;
                        chars[j] = ch;
                        string next = new string(chars);

                        if (next == endWord) return level + 1;

                        if (wordSet.Contains(next))
                        {
                            wordSet.Remove(next);
                            queue.Enqueue(next);
                        }
                    }
                    chars[j] = original;
                }
            }
            level++;
        }

        return 0;
    }
}
```
