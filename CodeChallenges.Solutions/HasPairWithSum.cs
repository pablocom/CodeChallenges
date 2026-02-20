namespace CodeChallenges.Solutions;

public static class HasPairWithSum
{
    public static bool SolveForAscOrderedNumbers(int[] numbers, int sum)
    {
        var low = 0;
        var high = numbers.Length - 1;
        while (low < high)
        {
            var currentSum = numbers[low] + numbers[high];
            if (currentSum == sum)
                return true;

            if (currentSum < sum)
            {
                low++;
            }
            else
            {
                high--;
            }
        }
        
        return false;
    }

    public static bool SolveForUnorderedNumbers(int[] numbers, int sum)
    {
        var complementsSeen = new HashSet<int>();
        
        foreach (var number in numbers)
        {
            if (complementsSeen.Contains(number))
                return true;

            var complement = sum - number;
            complementsSeen.Add(complement);
        }

        return false;
    }
}