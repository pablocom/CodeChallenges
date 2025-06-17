using CodeChallenges.Solutions.BinaryTrees;

namespace CodeChallenges.UnitTests;

public sealed class ValidBstTests
{
    [Fact]
    public void ValidatesBinarySearchTree()
    {
        var binarySearchTreeRoot = new LeetCodeTreeNode(1);

        binarySearchTreeRoot.left = new LeetCodeTreeNode(0, new LeetCodeTreeNode(-2));
        binarySearchTreeRoot.right = new LeetCodeTreeNode(3);

        var isValidBinarySearchTreeBfs = ValidBST.IsValidBinarySearchTreeBfs(binarySearchTreeRoot);

        isValidBinarySearchTreeBfs.Should().BeTrue();
    }
        
    [Fact(Skip = "Incomplete")]
    public void NotValidBst()
    {
        var binarySearchTreeRoot = new LeetCodeTreeNode(5);

        binarySearchTreeRoot.left = new LeetCodeTreeNode(1, new LeetCodeTreeNode(3));
        binarySearchTreeRoot.right = new LeetCodeTreeNode(6);

        var isValidBinarySearchTreeBfs = ValidBST.IsValidBinarySearchTreeBfs(binarySearchTreeRoot);

        isValidBinarySearchTreeBfs.Should().BeTrue();
    }
}