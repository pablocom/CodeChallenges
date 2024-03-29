﻿using System.Collections.Generic;

namespace CodeChallenges.Solutions.LinkedLists;

public class CopyOfLinkedListWithRandomPointersHashTable
{
    public ListNode CopyRandomList(ListNode head)
    {
        var newNodesMap = new Dictionary<ListNode, ListNode>();

        var currentNode = head;
        while (currentNode != null)
        {
            newNodesMap.Add(currentNode, new ListNode(currentNode.val));
            currentNode = currentNode.next;
        }

        currentNode = head;
        while (currentNode != null)
        {
            if (currentNode.next == null) break;

            newNodesMap[currentNode].next = newNodesMap[currentNode.next];
            currentNode = currentNode.next;
        }

        currentNode = head;
        while (currentNode != null)
        {
            newNodesMap[currentNode].random = currentNode.random != null ? newNodesMap[currentNode.random] : null;
            currentNode = currentNode.next;
        }

        return newNodesMap[head];
    }
}