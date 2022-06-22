using System;
using System.Collections.Generic;

namespace CodeChallenges.Solutions;

public class ThreeSum
{
    public IList<IList<int>> Solve(int[] nums)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
                continue;

            var left = i + 1;
            var right = nums.Length - 1;

            while (left < right)
            {
                var sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    result.Add(new List<int>() { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1])
                        left++;
                    while (left < right && nums[right] == nums[right - 1])
                        right--;
                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }
}

// [-1,  0, 1, 2, -1, -4]
// [-1, -1, 0, 2,  1, -3]