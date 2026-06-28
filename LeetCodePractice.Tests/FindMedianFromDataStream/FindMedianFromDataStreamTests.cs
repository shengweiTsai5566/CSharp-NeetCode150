using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class FindMedianFromDataStreamTests
{
    [Fact]
    public void MedianFinder_Example1_Works()
    {
        var mf = new FindMedianFromDataStream();
        mf.AddNum(1);
        mf.AddNum(2);
        Assert.Equal(1.5, mf.FindMedian());
        mf.AddNum(3);
        Assert.Equal(2.0, mf.FindMedian());
    }

    [Fact]
    public void MedianFinder_SingleElement_ReturnsIt()
    {
        var mf = new FindMedianFromDataStream();
        mf.AddNum(5);
        Assert.Equal(5.0, mf.FindMedian());
    }

    [Fact]
    public void MedianFinder_EvenCount_ReturnsAverage()
    {
        var mf = new FindMedianFromDataStream();
        mf.AddNum(1);
        mf.AddNum(2);
        mf.AddNum(3);
        mf.AddNum(4);
        Assert.Equal(2.5, mf.FindMedian());
    }

    [Fact]
    public void MedianFinder_NegativeNumbers_Works()
    {
        var mf = new FindMedianFromDataStream();
        mf.AddNum(-1);
        mf.AddNum(-2);
        Assert.Equal(-1.5, mf.FindMedian());
        mf.AddNum(-3);
        Assert.Equal(-2.0, mf.FindMedian());
    }

    [Fact]
    public void MedianFinder_AddLargeNumbers_DoesNotThrow()
    {
        var mf = new FindMedianFromDataStream();
        for (int i = 1; i <= 10000; i++)
            mf.AddNum(i);
        Assert.InRange(mf.FindMedian(), 4999.5, 5000.5);
    }
}


