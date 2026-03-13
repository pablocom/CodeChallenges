using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.UnitTests.LinkedLists;

public class CopyLinkedListTests
{
    [Fact]
    public void Test1()
    {
        var firstNodeValue = 6;
        var secondNodeValue = 32;

        var head = new ListNode(firstNodeValue);
        head.next = new ListNode(secondNodeValue);

        head.random = head.next;
        head.next.random = head;

        var newHead = new CopyOfLinkedListWithRandomPointersHashTable().CopyRandomList(head);

        newHead.GetHashCode().ShouldNotBe(head.GetHashCode());
        
        newHead.val.ShouldBe(firstNodeValue);
        newHead.next!.val.ShouldBe(secondNodeValue);
        newHead.next!.random!.GetHashCode().ShouldBe(newHead.GetHashCode());
    }
}
