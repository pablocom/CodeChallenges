using CodeChallenges.Solutions.BinaryTrees;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public sealed class NodesEqualToAverageOfSubtreeTests
{
    [Fact]
    public void SingleNode_AlwaysMatchesItself()
    {
        var root = Node(4).Build();

        var result = NodesEqualToAverageOfSubtree.Solve(root);

        result.ShouldBe(1);
    }

    [Fact]
    public void FullTree_CountsAllMatchingNodes()
    {
        //        4          ← avg(4,8,5,0,1,6) = 24/6 = 4  ✓
        //       / \
        //      8   5        ← avg(8,0,1) = 9/3 = 3 ✗  |  avg(5,6) = 11/2 = 5 ✓
        //     / \   \
        //    0   1   6      ← all leaves: avg = self          ✓ ✓ ✓
        var root = Node(4)
            .WithLeft(Node(8)
                .WithLeft(Node(0))
                .WithRight(Node(1)))
            .WithRight(Node(5)
                .WithRight(Node(6)))
            .Build();

        var result = NodesEqualToAverageOfSubtree.Solve(root);

        result.ShouldBe(5);
    }

    [Fact]
    public void ThreeNodeTree_OnlyLeavesMatch()
    {
        //     1             ← avg(1,2,3) = 6/3 = 2 ✗
        //    / \
        //   2   3           ← leaves always match themselves ✓ ✓
        var root = Node(1)
            .WithLeft(Node(2))
            .WithRight(Node(3))
            .Build();

        var result = NodesEqualToAverageOfSubtree.Solve(root);

        result.ShouldBe(2);
    }

    [Fact]
    public void UnbalancedTree_OnlyLeafMatches()
    {
        //   10              ← avg(10,3) = 13/2 = 6 ✗
        //   /
        //  3                ← avg(3) = 3 ✓
        var root = Node(10)
            .WithLeft(Node(3))
            .Build();

        var result = NodesEqualToAverageOfSubtree.Solve(root);

        result.ShouldBe(1);
    }
}
