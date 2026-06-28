using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DetectSquaresTests
{
    [Fact]
    public void DetectSquares_Example1_CountsSquares()
    {
        var ds = new DetectSquares();
        ds.Add([3, 10]);
        ds.Add([11, 2]);
        ds.Add([3, 2]);
        Assert.Equal(0, ds.Count([11, 10])); // only 1 point forms a square, need 4

        ds.Add([11, 10]); // now we have 4 corners
        Assert.Equal(1, ds.Count([11, 10]));
    }

    [Fact]
    public void DetectSquares_MultipleSamePoints_CountsMultiple()
    {
        var ds = new DetectSquares();
        ds.Add([1, 1]);
        ds.Add([1, 3]);
        ds.Add([3, 1]);
        ds.Add([3, 3]);
        Assert.Equal(1, ds.Count([3, 3]));

        ds.Add([3, 3]); // duplicate
        Assert.Equal(2, ds.Count([3, 3]));
    }

    [Fact]
    public void DetectSquares_NoSquare_Returns0()
    {
        var ds = new DetectSquares();
        ds.Add([0, 0]);
        ds.Add([1, 1]);
        Assert.Equal(0, ds.Count([0, 0]));
    }
}
