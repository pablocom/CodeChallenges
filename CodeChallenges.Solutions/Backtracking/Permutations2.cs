namespace CodeChallenges.Solutions.Backtracking;

public static class Permutations2
{
    public static IList<IList<int>> Solve(int[] nums)
    {
        var countByNum = new Dictionary<int, int>(8);
            
        foreach (var num in nums)
        {
            if (countByNum.TryGetValue(num, out var occurrences))
                countByNum[num] = occurrences + 1;
            else
                countByNum.Add(num, 1);
        }
        
        var result = new List<IList<int>>();
        
        foreach (var num in countByNum.Keys.ToArray()) 
            TraverseOptions(num, countByNum, result, new List<int>(nums.Length));

        return result;
    }

    private static void TraverseOptions(int num, Dictionary<int, int> countByNum, List<IList<int>> result, List<int> currentPath)
    {
        countByNum[num]--;
        if (countByNum[num] is 0) 
            countByNum.Remove(num);
        
        currentPath.Add(num);
        
        if (countByNum.Count is 0)
            result.Add(currentPath.ToArray());
        else foreach (var remainingNum in countByNum.Keys.ToArray())
            TraverseOptions(remainingNum, countByNum, result, currentPath);
            
        if (countByNum.TryGetValue(num, out var count))
            countByNum[num] = count + 1;
        else
            countByNum.Add(num, 1);
            
        currentPath.RemoveAt(currentPath.Count - 1);
    }
}