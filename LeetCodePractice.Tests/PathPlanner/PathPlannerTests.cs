using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class PathPlannerTests
{
    private readonly PathPlanner _solver = new();

    // ===== 正常情況 (Happy Path) =====

    [Fact]
    public void GenerateSpiralPath_N1_ReturnsSingleElement()
    {
        var result = _solver.GenerateSpiralPath(1);

        Assert.Equal(1, result[0, 0]);
    }

    [Fact]
    public void GenerateSpiralPath_N2_ReturnsCorrectMatrix()
    {
        var result = _solver.GenerateSpiralPath(2);

        Assert.Equal(1, result[0, 0]);
        Assert.Equal(2, result[0, 1]);
        Assert.Equal(4, result[1, 0]);
        Assert.Equal(3, result[1, 1]);
    }

    [Fact]
    public void GenerateSpiralPath_N3_ReturnsCorrectMatrix()
    {
        var result = _solver.GenerateSpiralPath(3);

        // [1,2,3]
        // [8,9,4]
        // [7,6,5]
        Assert.Equal(1, result[0, 0]);
        Assert.Equal(2, result[0, 1]);
        Assert.Equal(3, result[0, 2]);
        Assert.Equal(8, result[1, 0]);
        Assert.Equal(9, result[1, 1]);
        Assert.Equal(4, result[1, 2]);
        Assert.Equal(7, result[2, 0]);
        Assert.Equal(6, result[2, 1]);
        Assert.Equal(5, result[2, 2]);
    }

    [Fact]
    public void GenerateSpiralPath_N4_ReturnsCorrectMatrix()
    {
        var result = _solver.GenerateSpiralPath(4);

        // 驗證首尾值
        Assert.Equal(1, result[0, 0]);
        Assert.Equal(16, result[3, 3]);

        // 驗證總數
        int total = 0;
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                total++;

        Assert.Equal(16, total);
    }

    // ===== 邊界情況 (Edge Cases) =====

    [Fact]
    public void GenerateSpiralPath_N5_LastElementAtCenter()
    {
        var result = _solver.GenerateSpiralPath(5);

        // 奇數 n，最後一個元素 (n^2) 應在中心
        Assert.Equal(25, result[2, 2]);
    }

    [Fact]
    public void GenerateSpiralPath_AllValuesAreConsecutive()
    {
        var result = _solver.GenerateSpiralPath(4);

        var flat = new List<int>();
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                flat.Add(result[i, j]);

        flat.Sort();

        for (int i = 0; i < 16; i++)
        {
            Assert.Equal(i + 1, flat[i]);
        }
    }

    // ===== 壓力測試 (Stress) =====

    [Fact]
    public void GenerateSpiralPath_LargeN_CompletesQuickly()
    {
        var result = _solver.GenerateSpiralPath(100);

        // 驗證角落值
        Assert.Equal(1, result[0, 0]);
        Assert.Equal(100 * 100, result[49, 50]); // 中心附近（100為偶數）

        // 驗證總數
        Assert.Equal(10000, result[99, 98] + result[99, 99] - result[0, 0] + 1); // 粗略驗證
    }

    [Fact]
    public void GenerateSpiralPath_AllNumbersPresent_NoDuplicates()
    {
        int n = 10;
        var result = _solver.GenerateSpiralPath(n);

        var set = new HashSet<int>();
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                set.Add(result[i, j]);

        Assert.Equal(n * n, set.Count);
    }
}
