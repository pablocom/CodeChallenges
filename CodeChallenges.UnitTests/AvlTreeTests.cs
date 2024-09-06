using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class AvlTreeTests
{
    [Fact]
    public void ItsInitializedEmpty()
    {
        var tree = new AvlTree<int>();
        
        tree.InOrderTraversal().Should().BeEmpty();
        tree.Height.Should().Be(-1);
    }
    
    [Fact]
    public void ItsInitializedFromACollectionOfItems()
    {
        var tree = new AvlTree<int>([1, 2, 3]);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 3]);
        tree.Height.Should().Be(1);
    }
    
    [Fact]
    public void InsertsFirstItem()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert(1);
        
        tree.InOrderTraversal().Should().Equal([1]);
        tree.Height.Should().Be(0);
    }
    
    [Fact]
    public void InsertsTwoItemsMaintainingAllValuesInOrder()
    {
        var tree = new AvlTree<int>();
        
        tree.Insert(2);
        tree.Insert(1);
        
        tree.InOrderTraversal().Should().Equal([1, 2]);
        tree.Height.Should().Be(1);
        tree.Balance.Should().Be(1);
    }
    
    [Fact]
    public void InsertsMultipleItems()
    {
        var tree = new AvlTree<int>();

        tree.Insert([3, 2, 1, 4]);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 3, 4]);
        tree.Height.Should().Be(2);
    }
    
    [Fact]
    public void AddsMultipleItemsForcingRightRotation()
    {
        var tree = new AvlTree<char>();
        
        tree.Insert('b');
        tree.Insert('a');
        tree.Insert('c');
        
        tree.InOrderTraversal().Should().Equal(['a', 'b', 'c']);
        tree.Height.Should().Be(1);
    }
    
    [Fact]
    public void RemovesItemAndRebalanceTree()
    {
        var tree = new AvlTree<int>([1, 2, 3, 4]);
        
        tree.Remove(3);
        
        tree.InOrderTraversal().Should().Equal([1, 2, 4]);
        tree.Height.Should().Be(1);
    }
}