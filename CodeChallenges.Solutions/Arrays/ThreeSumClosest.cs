namespace CodeChallenges.Solutions.Arrays;

public class ThreeSumClosest
{
    public int Solve(int[] array, int target)
    {
        int result = default;
        var differenceBetweenSumToTarget = int.MaxValue;
        Array.Sort(array);

        for (var i = 0; i < array.Length; i++)
        {
            if (i != 0 && array[i - 1] == array[i])
                continue;

            int left = i + 1, right = array.Length - 1;
            while (left < right)
            {
                var sum = array[i] + array[left] + array[right];
                var difference = Math.Abs(sum - target);
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