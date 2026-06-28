using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class ImplementTrieTests
{
    [Fact]
    public void Trie_Example1_Works()
    {
        var trie = new ImplementTrie();
        trie.Insert("apple");
        Assert.True(trie.Search("apple"));
        Assert.False(trie.Search("app"));
        Assert.True(trie.StartsWith("app"));
        trie.Insert("app");
        Assert.True(trie.Search("app"));
    }

    [Fact]
    public void Trie_NotFound_ReturnsFalse()
    {
        var trie = new ImplementTrie();
        trie.Insert("hello");
        Assert.False(trie.Search("world"));
        Assert.False(trie.StartsWith("x"));
    }

    [Fact]
    public void Trie_PrefixButNotWord_StartsWithTrue_SearchFalse()
    {
        var trie = new ImplementTrie();
        trie.Insert("apple");
        Assert.True(trie.StartsWith("app"));
        Assert.False(trie.Search("app"));
    }
}
