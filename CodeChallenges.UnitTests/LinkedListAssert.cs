using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public static class LinkedListAssert
{
    public static void HasValues(ListNode actualHead, int[] expectedNodeValues)
    {
        var iterableNode = actualHead;
        foreach (var nodeValue in expectedNodeValues)
        {
            Assert.That(iterableNode.val, Is.EqualTo(nodeValue));
            iterableNode = iterableNode.next;
        }
    }
}