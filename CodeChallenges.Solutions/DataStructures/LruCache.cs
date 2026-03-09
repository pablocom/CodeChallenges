namespace CodeChallenges.Solutions.DataStructures;

public class LruCache
{
    private readonly Node _head;
    private readonly Node _tail;
    private readonly Dictionary<int, Node> _dictionary;
    private readonly int _capacity;

    public LruCache(int capacity)
    {
        this._capacity = capacity;
        _dictionary = new Dictionary<int, Node>();
        _head = new Node();
        _tail = new Node();
            
        _head.Next = _tail;
        _tail.Previous = _head;
    }

    public int Get(int key)
    {
        if (!_dictionary.TryGetValue(key, out var node))
            return -1;

        Remove(node);
        Add(node);
        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (!_dictionary.TryGetValue(key, out var node))
        {
            if (_dictionary.Count == _capacity)
            {
                _dictionary.Remove(_tail.Previous.Key);
                Remove(_tail.Previous);
            }

            var newNode = new Node(key, value);
            Add(newNode);
            _dictionary.Add(key, newNode);

            return;
        }

        Remove(node);
        node.Value = value;
        Add(node);
    }

    private void Add(Node node)
    {
        var next = _head.Next;
        _head.Next = node;
        node.Previous = _head;
        node.Next = next;
        next.Previous = node;
    }

    private static void Remove(Node node)
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