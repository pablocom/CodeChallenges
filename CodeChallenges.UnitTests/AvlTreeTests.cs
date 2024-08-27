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
}