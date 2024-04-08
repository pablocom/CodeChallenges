namespace CodeChallenges.Solutions.LinkedLists;

// https://leetcode.com/problems/reverse-nodes-in-k-group
public static class ReverseNodesInKGroups
{
    public static ListNode ReverseKGroup(ListNode head, int k)
    {
        if (k is 1)
            return head;

        var isFirstKGroup = true;
        var result = head;
        var currentNode = head;
        var currentGroupSize = 0;
        ListNode? groupCurrent = null;
        ListNode? tailOfLastReversedGroup = null;
        ListNode? previousTailOfLastReversedGroup = null;

        while (currentNode is not null)
        {
            groupCurrent ??= currentNode;
            currentGroupSize++;

            if (currentGroupSize < k)
            {
                currentNode = currentNode.next;
                continue;
            }

            var aux = currentNode.next;

            for (var i = 1; i <= k; i++)
            {
                var isTheFirstNodeToReverse = i is 1;
                if (isTheFirstNodeToReverse)
                {
                    previousTailOfLastReversedGroup = tailOfLastReversedGroup;
                    tailOfLastReversedGroup = groupCurrent;
                }

                var isTheLastNodeToReverse = i == k;
                if (isTheLastNodeToReverse)
                {
                    if (isFirstKGroup)
                        result = groupCurrent!;
                    else
                        previousTailOfLastReversedGroup!.next = currentNode;

                    currentNode = tailOfLastReversedGroup!.next;
                    groupCurrent!.next = aux;
                    break;
                }

                var groupNext = groupCurrent.next;
                groupCurrent.next = aux;
                aux = groupCurrent;
                groupCurrent = groupNext;
            }

            groupCurrent = null;
            isFirstKGroup = false;
            currentGroupSize = 0;
        }

        return result;
    }
}
