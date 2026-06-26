using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class CommandParserTests
{
    [Fact]
    public void IsValidCommand_ReturnsTrue_ForSimpleValidCommand()
    {
        var parser = new CommandParser();
        
        bool result = parser.IsValidCommand("$INIT;");
        
        // TODO: 更新預期值 - 應該接受合法的簡單命令
        Assert.True(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsTrue_ForCommandWithParams()
    {
        var parser = new CommandParser();
        
        bool result = parser.IsValidCommand("$MOVE,100,-250;");
        
        // TODO: 更新預期值 - 應該接受帶數字參數的命令
        Assert.True(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForMissingHeader()
    {
        var parser = new CommandParser();
        
        bool result = parser.IsValidCommand("MOVE,100;");
        
        // TODO: 更新預期值 - 應該拒絕缺 $ 開頭的命令
        Assert.False(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForNonNumericParams()
    {
        var parser = new CommandParser();
        
        bool result = parser.IsValidCommand("$INIT,ABC;");
        
        // TODO: 更新預期值 - 應該拒絕非數字參數
        Assert.False(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForMissingSemicolon()
    {
        var parser = new CommandParser();
        
        bool result = parser.IsValidCommand("$STOP");
        
        // TODO: 更新預期值 - 應該拒絕缺分號的命令
        Assert.False(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForConsecutiveCommas()
    {
        var parser = new CommandParser();

        bool result = parser.IsValidCommand("$MOVE,100,,200;");

        // 應該拒絕連續兩個逗號
        Assert.False(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForEmptyParamAfterComma()
    {
        var parser = new CommandParser();

        bool result = parser.IsValidCommand("$MOVE,;");

        Assert.False(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForMinusWithoutDigits()
    {
        var parser = new CommandParser();

        bool result = parser.IsValidCommand("$MOVE,-;");

        Assert.False(result);
    }

    [Fact]
    public void IsValidCommand_ReturnsFalse_ForMinusTrailingAfterNumber()
    {
        var parser = new CommandParser();

        bool result = parser.IsValidCommand("$MOVE,100,-;");

        Assert.False(result);
    }
}
