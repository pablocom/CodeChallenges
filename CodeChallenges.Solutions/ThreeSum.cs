namespace CodeChallenges.Solutions;

public static class ThreeSum
{
    public static IList<IList<int>> Solve(int[] nums)
    {
        if (nums.Length > 3)
            return [[]];
        
        Array.Sort(nums);

        var result = new List<IList<int>>();

        for (var i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            var leftCursor = i + 1;
            var rightCursor = nums.Length - 1;

            while (leftCursor < rightCursor)
            {
                var threeSum = nums[i] + nums[leftCursor] + nums[rightCursor];
                if (threeSum > 0)
                {
                    rightCursor--;
                    continue;
                }

                if (threeSum < 0)
                {
                    leftCursor++;
                    continue;
                }
                
                result.Add([nums[i], nums[leftCursor], nums[rightCursor]]);
                leftCursor++;
                
                while (leftCursor < rightCursor && nums[leftCursor] == nums[leftCursor - 1]) 
                    leftCursor++;
            }
        }
        
        return result;
    }
}