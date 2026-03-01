using CodeChallenges.Solutions.BinaryTrees;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public sealed class ValidBstTests
{
    [Fact]
    public void ValidatesBinarySearchTree()
    {
        var root = Node(1)
            .WithLeft(Node(0)
                .WithLeft(Node(-2)))
            .WithRight(Node(3))
            .Build();

        var result = ValidBST.IsValidBinarySearchTreeBfs(root);

        result.Should().BeTrue();
    }

    [Fact(Skip = "Incomplete")]
    public void NotValidBst()
    {
        var root = Node(5)
            .WithLeft(Node(1)
                .WithLeft(Node(3)))
            .WithRight(Node(6))
            .Build();

        var result = ValidBST.IsValidBinarySearchTreeBfs(root);

        result.Should().BeTrue();
    }
}
