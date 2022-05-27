using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class AddTwoNumbersTests
    {
        [TestCase(2, 3, 5)]
        [TestCase(2, 4, 6)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        public void TwoSingleDigitNumbers(int a, int b, int expected)
        {
            var l1 = new ListNode(a);
            var l2 = new ListNode(b);

            var actual = AddTwoNumbers.Solve(l1, l2);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TwoSingleNumbersWithSameLength()
        {
            var l1 = new ListNode(2){ next = new ListNode(4){ next = new ListNode(3)}};
            var l2 = new ListNode(5){ next = new ListNode(6){ next = new ListNode(4)}};
            var actual = AddTwoNumbers.Solve(l1, l2);

            Assert.AreEqual(708, actual);
        }
        
        [Test]
        public void TwoSingleNumbersWithSameLength1()
        {
            var l1 = new ListNode(0){ next = new ListNode(0){ next = new ListNode(3)}};
            var l2 = new ListNode(0){ next = new ListNode(0){ next = new ListNode(0){next = new ListNode(1)}}};
            var actual = AddTwoNumbers.Solve(l1, l2);

            Assert.AreEqual(708, actual);
        }
    }
}