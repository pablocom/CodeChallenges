using System.Runtime.InteropServices;

namespace CodeChallenges.Solutions.Arrays;

public static class FindDifferenceOfTwoArrays
{
    public static List<List<int>> Solve(int[] nums1, int[] nums2)
    {
        var uniqueNumbersIn1 = nums1.ToHashSet();
        var uniqueNumbersIn2 = nums2.ToHashSet();

        var result1 = new List<int>();
        var result2 = new List<int>();

        foreach (var number in uniqueNumbersIn1)
        {
            if (!uniqueNumbersIn2.Contains(number))
                result1.Add(number);
        }
        
        foreach (var number in uniqueNumbersIn2)
        {
            if (!uniqueNumbersIn1.Contains(number))
                result2.Add(number);
        }
        
        return [result1, result2];
    }
}