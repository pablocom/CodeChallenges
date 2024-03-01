using CodeChallenges.Solutions;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests;

public class SwapPairsTests
{
    [Fact]
    public void ListWithEvenLength()
    {
        var head = ListNodeBuilder.From(1, 2, 3, 4).Build();

        var newHead = new SwapPairs().Solve(head);

        newHead.Should().BeEquivalentTo([2, 1, 4, 3]);
    }
    
    [Fact]
    public void ListWithOddLength()
    {
        var head = ListNodeBuilder.From(1, 2, 3, 4, 5).Build();

        var newHead = new SwapPairs().Solve(head);
        
        newHead.Should().BeEquivalentTo([2, 1, 4, 3, 5]);
    }
    
    [Fact]
    public void ListWithOddLengthLessThan3()
    {
        var head = ListNodeBuilder.From(1, 2, 3).Build();

        var newHead = new SwapPairs().Solve(head);
        
        newHead.Should().BeEquivalentTo([2, 1, 3]);
    }
    
    [Fact]
    public void IfHeadIsNull_ReturnsNull()
    {
        var newHead = new SwapPairs().Solve(null);

        newHead.Should().BeNull();
    }
    
    [Fact]
    public void OnlyOneElementInLinkedList_ReturnsHead()
    {
        var head = ListNodeBuilder.From(1).Build();

        var newHead = new SwapPairs().Solve(head);
        
        newHead.Should().BeEquivalentTo([1]);
    }
}