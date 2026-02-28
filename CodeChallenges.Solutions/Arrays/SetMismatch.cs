namespace CodeChallenges.Solutions.Arrays;

public static class SetMismatch
{
    public static int[] Solve(int[] nums)
    {
        int duplicate = -1, missing = 1;
        
        for (var i = 0; i < nums.Length; i++) {
            if (nums[System.Math.Abs(nums[i]) - 1] < 0)
                duplicate = System.Math.Abs(nums[i]);
            else
                nums[System.Math.Abs(nums[i]) - 1] *= -1;
        }
        
        for (var i = 0; i < nums.Length; i++) {
            if (nums[i] > 0) {
                missing = i + 1;
                break;
            }
        }
        
        return [duplicate, missing];
    }
}