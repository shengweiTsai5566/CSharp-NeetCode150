using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class EncodeAndDecodeStringsTests
{
    private readonly EncodeAndDecodeStrings _solver = new();

    [Fact]
    public void EncodeDecode_Example1_RoundTrip()
    {
        var input = new List<string> { "hello", "world", "test" };
        var encoded = _solver.Encode(input);
        var decoded = _solver.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_WithEmptyStrings_RoundTrip()
    {
        var input = new List<string> { "", "a", "", "b" };
        var encoded = _solver.Encode(input);
        var decoded = _solver.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_SpecialChars_RoundTrip()
    {
        var input = new List<string> { "a#b", "c|d", "e\nf", "" };
        var encoded = _solver.Encode(input);
        var decoded = _solver.Decode(encoded);
        Assert.Equal(input, decoded);
    }

    [Fact]
    public void EncodeDecode_EmptyList_RoundTrip()
    {
        var input = new List<string>();
        var encoded = _solver.Encode(input);
        var decoded = _solver.Decode(encoded);
        Assert.Empty(decoded);
    }

    [Fact]
    public void EncodeDecode_LongStrings_RoundTrip()
    {
        var input = new List<string> { new string('x', 1000), new string('y', 1000) };
        var encoded = _solver.Encode(input);
        var decoded = _solver.Decode(encoded);
        Assert.Equal(input, decoded);
    }
}
