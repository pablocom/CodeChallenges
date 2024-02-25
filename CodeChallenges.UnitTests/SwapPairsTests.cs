using System;
using CodeChallenges.Solutions;
using CodeChallenges.UnitTests.Builders;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class SwapPairsTests
{
    [Test]
    public void ListWithEvenLength()
    {
        var head = ListNodeBuilder.From(1, 2, 3, 4).Build();

        var newHead = new SwapPairs().Solve(head);
        
        LinkedListAssert.HasValues(newHead, new []{ 2, 1, 4, 3 });
    }
    
    [Test]
    public void ListWithOddLength()
    {
        var head = ListNodeBuilder.From(1, 2, 3, 4, 5).Build();

        var newHead = new SwapPairs().Solve(head);
        
        LinkedListAssert.HasValues(newHead, new []{ 2, 1, 4, 3, 5 });
    }
    
    [Test]
    public void ListWithOddLengthLessThan3()
    {
        var head = ListNodeBuilder.From(1, 2, 3).Build();

        var newHead = new SwapPairs().Solve(head);
        
        LinkedListAssert.HasValues(newHead, new []{ 2, 1, 3 });
    }
    
    [Test]
    public void IfHeadIsNull_ReturnsNull()
    {
        var newHead = new SwapPairs().Solve(null);
        
        Assert.That(newHead is null);
    }
    
    [Test]
    public void OnlyOneElementInLinkedList_ReturnsHead()
    {
        var head = ListNodeBuilder.From(1).Build();

        var newHead = new SwapPairs().Solve(head);
        
        LinkedListAssert.HasValues(newHead, new int[1] { 1 });
    }
}