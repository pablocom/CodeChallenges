namespace CodeChallenges.Solutions;

public sealed class AvlTree<TItem>
{
    private const int BalanceThreshold = 1;
    private readonly IComparer<TItem> _comparer;
    private Node? _root;

    public AvlTree(IComparer<TItem>? comparer = null)
    {
        _comparer = comparer ?? Comparer<TItem>.Default;
    }

    public void Insert(IEnumerable<TItem> items)
    {
        foreach (var item in items) 
            Insert(item);
    }
    
    public void Insert(TItem item)
    {
        _root = Insert(_root, item);
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
        {
            node = GetBalanceOf(node.LeftChild) >= 0 
                ? RotateRight(node) 
                : RotateLeftRight(node);
        }
        else if (balance < -BalanceThreshold)
        {
            node = GetBalanceOf(node.RightChild) <= 0 
                ? RotateLeft(node) 
                : RotateRightLeft(node);
        }

        return node;
    }

    public void Remove(TItem item)
    {
        throw new NotImplementedException();
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

    private static Node RotateLeftRight(Node node)
    {
        node.LeftChild = RotateLeft(node.LeftChild!);
        return RotateRight(node);
    }

    private static Node RotateRightLeft(Node node)
    {
        node.RightChild = RotateRight(node.RightChild!);
        return RotateLeft(node);
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