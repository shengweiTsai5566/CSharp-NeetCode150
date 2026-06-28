using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class MinStackTests
{
    [Fact]
    public void MinStack_Example1_Works()
    {
        var stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);
        Assert.Equal(-3, stack.GetMin());
        stack.Pop();
        Assert.Equal(0, stack.Top());
        Assert.Equal(-2, stack.GetMin());
    }

    [Fact]
    public void MinStack_PushPop_Works()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.Top());
        stack.Pop();
        Assert.Equal(1, stack.Top());
    }

    [Fact]
    public void MinStack_GetMinAfterPop_Works()
    {
        var stack = new MinStack();
        stack.Push(5);
        stack.Push(3);
        stack.Push(7);
        Assert.Equal(3, stack.GetMin());
        stack.Pop();
        Assert.Equal(3, stack.GetMin());
        stack.Pop();
        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void MinStack_SingleElement_Works()
    {
        var stack = new MinStack();
        stack.Push(42);
        Assert.Equal(42, stack.Top());
        Assert.Equal(42, stack.GetMin());
        stack.Pop();
    }
}
