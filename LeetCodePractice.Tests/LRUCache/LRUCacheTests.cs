using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class LRUCacheTests
{
    [Fact]
    public void LRUCache_Example1_Works()
    {
        var cache = new LRUCache();
        cache.Put(1, 1);
        cache.Put(2, 2);
        Assert.Equal(1, cache.Get(1));
        cache.Put(3, 3); // evicts key 2
        Assert.Equal(-1, cache.Get(2));
        cache.Put(4, 4); // evicts key 1
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(3, cache.Get(3));
        Assert.Equal(4, cache.Get(4));
    }

    [Fact]
    public void LRUCache_Capacity1_Works()
    {
        var cache = new LRUCache();
        cache.Put(1, 10);
        Assert.Equal(10, cache.Get(1));
        cache.Put(2, 20); // evicts 1
        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(20, cache.Get(2));
    }

    [Fact]
    public void LRUCache_UpdateExisting_UpdatesValue()
    {
        var cache = new LRUCache();
        cache.Put(1, 10);
        cache.Put(1, 20);
        Assert.Equal(20, cache.Get(1));
    }

    [Fact]
    public void LRUCache_GetMakesItRecent_NoEviction()
    {
        var cache = new LRUCache();
        cache.Put(1, 1);
        cache.Put(2, 2);
        cache.Get(1);       // makes 1 most recent
        cache.Put(3, 3);    // evicts 2, not 1
        Assert.Equal(1, cache.Get(1));
        Assert.Equal(-1, cache.Get(2));
        Assert.Equal(3, cache.Get(3));
    }
}

