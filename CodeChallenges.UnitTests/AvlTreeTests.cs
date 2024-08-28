using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class AvlTreeTests
{
    [Fact]
    public void ItsInitializedEmpty()
    {
        var tree = new AvlTree<int>();
        
        tree.InOrderTraversal().Should().BeEmpty();
    }
    
    [Fact]
    public void AddsFirstItem()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert(1);
        
        tree.InOrderTraversal().Should().Equal([1]);
    }
    
    [Fact]
    public void AddsTwoItems()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert(2);
        tree.Insert(1);
        
        tree.InOrderTraversal().Should().Equal([1, 2]);
    }
    
    [Fact]
    public void AddsMultipleItemsAndKeepsThemInOrder()
    {
        var tree = new AvlTree<int>();

        tree.Insert([3, 2, 1, 4]);
        
        tree.InOrderTraversal().ToArray().Should().Equal([1, 2, 3, 4]);
    }
    
    [Fact]
    public void AddsMultipleItemsForcingRightRotation()
    {
        var tree = new AvlTree<char>();
        
        tree.Insert('b');
        tree.Insert('a');
        tree.Insert('c');
        
        tree.InOrderTraversal().Should().Equal(['a', 'b', 'c']);
    }
    
    [Fact]
    public void Test2()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert([1, 2, 3, 4]);
        
        tree.Remove(3);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 4]);
        tree.Height.Should().Be(1);
    }
    
    [Fact]
    public void Test3()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert([1, 2, 3, 4]);
        
        tree.Remove(3);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 4]);
    }
    
    [Fact]
    public void Test4()
    {
        var random = Random.Shared;
        
        var tree = new AvlTree<int>();
        tree.Insert(Enumerable.Range(0, 10000).ToArray());
        
        for (var i = 3; i < 10000; i++)
        {
            tree.Remove(random.Next(0, 10000));

            tree.Balance.Should().BeLessOrEqualTo(1).And.BeGreaterOrEqualTo(-1);
        }
    }
    
    [Fact]
    public void Test5()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert([10, 20, 50, 60, 70, 80, 55]);
        
        tree.Remove(70);
        
        tree.InOrderTraversal().Should().Equal([10, 20, 50, 55, 60, 80]);
    }
}