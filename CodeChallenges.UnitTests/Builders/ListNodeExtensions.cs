using System.Collections.Generic;
using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.UnitTests.Builders;

public static class ListNodeExtensions
{
    public static int[] ToArray(this ListNode head)
    {
        var list = new List<int>();

        var currentNode = head;
        while (head is not null)
        {
            list.Add(head.val);
            head = head.next;
        }

        return list.ToArray();
    }
}