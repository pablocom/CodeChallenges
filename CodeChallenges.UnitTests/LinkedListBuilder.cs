using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.UnitTests;

public class LinkedListBuilder
{
    private readonly ListNode _linkedListRootNode;
    public LinkedListBuilder(int linkedListRootValue)
    {
        _linkedListRootNode = new ListNode(linkedListRootValue);
    }
    
    public ListNode Build()
    {
        return _linkedListRootNode;
    }
}