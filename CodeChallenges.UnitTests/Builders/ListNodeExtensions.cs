using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.UnitTests.Builders;

public static class ListNodeExtensions
{
    public static int[] ToArray(this ListNode head)
    {
        var list = new List<int>();

        ListNode? cursor = head; 
        while (cursor is not null)
        {
            list.Add(head.val);
            cursor = head.next;
        }

        return list.ToArray();
    }
}