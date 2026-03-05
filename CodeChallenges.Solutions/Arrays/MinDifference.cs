
namespace CodeChallenges.Solutions.Arrays;

public static class MinDifference
{
    public static int Solve(int[] nums)
    {
        if (nums.Length < 4)
            return 0;
        
        Array.Sort(nums);
        var length = nums.Length;
        
        return Math.Min(
            Math.Min(nums[length - 4] - nums[0], nums[length - 3] - nums[1]), 
            Math.Min(nums[length - 2] - nums[2], nums[length - 1] - nums[3])
        );
    }
}