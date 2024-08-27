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
        
        tree.Insert(1);
        tree.Insert(3);
        tree.Insert(2);
        tree.Insert(4);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 3, 4]);
    }
    
    [Fact]
    public void AddsMultipleItemsForcingRightRotation()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert(3);
        tree.Insert(2);
        tree.Insert(1);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 3]);
    }
}