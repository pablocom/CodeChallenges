using CodeChallenges.Solutions.BinaryTrees;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public sealed class LevelOrderTraversalTests
{
    private readonly LevelOrderTraversal _sut = new();

    [Fact]
    public void ThreeLevelTree()
    {
        var root = Node(3)
            .WithLeft(Node(9))
            .WithRight(Node(20).WithLeft(Node(15)).WithRight(Node(7)))
            .Build();

        var result = _sut.LevelOrder(root);

        result.Count().ShouldBe(3);
        result[0].ShouldBe(new[] { 3 });
        result[1].ShouldBe(new[] { 9, 20 });
        result[2].ShouldBe(new[] { 15, 7 });
    }

    [Fact]
    public void SingleNode()
    {
        var root = Node(1).Build();

        var result = _sut.LevelOrder(root);

        result.Count().ShouldBe(1);
        result[0].ShouldBe(new[] { 1 });
    }

    [Fact]
    public void LeftSkewedTree()
    {
        var root = Node(1)
            .WithLeft(Node(2).WithLeft(Node(3)))
            .Build();

        var result = _sut.LevelOrder(root);

        result.Count().ShouldBe(3);
        result[0].ShouldBe(new[] { 1 });
        result[1].ShouldBe(new[] { 2 });
        result[2].ShouldBe(new[] { 3 });
    }

    [Fact]
    public void CompleteBinaryTree()
    {
        var root = Node(1)
            .WithLeft(Node(2).WithLeft(Node(4)).WithRight(Node(5)))
            .WithRight(Node(3).WithLeft(Node(6)).WithRight(Node(7)))
            .Build();

        var result = _sut.LevelOrder(root);

        result.Count().ShouldBe(3);
        result[0].ShouldBe(new[] { 1 });
        result[1].ShouldBe(new[] { 2, 3 });
        result[2].ShouldBe(new[] { 4, 5, 6, 7 });
    }
}
