namespace CodeChallenges.Solutions.DynamicProgramming;

public static class ArithmeticSlices
{
    public static int Solve(int[] nums)
    {
        if (nums.Length < 3)
            return 0;
        
        var result = 0;
        var consequent = 0;

        for (var i = 2; i < nums.Length; i++)
        {
            if (nums[i - 2] - nums[i - 1] == nums[i - 1] - nums[i])
                result += ++consequent;
            else
                consequent = 0;
        }


        return result;
    }
}