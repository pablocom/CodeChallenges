using CodeChallenges.Solutions;
using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class RemoveNthFromEndTests
{
    // removes the 3rd node from a 7 length linked list
    [Test]
    public void RemoveNthFromEndTest1()
    {
        var linkedList = ListNodeBuilder.From(1, 2, 3, 4, 5, 6, 7).Build();

        var result = new RemoveNthFromEnd().Solve(linkedList, 3);

        LinkedListAssert.HasValues(result, new[] {1, 2, 3, 4, 5, 6, 7});
    }
}