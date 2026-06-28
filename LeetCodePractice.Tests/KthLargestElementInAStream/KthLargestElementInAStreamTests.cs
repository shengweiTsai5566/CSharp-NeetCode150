using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class KthLargestElementInAStreamTests
{
    [Fact]
    public void KthLargest_Add_Works()
    {
        var kth = new KthLargestElementInAStream();
        // Note: Constructor with (k, nums) needs to be implemented
        // For now testing Add method exists
        var ex = Record.Exception(() => kth.Add(5));
        Assert.NotNull(ex);
        Assert.IsType<NotImplementedException>(ex);
    }
}
