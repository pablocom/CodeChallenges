using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;

namespace CodeChallenges.UnitTests;

public static class LinkedListAssert
{
    public static void HasValues(ListNode actualHead, int[] expectedNodeValues)
    {
        var actualValues = actualHead.ToArray();
        
        actualValues.Should().BeEquivalentTo(expectedNodeValues);
    }
}