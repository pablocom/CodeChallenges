using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class CopyLinkedListTests
    {
        [Test]
        public void Test1()
        {
            var firstNodeValue = 6;
            var secondNodeValue = 32;

            var head = new Node(firstNodeValue);
            head.next = new Node(secondNodeValue);

            head.random = head.next;
            head.next.random = head;

            var newHead = new CopyOfLinkedListWithRandomPointersHashTable().CopyRandomList(head);

            Assert.That(newHead.GetHashCode(), Is.Not.EqualTo(head.GetHashCode()));
            Assert.That(newHead.val, Is.EqualTo(firstNodeValue));

            Assert.That(newHead.next.val, Is.EqualTo(secondNodeValue));
            Assert.That(newHead.next.random.GetHashCode(), Is.EqualTo(newHead.GetHashCode()));
        }
    }
}