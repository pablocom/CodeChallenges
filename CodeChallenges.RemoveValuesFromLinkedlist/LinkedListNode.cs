using System;

namespace CodeChallenges.RemoveValuesFromLinkedlist
{
    public class LinkedListNode
    {
        public int Value { get; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }

        public void AppendNode(int value)
        {
            var prev = this;
            var tmp = Next;
            while (tmp != null)
            {
                prev = tmp;
                tmp = tmp.Next;
            }

            prev.Next = new LinkedListNode(value);
        }

        public void Print()
        {
            var node = this;
            while (node != null)
            {
                Console.Write(node.Value + ", ");
                node = node.Next;
            }
            Console.WriteLine();
        }
    }
}