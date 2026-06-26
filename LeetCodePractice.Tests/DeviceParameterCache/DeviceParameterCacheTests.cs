using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DeviceParameterCacheTests
{
    // ===== 正常情況 (Happy Path) =====

    [Fact]
    public void PutAndGet_BasicOperations_ReturnsCorrectValue()
    {
        var cache = new DeviceParameterCache(2);

        cache.Put(1, 100);
        cache.Put(2, 200);

        Assert.Equal(100, cache.Get(1));
        Assert.Equal(200, cache.Get(2));
    }

    [Fact]
    public void Get_ExistingKey_UpdatesRecentlyUsed()
    {
        var cache = new DeviceParameterCache(2);

        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Get(1);       // key 1 變成最近使用
        cache.Put(3, 30);   // 淘汰 key 2（最久未使用）

        // TODO: 補上預期值
        // Assert.Equal(10, cache.Get(1)); // key 1 應存在
        // Assert.Equal(-1, cache.Get(2)); // key 2 應被淘汰
        // Assert.Equal(30, cache.Get(3)); // key 3 應存在
    }

    // ===== 邊界情況 (Edge Cases) =====

    [Fact]
    public void Get_NonExistentKey_ReturnsMinusOne()
    {
        var cache = new DeviceParameterCache(2);

        // TODO: 預期回傳 -1
        Assert.Equal(-1, cache.Get(99));
    }

    [Fact]
    public void Put_UpdateExistingKey_ShouldUpdateValue()
    {
        var cache = new DeviceParameterCache(2);

        cache.Put(1, 100);
        cache.Put(1, 200);

        // TODO: 補上預期值
        // Assert.Equal(200, cache.Get(1));
    }

    [Fact]
    public void Cache_CapacityOne_WorksCorrectly()
    {
        var cache = new DeviceParameterCache(1);

        cache.Put(1, 10);
        Assert.Equal(10, cache.Get(1));

        cache.Put(2, 20);   // 淘汰 key 1

        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(20, cache.Get(2));
    }

    // ===== 邊界條件 (Boundary Conditions) =====

    [Fact]
    public void Put_EvictsLeastRecentlyUsed_WhenFull()
    {
        var cache = new DeviceParameterCache(3);

        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Put(3, 30);
        cache.Put(4, 40);   // 淘汰 key 1

        Assert.Equal(-1, cache.Get(1));
        Assert.Equal(20, cache.Get(2));
        Assert.Equal(30, cache.Get(3));
        Assert.Equal(40, cache.Get(4));
    }

    [Fact]
    public void Put_RepeatedAccess_PreventsEviction()
    {
        var cache = new DeviceParameterCache(3);

        cache.Put(1, 10);
        cache.Put(2, 20);
        cache.Put(3, 30);
        cache.Get(1);       // key 1 變最近使用
        cache.Get(2);       // key 2 變最近使用
        cache.Put(4, 40);   // 淘汰 key 3

        // TODO: 補上預期值
        // Assert.Equal(10, cache.Get(1));
        // Assert.Equal(20, cache.Get(2));
        // Assert.Equal(-1, cache.Get(3));
        // Assert.Equal(40, cache.Get(4));
    }

    // ===== 無效與特殊輸入 (Invalid / Special Inputs) =====

    [Fact]
    public void Cache_ZeroCapacity_GetAlwaysReturnsMinusOne()
    {
        var cache = new DeviceParameterCache(0);

        cache.Put(1, 10);
        Assert.Equal(-1, cache.Get(1));
    }

    [Fact]
    public void Cache_LargeCapacity_GetNonExistentReturnsMinusOne()
    {
        var cache = new DeviceParameterCache(1000);

        for (int i = 0; i < 1000; i++)
        {
            cache.Put(i, i * 10);
        }

        Assert.Equal(-1, cache.Get(9999));
    }

    // ===== 壓力測試 (Stress / Large Data) =====

    [Fact]
    public void PutAndGet_StressTest_DoesNotThrow()
    {
        var cache = new DeviceParameterCache(500);

        for (int i = 0; i < 1000; i++)
        {
            cache.Put(i, i);
        }

        // 前 500 筆應被淘汰
        for (int i = 0; i < 500; i++)
        {
            Assert.Equal(-1, cache.Get(i));
        }

        // 後 500 筆應存在
        for (int i = 500; i < 1000; i++)
        {
            Assert.Equal(i, cache.Get(i));
        }
    }

    [Fact]
    public void Put_SameKeyRepeatedly_NoLeak()
    {
        var cache = new DeviceParameterCache(2);

        for (int i = 0; i < 100; i++)
        {
            cache.Put(1, i);
        }

        // TODO: 補上預期值
        // Assert.Equal(99, cache.Get(1));
    }
}
