using CodeChallenges.Solutions.BinaryTrees;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public class DeleteNodeInBinarySearchTreeTests
{
    [Fact]
    public void Test1()
    {
        var tree = Node(5)
            .WithLeft(Node(3)
                .WithLeft(Node(2))
                .WithRight(Node(4)))
            .WithRight(Node(6)
                .WithRight(Node(7)))
            .Build();

        var root = new DeleteNodeInBinarySearchTree().DeleteNode(tree, 3);

        root!.left!.val.Should().Be(4);
    }

    [Fact]
    public void Test2()
    {
        var tree = Node(10)
            .WithLeft(Node(5)
                .WithLeft(Node(2))
                .WithRight(Node(8)
                    .WithLeft(Node(7))
                    .WithRight(Node(9))))
            .WithRight(Node(17))
            .Build();

        var root = new DeleteNodeInBinarySearchTree().DeleteNode(tree, 5);

        root!.left!.val.Should().Be(7);
    }
}
