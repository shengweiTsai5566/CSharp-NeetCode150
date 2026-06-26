# Design Twitter

## 解題思路

此題為系統設計題，需要實作一個簡化版的 Twitter，支援發推文、取得近貼文、追蹤/取消追蹤功能。

**核心設計：**
- 使用兩個字典：一個儲存每位使用者的推文列表（`_tweets`），另一個儲存每位使用者的追蹤關係（`_followers`）。
- 每則推文記錄其 ID 與時間戳記（用一個全域計數器模擬時間順序）。
- `PostTweet`：將新推文加入該使用者的推文列表。
- `Follow` / `Unfollow`：維護追蹤集合。
- `GetNewsFeed`：收集使用者自己與追蹤對象的所有推文，取出最新的 10 則（可使用排序或優先佇列）。

**實作細節：**
- 使用 `Dictionary<int, List<(int tweetId, int timestamp)>>` 儲存推文。
- 使用 `Dictionary<int, HashSet<int>>` 儲存追蹤關係（follower -> set of followees）。
- `GetNewsFeed` 遍歷所有相關使用者的推文，排序後取前 10 筆。

## 時間複雜度

- **PostTweet**: O(1) — 直接附加到列表末端
- **Follow / Unfollow**: O(1) — HashSet 操作
- **GetNewsFeed**: O(N log N) — N 為相關推文總數，需要排序取前 10 筆；可優化為 O(N) 使用 min-heap 固定大小為 10

## 空間複雜度

- **整體**: O(T + F) — T 為推文總數，F 為追蹤關係總數

## 程式碼

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodePractice.Problems;

public class DesignTwitter
{
    private readonly Dictionary<int, List<(int tweetId, int timestamp)>> _tweets;
    private readonly Dictionary<int, HashSet<int>> _followers;
    private int _timestamp;

    public DesignTwitter()
    {
        _tweets = new Dictionary<int, List<(int, int)>>();
        _followers = new Dictionary<int, HashSet<int>>();
        _timestamp = 0;
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!_tweets.ContainsKey(userId))
            _tweets[userId] = new List<(int, int)>();
        _tweets[userId].Add((tweetId, _timestamp++));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var followees = _followers.GetValueOrDefault(userId, new HashSet<int>());
        var allTweets = new List<(int tweetId, int timestamp)>();

        // 加入使用者自己的推文
        if (_tweets.ContainsKey(userId))
            allTweets.AddRange(_tweets[userId]);

        // 加入追蹤對象的推文
        foreach (var followee in followees)
        {
            if (_tweets.ContainsKey(followee))
                allTweets.AddRange(_tweets[followee]);
        }

        // 按時間戳降序排列，取前 10 筆
        return allTweets
            .OrderByDescending(t => t.timestamp)
            .Take(10)
            .Select(t => t.tweetId)
            .ToList();
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!_followers.ContainsKey(followerId))
            _followers[followerId] = new HashSet<int>();
        _followers[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (_followers.ContainsKey(followerId))
            _followers[followerId].Remove(followeeId);
    }
}
```
