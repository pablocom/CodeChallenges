using System.Collections.Generic;

namespace CodeChallenges.Solutions
{
    public class LRUCache
    {
        private readonly Node head;
        private readonly Node tail;
        private readonly Dictionary<int, Node> dictionary;
        private readonly int capacity;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            dictionary = new Dictionary<int, Node>();
            dictionary = new Dictionary<int, Node>();
            head = new Node();
            tail = new Node();
            
            head.Next = tail;
            tail.Previous = head;
        }

        public int Get(int key)
        {
            if (!dictionary.ContainsKey(key))
                return -1;
            
            var node = dictionary[key];
            Remove(node);
            Add(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (!dictionary.ContainsKey(key))
            {
                if (dictionary.Count == capacity)
                {
                    dictionary.Remove(tail.Previous.Key);
                    Remove(tail.Previous);
                }

                var newNode = new Node(key, value);
                Add(newNode);
                dictionary.Add(key, newNode);

                return;
            }
            
            var node = dictionary[key];
            Remove(node);
            node.Value = value;
            Add(node);
        }

        private void Add(Node node)
        {
            var next = head.Next;
            head.Next = node;
            node.Previous = head;
            node.Next = next;
            next.Previous = node;
        }

        private void Remove(Node node)
        {
            var next = node.Next;
            var prev = node.Previous;

            prev.Next = next;
            next.Previous = prev;
        }
        
        public class Node
        {
            public int Key { get; }
            public int Value { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node()
            {
            }

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}