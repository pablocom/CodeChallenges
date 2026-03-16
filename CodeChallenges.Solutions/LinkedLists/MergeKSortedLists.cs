namespace CodeChallenges.Solutions.LinkedLists;

public static class MergeKSortedLists
{
    public static ListNode? Solve(ListNode[] lists)
    {
        var nodeValueTuples = lists.Select(node => (node, node.val));
        var priorityQueue = new PriorityQueue<ListNode, int>(nodeValueTuples);

        var rootNode = priorityQueue.Dequeue();
        if (rootNode.next is not null)
            priorityQueue.Enqueue(rootNode.next, rootNode.next.val);

        var currentNode = rootNode;

        while (priorityQueue.Count > 0)
        {
            currentNode.next = priorityQueue.Dequeue();
            currentNode = currentNode.next;

            if (currentNode.next is not null)
                priorityQueue.Enqueue(currentNode.next, currentNode.next.val);
        }

        return rootNode;
    }

    public static ListNode? SolveOptimized(ListNode[] lists)
    {
        if (lists.Length is 0)
            return null;

        var count = lists.Length;

        while (count > 1)
        {
            var mergedCount = 0;

            for (var i = 0; i < count; i += 2)
            {
                var right = i + 1 < count ? lists[i + 1] : null;
                lists[mergedCount++] = MergeTwoSortedLists(lists[i], right);
            }

            count = mergedCount;
        }

        return lists[0];
    }

    private static ListNode? MergeTwoSortedLists(ListNode? left, ListNode? right)
    {
        if (left is null) return right;
        if (right is null) return left;

        ListNode head;

        if (left.val <= right.val)
        {
            head = left;
            left = left.next;
        }
        else
        {
            head = right;
            right = right.next;
        }

        var tail = head;

        while (left is not null && right is not null)
        {
            if (left.val <= right.val)
            {
                tail.next = left;
                left = left.next;
            }
            else
            {
                tail.next = right;
                right = right.next;
            }

            tail = tail.next;
        }

        tail.next = left ?? right;

        return head;
    }
}
