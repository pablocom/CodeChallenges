using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class MinStack
{
    private Stack<int> stack;
    private Stack<int> stackOfMinimums;

    public MinStack()
    {
        stack = new Stack<int>();
        stackOfMinimums = new Stack<int>();
    }

    public void Push(int value)
    {
        if (value <= GetMin())
            stackOfMinimums.Push(value);

        stack.Push(value);
    }

    public void Pop()
    {
        var popResult = stack.Pop();

        if (popResult == stackOfMinimums.Peek())
            stackOfMinimums.Pop();
    }

    public int Top()
    {
        return stack.Peek();
    }

    public int GetMin()
    {
        if (!stackOfMinimums.Any())
            return int.MaxValue;
        
        return stackOfMinimums.Peek();
    }
}