using CodeChallenges.Solutions.BinaryTrees;
using CodeChallenges.Solutions.Strings;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public sealed class BinaryTreeUniquePathsToLeavesTests
{
    [Fact]
    public void SingleNode_ReturnsSinglePathWithItsValue()
    {
        var root = Node(5).Build();

        var result = BinaryTreeUniquePathsToLeaves.Solve(root);

        result.ShouldBe(new[] { "5" });
    }

    [Fact]
    public void TwoLeavesTree_ReturnsBothPaths()
    {
        //   1
        //  / \
        // 2   3
        var root = Node(1)
            .WithLeft(Node(2))
            .WithRight(Node(3))
            .Build();

        var result = BinaryTreeUniquePathsToLeaves.Solve(root);

        result.ShouldBe(new[] { "1->2", "1->3" });
    }

    [Fact]
    public void LeftOnlyChain_ReturnsSinglePath()
    {
        //  1
        //  |
        //  2
        //  |
        //  3
        var root = Node(1)
            .WithLeft(Node(2)
                .WithLeft(Node(3)))
            .Build();

        var result = BinaryTreeUniquePathsToLeaves.Solve(root);

        result.ShouldBe(new[] { "1->2->3" });
    }

    [Fact]
    public void AsymmetricTree_ReturnsPathsInLeftFirstOrder()
    {
        //    1
        //   / \
        //  2   3
        //   \
        //    5
        var root = Node(1)
            .WithLeft(Node(2)
                .WithRight(Node(5)))
            .WithRight(Node(3))
            .Build();

        var result = BinaryTreeUniquePathsToLeaves.Solve(root);

        result.ShouldBe(new[] { "1->2->5", "1->3" });
    }

    [Fact]
    public void FullThreeLevelTree_ReturnsAllLeafPaths()
    {
        //        1
        //       / \
        //      2   3
        //     / \   \
        //    4   5   6
        var root = Node(1)
            .WithLeft(Node(2)
                .WithLeft(Node(4))
                .WithRight(Node(5)))
            .WithRight(Node(3)
                .WithRight(Node(6)))
            .Build();

        var result = BinaryTreeUniquePathsToLeaves.Solve(root);

        result.ShouldBe(new[] { "1->2->4", "1->2->5", "1->3->6" });
    }
}
