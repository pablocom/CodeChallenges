using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.UnitTests.Builders;

public class ListNodeBuilder
{
    private readonly List<int> _values = [];
    
    public ListNode? Build()
    {
        if (_values.Count is 0)
            return null;
        
        var head = new ListNode(_values[0]);
        var current = head;
        foreach (var value in _values.Skip(1))
        {
            current.next = new ListNode(value);
            current = current.next;
        }

        return head;
    }

    public static ListNodeBuilder From(params int[] nodeValues)
    {
        var builder = new ListNodeBuilder();
        foreach (var value in nodeValues)
        {
            builder.AddNodeWithValue(value);
        }

        return builder;
    }
    
    public ListNodeBuilder AddNodeWithValue(int value)
    {
        _values.Add(value);
        return this;
    }
}