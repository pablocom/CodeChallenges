using System;
using System.Linq;
using NUnit.Framework;

namespace CodeChallenges.KthLargestElement
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var inputArray = new[] {3, 2, 1, 4, 5, 6};
            var kthLargestNumber = 2;

            var result = new Solution().FindKthLargest(inputArray, kthLargestNumber);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Test2()
        {
            var inputArray = new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var kthLargestNumber = 4;

            var result = new Solution().FindKthLargest(inputArray, kthLargestNumber);

            Assert.That(result, Is.EqualTo(4));
        }
    }

    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums); // O(n*logn)

            return nums[(nums.Length - 1) - (k - 1)];
        }
    }
}