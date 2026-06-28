using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class TimeBasedKeyValueStoreTests
{
    [Fact]
    public void TimeMap_Example1_Works()
    {
        var tm = new TimeBasedKeyValueStore();
        tm.Set("foo", "bar", 1);
        Assert.Equal("bar", tm.Get("foo", 1));
        Assert.Equal("bar", tm.Get("foo", 3));
        tm.Set("foo", "bar2", 4);
        Assert.Equal("bar2", tm.Get("foo", 4));
        Assert.Equal("bar", tm.Get("foo", 5));
    }

    [Fact]
    public void TimeMap_KeyNotFound_ReturnsEmptyString()
    {
        var tm = new TimeBasedKeyValueStore();
        Assert.Equal("", tm.Get("nonexistent", 1));
    }

    [Fact]
    public void TimeMap_TimestampBeforeAnySet_ReturnsEmpty()
    {
        var tm = new TimeBasedKeyValueStore();
        tm.Set("key", "val", 10);
        Assert.Equal("", tm.Get("key", 5));
    }

    [Fact]
    public void TimeMap_MultipleTimestamps_ReturnsCorrect()
    {
        var tm = new TimeBasedKeyValueStore();
        tm.Set("key", "v1", 1);
        tm.Set("key", "v2", 3);
        tm.Set("key", "v3", 5);
        Assert.Equal("v1", tm.Get("key", 2));
        Assert.Equal("v2", tm.Get("key", 4));
        Assert.Equal("v3", tm.Get("key", 6));
    }
}


