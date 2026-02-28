namespace CodeChallenges.Solutions.Searching;

public static class SearchInsertPosition
{
    public static int Solve(int[] nums, int target)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low < high)
        {
            var mid = low + (high - low) / 2;

            if (nums[mid] == target)
                return mid;
            
            if (nums[mid] < target)
            {
                low = mid + 1;
                continue;
            }

            if (nums[mid] > target)
                high = mid - 1;
        }

        return nums[low] < target 
            ? low + 1 
            : low;
    }
}