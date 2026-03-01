using CodeChallenges.Solutions.BinaryTrees;
using static CodeChallenges.UnitTests.BinaryTrees.BinaryTreeBuilder;

namespace CodeChallenges.UnitTests.BinaryTrees;

public class GoodNodesTests
{
    [Fact]
    public void Test1()
    {
        var root = Node(3)
            .WithLeft(Node(1)
                .WithLeft(Node(3)))
            .WithRight(Node(4)
                .WithLeft(Node(1))
                .WithRight(Node(5)))
            .Build();

        var result = GoodNodesFinder.GoodNodes(root);

        result.Should().Be(4);
    }

    [Fact]
    public void Test2()
    {
        var root = Node(3)
            .WithLeft(Node(3)
                .WithLeft(Node(4))
                .WithRight(Node(2)))
            .Build();

        var result = GoodNodesFinder.GoodNodes(root);

        result.Should().Be(3);
    }

    [Fact]
    public void Test3()
    {
        var root = Node(3)
            .WithLeft(Node(4)
                .WithLeft(Node(3)))
            .Build();

        var result = GoodNodesFinder.GoodNodes(root);

        result.Should().Be(2);
    }
}
