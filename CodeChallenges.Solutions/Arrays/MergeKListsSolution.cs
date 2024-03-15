using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.Solutions;

public class MergeKListsSolution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length is 0) 
            return null;

        if (lists.Length is 1) 
            return lists[0];

        return Partition(lists, 0, lists.Length - 1);
    }

    private static ListNode Partition(ListNode[] list, int i, int j)
    {

        if (i == j)
            return list[i];

        var mid = (i + j + 1) / 2;

        var node1 = Partition(list, i, mid - 1);
        var node2 = Partition(list, mid, j);

        return MergeInOrder(node1, node2);
    }


    private static ListNode MergeInOrder(ListNode n1, ListNode n2)
    {
        if (n1 is null)
            return n2;

        if (n2 is null)
            return n1;

        if (n1.val <= n2.val)
        {
            n1.next = MergeInOrder(n1.next, n2);
            return n1;
        }

        n2.next = MergeInOrder(n1, n2.next);
        return n2;
    }
}
