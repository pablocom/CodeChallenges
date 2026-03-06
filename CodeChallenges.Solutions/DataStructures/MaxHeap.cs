namespace CodeChallenges.Solutions.DataStructures;

public sealed class MaxHeap<T> where T : IComparable<T>
{
    public int Count => _heap.Count;
    
    private readonly List<T> _heap;

    public MaxHeap() => _heap = new();

    public MaxHeap(int capacity) => _heap = new(capacity);

    public MaxHeap(IEnumerable<T> span)
    {
        _heap = new List<T>(span);

        for (var index = LastNonLeaveIndex(); index >= 0; index--)
            MoveNodeDown(index);
    }
    
    public void Insert(T value)
    {
        _heap.Add(value);
        MoveNodeUp(_heap.Count - 1);
    }

    public T? PeekMaxOrDefault(T? @default = default) => _heap.Count is 0 ? @default : _heap[0];

    public T PopMax()
    {
        if (_heap.Count is 0)
            throw new InvalidOperationException("The heap is empty.");

        return PopMaxInternal();
    }

    public T? PopMaxOrDefault(T? @default = default) =>
        _heap.Count is 0 ? @default : PopMaxInternal();

    private T PopMaxInternal()
    {
        var root = _heap[0];

        _heap[0] = _heap[^1];
        _heap.RemoveAt(_heap.Count - 1);

        if (_heap.Count > 0)
            MoveNodeDown(0);

        return root;
    }
    
    private void MoveNodeUp(int index)
    {
        var currentIndex = index;
        while (currentIndex is not 0 && _heap[ParentOf(currentIndex)].CompareTo(_heap[currentIndex]) < 0)
        {
            (_heap[ParentOf(currentIndex)], _heap[currentIndex]) = (_heap[currentIndex], _heap[ParentOf(currentIndex)]);
            currentIndex = ParentOf(currentIndex);
        }
    }

    private void MoveNodeDown(int initialIndex)
    {
        var heapSize = _heap.Count;
        var currentIndex = initialIndex;

        while (true)
        {
            var largest = currentIndex;
            
            var left = LeftChildOf(currentIndex);
            var right = RightChildOf(currentIndex);

            if (left < heapSize && _heap[left].CompareTo(_heap[largest]) > 0)
                largest = left;

            if (right < heapSize && _heap[right].CompareTo(_heap[largest]) > 0)
                largest = right;

            if (largest == currentIndex)
                break;

            (_heap[currentIndex], _heap[largest]) = (_heap[largest], _heap[currentIndex]);
            currentIndex = largest;
        }
    }

    private static int ParentOf(int index) => (index - 1) / 2;
    private static int LeftChildOf(int index) => 2 * index + 1;
    private static int RightChildOf(int index) => 2 * index + 2;
    private int LastNonLeaveIndex() => _heap.Count / 2 - 1;
}