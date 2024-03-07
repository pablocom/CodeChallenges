

namespace CodeChallenges.Solutions;

public class FourSum
{
    public IList<IList<int>> Solve(int[] nums, int target)
    {
        var result = new List<IList<int>>();
        
        Array.Sort(nums);
        
        for (var k = 0; k < nums.Length - 3; k++)
        {
            if (k > 0 && nums[k] == nums[k - 1]) 
                continue;
            
            for (var i = k + 1; i < nums.Length - 2; i++)
            {
                if (i > k + 1 && nums[i] == nums[i - 1]) 
                    continue;
                
                var toFind = (long)target - (nums[i] + nums[k]);
                var lo = i + 1;
                var hi = nums.Length - 1;

                while (lo < hi)
                {
                    long sum = nums[lo] + nums[hi];
                    if (sum == toFind)
                    {
                        result.Add([nums[k], nums[i], nums[lo], nums[hi]]);
                        while (lo < hi && nums[lo] == nums[lo - 1]) lo++;
                        while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                    }

                    if (sum < toFind)
                        lo++;
                    else
                        hi--;
                }
            }
        }
        
        return result;
    }
}