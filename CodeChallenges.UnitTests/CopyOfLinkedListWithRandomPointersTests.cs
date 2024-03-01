using CodeChallenges.Solutions.LinkedLists;

namespace CodeChallenges.UnitTests;

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

        newHead.GetHashCode().Should().NotBe(head.GetHashCode());
        
        newHead.val.Should().Be(firstNodeValue);
        newHead.next!.val.Should().Be(secondNodeValue);
        newHead.next!.random!.GetHashCode().Should().Be(newHead.GetHashCode());
    }
}
