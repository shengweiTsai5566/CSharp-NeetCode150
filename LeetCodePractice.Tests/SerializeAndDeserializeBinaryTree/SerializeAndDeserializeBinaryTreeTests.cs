using LeetCodePractice.Problems;
using Xunit;

namespace LeetCodePractice.Tests;

public class SerializeAndDeserializeBinaryTreeTests
{
    [Fact]
    public void Codec_Example1_RoundTrip()
    {
        var SerializeAndDeserializeBinaryTree = new SerializeAndDeserializeBinaryTree();
        var root = new TreeNode(1) { left = new TreeNode(2), right = new TreeNode(3) { left = new TreeNode(4), right = new TreeNode(5) } };
        var serialized = SerializeAndDeserializeBinaryTree.Serialize(root);
        var deserialized = SerializeAndDeserializeBinaryTree.Deserialize(serialized);
        Assert.Equal(1, deserialized.val);
        Assert.Equal(2, deserialized.left.val);
        Assert.Equal(3, deserialized.right.val);
        Assert.Equal(4, deserialized.right.left.val);
        Assert.Equal(5, deserialized.right.right.val);
    }

    [Fact]
    public void Codec_Empty_RoundTrip()
    {
        var SerializeAndDeserializeBinaryTree = new SerializeAndDeserializeBinaryTree();
        var serialized = SerializeAndDeserializeBinaryTree.Serialize(null!);
        Assert.Null(SerializeAndDeserializeBinaryTree.Deserialize(serialized));
    }

    [Fact]
    public void Codec_SingleNode_RoundTrip()
    {
        var SerializeAndDeserializeBinaryTree = new SerializeAndDeserializeBinaryTree();
        var root = new TreeNode(42);
        var serialized = SerializeAndDeserializeBinaryTree.Serialize(root);
        var deserialized = SerializeAndDeserializeBinaryTree.Deserialize(serialized);
        Assert.Equal(42, deserialized.val);
        Assert.Null(deserialized.left);
        Assert.Null(deserialized.right);
    }

    [Fact]
    public void Codec_LeftSkewed_RoundTrip()
    {
        var SerializeAndDeserializeBinaryTree = new SerializeAndDeserializeBinaryTree();
        var root = new TreeNode(1) { left = new TreeNode(2) { left = new TreeNode(3) } };
        var serialized = SerializeAndDeserializeBinaryTree.Serialize(root);
        var deserialized = SerializeAndDeserializeBinaryTree.Deserialize(serialized);
        Assert.Equal(1, deserialized.val);
        Assert.Equal(2, deserialized.left.val);
        Assert.Equal(3, deserialized.left.left.val);
    }
}


