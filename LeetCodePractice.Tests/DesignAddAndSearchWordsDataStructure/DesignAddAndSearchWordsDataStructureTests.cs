using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class DesignAddAndSearchWordsDataStructureTests
{
    [Fact]
    public void WordDictionary_Example1_SearchWorks()
    {
        var wd = new DesignAddAndSearchWordsDataStructure();
        wd.AddWord("bad");
        wd.AddWord("dad");
        wd.AddWord("mad");
        Assert.False(wd.Search("pad"));
        Assert.True(wd.Search("bad"));
        Assert.True(wd.Search(".ad"));
        Assert.True(wd.Search("b.."));
    }

    [Fact]
    public void WordDictionary_DotOnly_MatchesAnyChar()
    {
        var wd = new DesignAddAndSearchWordsDataStructure();
        wd.AddWord("a");
        Assert.True(wd.Search("."));
        Assert.False(wd.Search(".."));
    }

    [Fact]
    public void WordDictionary_EmptyWord_AddedThenSearched()
    {
        var wd = new DesignAddAndSearchWordsDataStructure();
        wd.AddWord("hello");
        wd.AddWord("hello");
        Assert.False(wd.Search("world"));
        Assert.False(wd.Search("h.."));
    }
}


