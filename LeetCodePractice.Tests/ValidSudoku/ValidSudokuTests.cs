using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ValidSudokuTests
{
    private readonly ValidSudoku _solver = new();

    [Fact]
    public void Solve_Example1_ReturnsTrue()
    {
        char[][] board = [
            ['5','3','.','.','7','.','.','.','.'],
            ['6','.','.','1','9','5','.','.','.'],
            ['.','9','8','.','.','.','.','6','.'],
            ['8','.','.','.','6','.','.','.','3'],
            ['4','.','.','8','.','3','.','.','1'],
            ['7','.','.','.','2','.','.','.','6'],
            ['.','6','.','.','.','.','2','8','.'],
            ['.','.','.','4','1','9','.','.','5'],
            ['.','.','.','.','8','.','.','7','9']
        ];
        Assert.True(_solver.Solve(board));
    }

    [Fact]
    public void Solve_Example2_ReturnsFalse()
    {
        char[][] board = [
            ['8','3','.','.','7','.','.','.','.'],
            ['6','.','.','1','9','5','.','.','.'],
            ['.','9','8','.','.','.','.','6','.'],
            ['8','.','.','.','6','.','.','.','3'],
            ['4','.','.','8','.','3','.','.','1'],
            ['7','.','.','.','2','.','.','.','6'],
            ['.','6','.','.','.','.','2','8','.'],
            ['.','.','.','4','1','9','.','.','5'],
            ['.','.','.','.','8','.','.','7','9']
        ];
        Assert.False(_solver.Solve(board));
    }

    [Fact]
    public void Solve_EmptyBoard_ReturnsTrue()
    {
        char[][] board = new char[9][];
        for (int i = 0; i < 9; i++)
            board[i] = new char[9];
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
                board[i][j] = '.';
        Assert.True(_solver.Solve(board));
    }
}
