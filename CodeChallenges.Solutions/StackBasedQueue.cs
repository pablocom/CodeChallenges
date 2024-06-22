namespace CodeChallenges.Solutions;

public class StackBasedQueue<T>
{
    private readonly Stack<T> _stack1 = new();
    private readonly Stack<T> _stack2 = new();

    public void Enqueue(T item)
    {
        while (_stack1.Count > 0)
            _stack2.Push(_stack1.Pop());

        _stack1.Push(item);

        while (_stack2.Count > 0)
            _stack1.Push(_stack2.Pop());
    }

    public T Dequeue() => _stack1.Pop();
    public T Peek() => _stack1.Peek();
}
