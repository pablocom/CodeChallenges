using CodeChallenges.Solutions;
using CodeChallenges.Solutions.LinkedLists;
using CodeChallenges.UnitTests.Builders;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public static class LinkedListAssert
{
    public static void HasValues(ListNode actualHead, int[] expectedNodeValues)
    {
        var actualValues = actualHead.ToArray();
        CollectionAssert.AreEquivalent(expectedNodeValues, actualValues);
    }
}