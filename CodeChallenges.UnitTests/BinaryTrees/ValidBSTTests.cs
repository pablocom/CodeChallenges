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

        result.ShouldBeTrue();
    }

}
