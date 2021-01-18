using System.Collections.Generic;

namespace CodeChallenges.CopyOfLinkedListWithRandomPointers
{
    public class HashTableSolution
    {
        public Node CopyRandomList(Node head)
        {
            var newNodesMap = new Dictionary<Node, Node>();

            var currentNode = head;
            while (currentNode != null)
            {
                newNodesMap.Add(currentNode, new Node(currentNode.val));
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
}