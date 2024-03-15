namespace CodeChallenges.Solutions.Arrays;

public class FirstAndLastPositionInSortedArraySolution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var index = Array.BinarySearch(nums, target);

        if (index < 0)
        {
            return [-1, -1];
        }

        var leftLimit = index;
        var rightLimit = index;

        while (true)
        {
            leftLimit--;

            if (leftLimit < 0 || nums[leftLimit] != target)
            {
                leftLimit++;
                break;
            }
        }

        while (rightLimit < nums.Length)
        {
            rightLimit++;

            if (rightLimit >= nums.Length ||nums[rightLimit] != target)
            {
                rightLimit--;
                break;
            }
        }

        return [leftLimit, rightLimit];
    }
}