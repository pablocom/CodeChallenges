using CodeChallenges.Solutions;
using CodeChallenges.Solutions.BinaryTrees;

namespace CodeChallenges.UnitTests;

public sealed class LowestCommonAncestorInBinaryTreeTests
{
    [Fact]
    public void Test1()
    {
        LeetCodeTreeNode bstRoot = new(3);

        bstRoot.left = new(5);
        bstRoot.right = new(1);

        bstRoot.left.left = new(6);
        bstRoot.left.right = new(2);
        bstRoot.left.right.left = new(7);
        bstRoot.left.right.right = new(4);

        bstRoot.right = new(1);
        bstRoot.right.left = new(0);
        bstRoot.right.right = new(8);

        var lowestCommonAncestor = new LowestCommonAncestorInBinaryTree().LowestCommonAncestor(bstRoot, bstRoot.left, bstRoot.right);

        lowestCommonAncestor.Should().Be(bstRoot);
    }
    
    [Fact]
    public void Test2()
    {
        LeetCodeTreeNode bstRoot = new(3);

        bstRoot.left = new(5);

        bstRoot.left.left = new(6);
        bstRoot.left.right = new(2);
        bstRoot.left.right.left = new(7);
        bstRoot.left.right.right = new(4);

        bstRoot.right = new(1);
        bstRoot.right.left = new(0);
        bstRoot.right.right = new(8);

        var lowestCommonAncestor = new LowestCommonAncestorInBinaryTree().LowestCommonAncestor(bstRoot, bstRoot.left.left, bstRoot.left.right);

        lowestCommonAncestor.Should().Be(bstRoot.left);
    }

    [Fact]
    public void Test3()
    {
        LeetCodeTreeNode bstRoot = new(3);

        bstRoot.right = new(1);
        bstRoot.right.left = new(0);
        bstRoot.right.right = new(8);

        var lowestCommonAncestor = new LowestCommonAncestorInBinaryTree().LowestCommonAncestor(bstRoot, bstRoot.right.left, bstRoot.right.right);

        lowestCommonAncestor.Should().Be(bstRoot.right);
    }
}
