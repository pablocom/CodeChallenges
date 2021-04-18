namespace CodeChallenges.Solutions
{
    public class CopyOfLinkedListWithRandomPointers
    {
        public Node CopyRandomList(Node head)
        {
            var headCopy = head;
            var newHead = CreateCopyOfLinkedList(headCopy);

            FillRandomPointersInCopy(headCopy, newHead);
            PointOldNodesNextPointersToNewNodes(headCopy, newHead);
            ChangeNewRandomPointerToNextPointers(newHead);

            return newHead;
        }

        private Node CreateCopyOfLinkedList(Node head)
        {
            var newHead = new Node(head.val);

            var currentOldNode = head.next;
            var currentNewNode = newHead;
            while (currentOldNode != null)
            {
                currentNewNode.next = new Node(currentOldNode.val);
                currentNewNode = currentNewNode.next;
                currentOldNode = currentOldNode.next;
            }

            return newHead;
        }

        private void FillRandomPointersInCopy(Node head, Node newHead)
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

        private void PointOldNodesNextPointersToNewNodes(Node head, Node newHead)
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

        private void ChangeNewRandomPointerToNextPointers(Node newHead)
        {
            var currentNewNode = newHead;
            while (currentNewNode != null)
            {
                currentNewNode.random = currentNewNode.random?.next;
                currentNewNode = currentNewNode.next;
            }
        }
    }
}