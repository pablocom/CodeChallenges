using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests;

public class RemoveNthFromEndTests
{
    [Fact]
    public void RemoveNthFromEndTest0()
    {
        var linkedList = ListNodeBuilder.From(1, 2, 3, 4, 5).Build()!;

        var result = new RemoveNthNodeFromList().RemoveNthFromEnd(linkedList, 2);

        result.Should().BeEquivalentTo([1, 2, 3, 5]);
    }
    
    [Fact]
    public void RemoveNthFromEndTest1()
    {
        var linkedList = ListNodeBuilder.From(1, 2, 2, 3, 4, 5).Build()!;

        var result = new RemoveNthNodeFromList().RemoveNthFromEnd(linkedList, 3);

        result.Should().BeEquivalentTo([1, 2, 2, 4, 5]);
    }
    
    [Fact]
    public void RemoveNthFromEndTest2()
    {
        var linkedList = ListNodeBuilder.From(1).Build()!;

        var result = new RemoveNthNodeFromList().RemoveNthFromEnd(linkedList, 1);

        result.Should().BeNull();
    }
    
    [Fact]
    public void RemoveNthFromEndTest3()
    {
        var linkedList = ListNodeBuilder.From(1, 2).Build()!;

        var result = new RemoveNthNodeFromList().RemoveNthFromEnd(linkedList, 1);

        result.Should().BeEquivalentTo([1]);
    }
    
    [Fact]
    public void RemoveNthFromEndTest4()
    {
        var linkedList = ListNodeBuilder.From(1, 2).Build()!;

        var result = new RemoveNthNodeFromList().RemoveNthFromEnd(linkedList, 2);

        result.Should().BeEquivalentTo([2]);
    }
    
    [Fact]
    public void RemoveNthFromEndTest5()
    {
        var linkedList = ListNodeBuilder.From(1, 2, 3).Build()!;

        var result = new RemoveNthNodeFromList().RemoveNthFromEnd(linkedList, 3);

        result.Should().BeEquivalentTo([2, 3]);
    }
}