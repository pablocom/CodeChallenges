namespace CodeChallenges.Solutions.Arrays;

public static class CombinationSum
{
    public static IList<IList<int>> Solve(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        var currentCombination = new List<int>();
        var currentSum = 0;
        var position = 0;

        Traverse(candidates, result, currentCombination, currentSum, position, target);
        return result;
    }

    private static void Traverse(int[] candidates, List<IList<int>> result, List<int> currentCombination, int currentSum,
        int position, int target)
    {
        if (position >= candidates.Length)
            return;
        
        if (currentSum == target)
        {
            result.Add(currentCombination.ToArray());
            return;
        }
        
        if (currentSum > target)
            return;

        currentCombination.Add(candidates[position]);
        Traverse(
            candidates,
            result,
            currentCombination,
            currentSum + candidates[position],
            position,
            target
        );
        currentCombination.RemoveAt(currentCombination.Count - 1);
        Traverse(
            candidates,
            result,
            currentCombination,
            currentSum,
            position + 1,
            target
        );
    }
}