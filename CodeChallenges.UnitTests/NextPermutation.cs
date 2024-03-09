namespace CodeChallenges.UnitTests;

// https://leetcode.com/problems/next-permutation/?envType=featured-list&envId=top-microsoft-questions?envType=featured-list&envId=top-microsoft-questions
public class NextPermutation
{
    public void ToNextPermutation(int[] nums)
    {
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) 
            i--;

        if (i >= 0)
        {
            int j = nums.Length - 1;
            while (nums[i] >= nums[j]) 
                j--;

            (nums[i], nums[j]) = (nums[j], nums[i]);
        }

        Array.Reverse(nums, i + 1, nums.Length - i - 1);
    }
}