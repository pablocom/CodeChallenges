namespace CodeChallenges.Solutions.LinkedLists;

public sealed class RemoveNthNodeFromList
{
    public ListNode? RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode? nodeToChangeFinder = null;
        var currentNode = head;
        var distanceMoved = 0;

        if (n is 1 && head is { next: null })
            return null;
            
        while (currentNode.next is not null)
        {
            currentNode = currentNode.next;
            distanceMoved++;
            
            if (distanceMoved >= n) 
                nodeToChangeFinder = nodeToChangeFinder is not null 
                    ? nodeToChangeFinder.next 
                    : head;
        }

        if (nodeToChangeFinder is null)
            return head.next;
        
        nodeToChangeFinder.next = nodeToChangeFinder.next!.next;
        
        return head;
    }
}