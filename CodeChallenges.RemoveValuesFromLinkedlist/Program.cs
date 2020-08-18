namespace CodeChallenges.RemoveValuesFromLinkedlist
{
    class Program
    {
        static void Main()
        {
            var head = new LinkedListNode(3);
            head.AppendNode(3);
            head.AppendNode(3);
            head.AppendNode(1);
            head.AppendNode(5);
            head.AppendNode(2);
            head.AppendNode(3);
            head.AppendNode(3);
            head.AppendNode(3);
            head.AppendNode(1);
            head.AppendNode(4);
            head.AppendNode(3);
            head.AppendNode(3);

            var removedLinkedList = RemoveDigits(3, head);

            removedLinkedList.Print();
        }

        static LinkedListNode RemoveDigits(int value, LinkedListNode firstNode)
        {
            if (firstNode == null)
                return null;

            while (firstNode.Val == value)
                firstNode = firstNode.Next;

            LinkedListNode previousNode = null;
            var currentNode = firstNode;
            while (currentNode != null)
            {
                if (currentNode.Val == value)
                    previousNode.Next = currentNode.Next;
                else
                    previousNode = currentNode;

                currentNode = currentNode.Next;
            }

            return firstNode;
        }
    }
}
