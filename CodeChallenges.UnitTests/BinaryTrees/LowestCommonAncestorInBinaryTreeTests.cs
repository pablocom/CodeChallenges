using CodeChallenges.Solutions.BinaryTrees;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public sealed class LowestCommonAncestorInBinaryTreeTests
{
    [Fact]
    public void Test1()
    {
        var root = Node(3)
            .WithLeft(Node(5)
                .WithLeft(Node(6))
                .WithRight(Node(2)
                    .WithLeft(Node(7))
                    .WithRight(Node(4))))
            .WithRight(Node(1)
                .WithLeft(Node(0))
                .WithRight(Node(8)))
            .Build();

        var result = new LowestCommonAncestorInBinaryTree()
            .LowestCommonAncestor(root, root.left!, root.right!);

        result.ShouldBe(root);
    }

    [Fact]
    public void Test2()
    {
        var root = Node(3)
            .WithLeft(Node(5)
                .WithLeft(Node(6))
                .WithRight(Node(2)
                    .WithLeft(Node(7))
                    .WithRight(Node(4))))
            .WithRight(Node(1)
                .WithLeft(Node(0))
                .WithRight(Node(8)))
            .Build();

        var result = new LowestCommonAncestorInBinaryTree()
            .LowestCommonAncestor(root, root.left!.left!, root.left!.right!);

        result.ShouldBe(root.left);
    }

    [Fact]
    public void Test3()
    {
        var root = Node(3)
            .WithRight(Node(1)
                .WithLeft(Node(0))
                .WithRight(Node(8)))
            .Build();

        var result = new LowestCommonAncestorInBinaryTree()
            .LowestCommonAncestor(root, root.right!.left!, root.right!.right!);

        result.ShouldBe(root.right);
    }
}
