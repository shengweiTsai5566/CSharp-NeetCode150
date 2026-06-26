using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ProblemTemplateTests
{
    [Fact]
    public void Solve_ReturnsExpectedResult_ForExampleInput()
    {
        var solution = new ProblemTemplate();

        int[] nums = { 1, 2, 3 };
        int target = 4;

        int[] result = solution.Solve(nums, target);

        // TODO: 修改以下預期值為你題目的正確結果
        Assert.Empty(result);
    }
}
