namespace CodeChallenges.Solutions.DynamicProgramming;

public static class TwoKeysKeyboard
{
    public static int SolveWithMagic(int n)
    {
        var res = 0;
        for (var i = 2; i <= n; i++)
        {
            while (n % i == 0)
            {
                res += i;
                n /= i;
            }
        }
        return res;
    }
    
    public static int SolveWithFactors(int n)
    {
        Span<int> subProblems = stackalloc int[n + 1];
        subProblems.Fill(1000);

        subProblems[1] = 0;

        for (var i = 2; i <= n; i++)
        {
            for (var j = 1; j <= i / 2; j++)
            {
                if (i % j == 0)
                    subProblems[i] = Math.Min(subProblems[i], subProblems[j] + i / j);
            }
        }

        return subProblems[n];
    }
    
    public static int SolveWithDfs(int n)
    {
        if (n is 1)
            return 0;
        
        var subProblemsCache = new Dictionary<(int Count, int ClipboardSize), int>();
        return 1 + Helper(1, 1, n, subProblemsCache);
        
        static int Helper(
            int count, 
            int clipboardSize, 
            int targetN, 
            Dictionary<(int Count, int ClipboardSize), int> cache)
        {
            const int infinite = int.MaxValue - 1001;
        
            if (targetN == count)
                return 0;

            if (count > targetN)
                return infinite;

            if (cache.TryGetValue((count, clipboardSize), out var result))
                return result;

            var copyingResult = 1 + Helper(count + clipboardSize, clipboardSize, targetN, cache);
            var copyPastingResult = 2 + Helper(count + count, count, targetN, cache);
        
            var min = Math.Min(copyingResult, copyPastingResult);
            cache.TryAdd((count, clipboardSize), min);
            return min;
        }
    }
}