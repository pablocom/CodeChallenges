namespace CodeChallenges.Solutions;

public sealed class AvlTree<TItem>
{
    public int Height => _root?.Height ?? -1;
    public int Balance => GetBalanceOf(_root);

    private const int BalanceThreshold = 1;
    
    private readonly IComparer<TItem> _comparer;
    private Node? _root;

    public AvlTree(IComparer<TItem>? comparer = null)
    {
        _comparer = comparer ?? Comparer<TItem>.Default;
    }

    public AvlTree(IEnumerable<TItem> items, IComparer<TItem>? comparer = null) : this(comparer)
    {
        Insert(items);
    }

    public void Insert(IEnumerable<TItem> items)
    {
        foreach (var item in items) 
            Insert(item);
    }
    
    public void Insert(TItem item)
    {
        var newRoot = Insert(_root, item);
        _root = newRoot;
    }

    public void Remove(TItem? item)
    {
        var newRoot = Remove(_root, item);
        _root = newRoot;
    }

    private Node Insert(Node? node, TItem item)
    {
        if (node is null)
            return new Node(item);
        
        if (_comparer.Compare(item, node.Value) < 0)
            node.LeftChild = Insert(node.LeftChild, item);
        else
            node.RightChild = Insert(node.RightChild, item);

        node.Height = 1 + Math.Max(GetHeightOf(node.LeftChild), GetHeightOf(node.RightChild));

        var balance = GetBalanceOf(node);
        
        if (balance > BalanceThreshold)
            return GetBalanceOf(node.LeftChild) >= 0 ? RotateRight(node) : RotateLeftRight(node);
        if (balance < -BalanceThreshold) 
            return GetBalanceOf(node.RightChild) <= 0 ? RotateLeft(node) : RotateRightLeft(node);

        return node;
    }

    private Node? Remove(Node? node, TItem? item)
    {
        if (node is null)
            return null;

        var comparison = _comparer.Compare(item, node.Value);
        switch (comparison)
        {
            case < 0:
                node.LeftChild = Remove(node.LeftChild, item);
                break;
            case > 0:
                node.RightChild = Remove(node.RightChild, item);
                break;
            default:
                if (node.LeftChild is null)
                    return node.RightChild;
                
                if (node.RightChild is null)
                    return node.LeftChild;
                
                var minNode = GetMinValueNode(node.RightChild);
                node.Value = minNode.Value;
                node.RightChild = Remove(node.RightChild, minNode.Value);

                break;
        }

        node!.Height = 1 + Math.Max(GetHeightOf(node.LeftChild), GetHeightOf(node.RightChild));
        
        var balance = GetBalanceOf(node);
        
        if (balance > BalanceThreshold)
            return GetBalanceOf(node.LeftChild) >= 0 ? RotateRight(node) : RotateLeftRight(node);
        if (balance < -BalanceThreshold)
            return GetBalanceOf(node.RightChild) <= 0 ? RotateLeft(node) : RotateRightLeft(node);

        return node;
    }

    private static Node RotateRight(Node node)
    {
        var leftChildTemp = node.LeftChild!;

        node.LeftChild = leftChildTemp.RightChild;
        leftChildTemp.RightChild = node;

        node.Height = 1 + Math.Max(GetHeightOf(node.LeftChild), GetHeightOf(node.RightChild));
        leftChildTemp.Height = node.Height + 1;
        
        return leftChildTemp;
    }

    private static Node RotateLeft(Node node)
    {
        var rightChildTemp = node.RightChild!;

        node.RightChild = rightChildTemp.LeftChild;
        rightChildTemp.LeftChild = node;

        node.Height = 1 + Math.Max(GetHeightOf(node.LeftChild), GetHeightOf(node.RightChild));
        rightChildTemp.Height = node.Height + 1;
        
        return rightChildTemp;
    }

    private static Node RotateRightLeft(Node node)
    {
        node.RightChild = RotateRight(node.RightChild!);
        return RotateLeft(node);
    }

    private static Node RotateLeftRight(Node node)
    {
        node.LeftChild = RotateLeft(node.LeftChild!);
        return RotateRight(node);
    }

    private static int GetBalanceOf(Node? node)
    {
        if (node is null)
            return 0;

        return GetHeightOf(node.LeftChild) - GetHeightOf(node.RightChild);
    }

    private static int GetHeightOf(Node? node)
    {
        if (node is null)
            return -1;

        return node.Height;
    }

    private static Node GetMinValueNode(Node node)
    {
        var current = node;
        while (current.LeftChild is not null)
            current = current.LeftChild;

        return current;
    }

    public IEnumerable<TItem> InOrderTraversal() => InOrderTraversalInternal(_root);
    
    private static IEnumerable<TItem> InOrderTraversalInternal(Node? node)
    {
        if (node is null)
            yield break;

        if (node.LeftChild is not null)
        {
            foreach (var leftChild in InOrderTraversalInternal(node.LeftChild))
                yield return leftChild;
        }

        yield return node.Value!;
        
        if (node.RightChild is not null)
        {
            foreach(var rightNode in InOrderTraversalInternal(node.RightChild))
                yield return rightNode;
        }
    }

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
}