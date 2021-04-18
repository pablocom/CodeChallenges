using System;

namespace CodeChallenges.KthLargestElement
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums); // O(n*logn)

            return nums[nums.Length - 1 - (k - 1)];
        }
    }
}