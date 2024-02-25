using CodeChallenges.Solutions;
using CodeChallenges.Solutions.BinaryTrees;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

[TestFixture]
public class ValidBstTests
{
    [Test]
    public void ValidatesBinarySearchTree()
    {
        var binarySearchTreeRoot = new LeetCodeTreeNode(1);

        binarySearchTreeRoot.left = new LeetCodeTreeNode(0, new LeetCodeTreeNode(-2));
        binarySearchTreeRoot.right = new LeetCodeTreeNode(3);

        var isValidBinarySearchTreeBfs = ValidBST.IsValidBinarySearchTreeBfs(binarySearchTreeRoot);
            
        Assert.That(isValidBinarySearchTreeBfs);
    }
        
    [Test]
    public void NotValidBst()
    {
        var binarySearchTreeRoot = new LeetCodeTreeNode(5);

        binarySearchTreeRoot.left = new LeetCodeTreeNode(1, new LeetCodeTreeNode(3));
        binarySearchTreeRoot.right = new LeetCodeTreeNode(6);

        var isValidBinarySearchTreeBfs = ValidBST.IsValidBinarySearchTreeBfs(binarySearchTreeRoot);
            
        Assert.That(isValidBinarySearchTreeBfs);
    }
}