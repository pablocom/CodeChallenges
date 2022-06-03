using CodeChallenges.Solutions;
using CodeChallenges.Solutions.BinaryTrees;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class GoodNodesTests
{
    [Test]
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
        Assert.That(result, Is.EqualTo(expected));
    }
        
    [Test]
    public void Test2()
    {
        var root = new LeetCodeTreeNode(3);
            
        root.left = new LeetCodeTreeNode(3);
            
        root.left.left = new LeetCodeTreeNode(4);
        root.left.right = new LeetCodeTreeNode(2);

        var result = GoodNodesFinder.GoodNodes(root);

        var expected = 3;
        Assert.That(result, Is.EqualTo(expected));
    }
        
    [Test]
    public void Test3()
    {
        var root = new LeetCodeTreeNode(3);
            
        root.left = new LeetCodeTreeNode(4);
            
        root.left.left = new LeetCodeTreeNode(3);

        var result = GoodNodesFinder.GoodNodes(root);

        var expected = 2;
        Assert.That(result, Is.EqualTo(expected));
    }
}