namespace CodeChallenges.Solutions.LinkedLists;

// https://leetcode.com/problems/reverse-nodes-in-k-group
public static class ReverseNodesInKGroups
{
    public static ListNode ReverseKGroup(ListNode head, int k)
    {
        if (k is 1)
            return head;

        var isFirstReverse = true;

        ListNode result = head;
        ListNode? groupCurrent = null;
        ListNode? tailOfLastReversedGroup = null;
        ListNode? previousTailOfLastReversedGroup = null;
        var currentNode = head;
        var currentGroupSize = 0;

        while (currentNode is not null)
        {
            var hasReversedInThisIteration = false;
            groupCurrent ??= currentNode;
            currentGroupSize++;

            if (currentGroupSize == k)
            {
                hasReversedInThisIteration = true;

                if (tailOfLastReversedGroup is null)
                    tailOfLastReversedGroup = head;

                var groupIterationCount = 0;
                var aux = currentNode.next;
                var groupNext = groupCurrent.next;

                while (groupIterationCount < k) 
                {
                    if (groupIterationCount is 0)
                    {
                        previousTailOfLastReversedGroup = tailOfLastReversedGroup;
                        tailOfLastReversedGroup = groupCurrent;
                    }

                    if (groupIterationCount == k - 1)
                    {
                        if (isFirstReverse)
                            result = groupCurrent!;

                        var next2 = tailOfLastReversedGroup!.next;

                        if (!isFirstReverse)
                            previousTailOfLastReversedGroup!.next = currentNode;

                        currentNode = next2;
                        groupCurrent!.next = aux;
                        break;
                    }

                    groupNext = groupCurrent!.next;
                    groupCurrent.next = aux;
                    aux = groupCurrent;
                    groupCurrent = groupNext;

                    groupIterationCount++;
                }

                groupCurrent = null;
                isFirstReverse = false;
                currentGroupSize = 0;
            }

            if (!hasReversedInThisIteration)
                currentNode = currentNode.next;
        }

        return result;
    }
}
