using System;

namespace CodeChallenges.Solutions;

public class ThreeSumClosest
{
    public int Solve(int[] array, int target)
    {
        int result = default;
        int differenceBetweenSumToTarget = int.MaxValue;
        Array.Sort(array);

        for (int i = 0; i < array.Length; i++)
        {
            if (i != 0 && array[i - 1] == array[i])
                continue;

            int left = i + 1, right = array.Length - 1;
            while (left < right)
            {
                var sum = array[i] + array[left] + array[right];
                int difference = Math.Abs(sum - target);
                if (difference < differenceBetweenSumToTarget)
                {
                    differenceBetweenSumToTarget = difference;
                    result = sum;
                }
                else if (sum < target)
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