namespace CodeChallenges.Solutions.LinkedLists;

public static class MergeTwoSortedLists
{
    public static ListNode? Merge(ListNode? list1, ListNode? list2)
    {
        var beginning = new ListNode(-1);
        var cursor = beginning;

        while (list1 != null || list2 != null) 
        {
            var list1Val = list1?.val ?? int.MaxValue;
            var list2Val = list2?.val ?? int.MaxValue;

            if (list1Val < list2Val) 
            {
                cursor!.next = list1;
                cursor = list1;
                list1 = list1!.next;
            }
            else 
            {
                cursor!.next = list2;
                cursor = list2;
                list2 = list2!.next;
            }
        }

        return beginning.next;
    }
}