using CodeChallenges.Solutions;
using CodeChallenges.Solutions.BinaryTrees;

namespace CodeChallenges.UnitTests;
public class DeleteNodeInBinarySearchTreeTests
{
    [Fact]
    public void Test1()
    {
        var tree = new LeetCodeTreeNode(5);
        tree.left = new LeetCodeTreeNode(3);
        tree.right = new LeetCodeTreeNode(6);

        tree.left.left = new LeetCodeTreeNode(2);
        tree.left.right = new LeetCodeTreeNode(4);

        tree.right.right = new LeetCodeTreeNode(7);

        var root = new DeleteNodeInBinarySearchTree().DeleteNode(tree, 3);

        root!.left!.val.Should().Be(4);
    }

    [Fact]
    public void Test2()
    {
        var tree = new LeetCodeTreeNode(10);
        tree.left = new(5);
        tree.right = new(17);

        tree.left.left = new(2);
        tree.left.right = new(8);

        tree.left.right.left = new(7);
        tree.left.right.right = new(9);


        var root = new DeleteNodeInBinarySearchTree().DeleteNode(tree, 5);

        root!.left!.val.Should().Be(7);
    }
}
