using System.Collections;

namespace CodeChallenges.Solutions;

public sealed class AvlTree<TItem>
{
    private readonly IComparer<TItem> _comparer;
    private Node? _root;

    public AvlTree(IComparer<TItem>? comparer = null)
    {
        _comparer = comparer ?? Comparer<TItem>.Default;
    }

    private void InsertNew(TItem item)
    {
        if (_root is null)
        {
            
        }
    }
    
    public void Insert(TItem item)
    {
        if (_root is null) 
            _root = new Node(item);
        else
            Insert(_root, item);
    }

    private void Insert(Node node, TItem item)
    {
        if (_comparer.Compare(item, node.Value) < 0)
        {
            if (node.LeftChild is null)
                node.LeftChild = new Node(item);
            else
                Insert(node.LeftChild, item);
        }
        else
        { 
            if (node.RightChild is null)
                node.RightChild = new Node(item);
            else
                Insert(node.RightChild, item);
        }
    }

    public void Remove(TItem item) => throw new NotImplementedException();

    public IEnumerable<TItem> InOrderTraversal() => new InOrderTraversalEnumerator(this);

    private sealed class Node
    {
        public TItem? Value { get; set; }
        public int Height { get; set; }
        public Node? LeftChild { get; set; }
        public Node? RightChild { get; set; }

        public Node(TItem? value, Node? leftChild = null, Node? rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }

    private sealed class InOrderTraversalEnumerator : IEnumerator<TItem>, IEnumerable<TItem>
    {
        private readonly Stack<Node> _stack = new();
        private readonly Node? _root;
        
        private Node? _current;
        public TItem Current => _current!.Value!;

        public InOrderTraversalEnumerator(AvlTree<TItem> tree)
        {
            _root = tree._root;
            Initialize();
        }

        public bool MoveNext()
        {
            if (_stack.Count is 0)
                return false;

            _current = _stack.Pop();
            var node = _current;
            
            if (node.RightChild is not null)
            {
                node = node.RightChild;
                
                while (node is not null)
                {
                    _stack.Push(node);
                    node = node.LeftChild;
                }
            }

            return true;
        }

        public void Reset()
        {
            _stack.Clear();
            Initialize();
        }

        object? IEnumerator.Current => Current;

        public void Dispose() { }

        private void Initialize()
        {
            _current = _root;

            while (_current is not null)
            {
                _stack.Push(_current);
                _current = _current.LeftChild;
            }
        }

        public IEnumerator<TItem> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}