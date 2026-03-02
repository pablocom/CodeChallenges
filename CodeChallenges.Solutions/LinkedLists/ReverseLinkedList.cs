namespace CodeChallenges.Solutions.LinkedLists;

public static class ReverseLinkedList
{
    public static ListNode Solve(ListNode head)
    {
        ListNode previous = null!;
        var current = head;
        var next = head.next;

        while (next is not null)
        {
            current.next = previous;

            previous = current;
            current = next;
            next = next.next;
        }

        current.next = previous;
        return current;
    }
}