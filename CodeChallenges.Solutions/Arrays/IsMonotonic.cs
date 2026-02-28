namespace CodeChallenges.Solutions.Arrays;

public static class IsMonotonic
{
    public static bool Solve(int[] nums)
    {
        if (nums.Length <= 1)
            return true;

        var direction = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            var previous = nums[i - 1];
            var current = nums[i];

            if (previous == current)
                continue;

            switch (direction)
            {
                case 0:
                {
                    direction = previous > current ? -1 : 1;
                    break;
                }
                case 1 when previous > current:
                case -1 when previous < current:
                    return false;
            }
        }

        return true;
    }
}
