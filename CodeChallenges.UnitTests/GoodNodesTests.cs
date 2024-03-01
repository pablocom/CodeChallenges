using CodeChallenges.Solutions.BinaryTrees;

namespace CodeChallenges.UnitTests;

public class GoodNodesTests
{
    [Fact]
    public void Test1()
    {
        var root = new LeetCodeTreeNode(3)
        {
            left = new LeetCodeTreeNode(1)
            {
                left = new LeetCodeTreeNode(3)
            },
            right = new LeetCodeTreeNode(4)
            {
                left = new LeetCodeTreeNode(1), 
                right = new LeetCodeTreeNode(5)
            }
        };

        var result = GoodNodesFinder.GoodNodes(root);

        var expected = 4;
        result.Should().Be(expected);
    }
        
    [Fact]
    public void Test2()
    {
        var root = new LeetCodeTreeNode(3)
        {
            left = new(3)
            {
                left = new(4),
                right = new(2)
            }
        };

        var result = GoodNodesFinder.GoodNodes(root);

        var expected = 3;
        result.Should().Be(expected);
    }
        
    [Fact]
    public void Test3()
    {
        var root = new LeetCodeTreeNode(3)
        {
            left = new(4)
            {
                left = new(3)
            }
        };

        var result = GoodNodesFinder.GoodNodes(root);

        var expected = 2;
        result.Should().Be(expected);
    }
}