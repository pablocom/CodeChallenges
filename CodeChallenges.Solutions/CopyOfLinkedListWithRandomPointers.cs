namespace CodeChallenges.Solutions;

public class CopyOfLinkedListWithRandomPointers
{
    public ListNode CopyRandomList(ListNode head)
    {
        var headCopy = head;
        var newHead = CreateCopyOfLinkedList(headCopy);

        FillRandomPointersInCopy(headCopy, newHead);
        PointOldNodesNextPointersToNewNodes(headCopy, newHead);
        ChangeNewRandomPointerToNextPointers(newHead);

        return newHead;
    }

    private ListNode CreateCopyOfLinkedList(ListNode head)
    {
        var newHead = new ListNode(head.val);

        var currentOldNode = head.next;
        var currentNewNode = newHead;
        while (currentOldNode != null)
        {
            currentNewNode.next = new ListNode(currentOldNode.val);
            currentNewNode = currentNewNode.next;
            currentOldNode = currentOldNode.next;
        }

        return newHead;
    }

    private void FillRandomPointersInCopy(ListNode head, ListNode newHead)
    {
        var currentNode = head;
        var currentNewNode = newHead;
        while (currentNode != null)
        {
            currentNewNode.random = currentNode.random;
            currentNode = currentNode.next;
            currentNewNode = currentNewNode.next;
        }
    }

    private void PointOldNodesNextPointersToNewNodes(ListNode head, ListNode newHead)
    {
        var currentNode = head;
        var currentNewNode = newHead;
        while (currentNode != null)
        {
            var tempCurrentNext = currentNode.next;
            currentNode.next = currentNewNode;

            currentNode = tempCurrentNext;
            currentNewNode = currentNewNode.next;
        }
    }

    private void ChangeNewRandomPointerToNextPointers(ListNode newHead)
    {
        var currentNewNode = newHead;
        while (currentNewNode != null)
        {
            currentNewNode.random = currentNewNode.random?.next;
            currentNewNode = currentNewNode.next;
        }
    }
}