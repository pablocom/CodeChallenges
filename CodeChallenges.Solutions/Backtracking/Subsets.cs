namespace CodeChallenges.Solutions.Backtracking;

public static class Subsets
{
    public static IList<IList<int>> Solve(int[] nums)
    {
        var result = new List<IList<int>>();
        var currentNumbers = new List<int>(nums.Length);
        Traverse(nums, result, currentNumbers, 0);
        return result;
    }

    private static void Traverse(int[] nums, List<IList<int>> result, List<int> currentNumbers, int position)
    {
        if (position == nums.Length)
        {
            result.Add(currentNumbers.ToArray());
            if (currentNumbers.Count > 0)
                currentNumbers.RemoveAt(currentNumbers.Count - 1);
            return;
        }
        
        currentNumbers.Add(nums[position]);
        var next = position + 1;
        
        Traverse(nums, result, currentNumbers, next);
        Traverse(nums, result, currentNumbers, next);
    }
}