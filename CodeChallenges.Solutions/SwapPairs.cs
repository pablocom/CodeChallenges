using System;
using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.Solutions;

public class SwapPairs
{
    public ListNode? Solve(ListNode? head) 
    {
        if (head?.next is null)
            return head;
        
        var newHead = head.next;

        ListNode? carriedNode = null;
        var previousNode = head;
        var currentNode = head.next;
        
        while (currentNode is not null)
        {
            var nextNode = currentNode.next;
            
            if (carriedNode is not null)
            {
                carriedNode.next = currentNode;
            }
            
            currentNode.next = previousNode;
            previousNode.next = nextNode;

            carriedNode = previousNode;
            
            previousNode = nextNode;
            currentNode = previousNode?.next;
        }
        
        return newHead;
    }
}