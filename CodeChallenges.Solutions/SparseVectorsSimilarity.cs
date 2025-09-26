using System.Runtime.InteropServices;

namespace CodeChallenges.Solutions;

public static class SparseVectorsSimilarity
{
    public static double Solve(List<int> keysA, List<double> valuesA, List<int> keysB, List<double> valuesB)
    {
        double squaresSumOfA = valuesA.Sum(x => x * x);
        double squaresSumOfB = valuesB.Sum(x => x * x);

        if (squaresSumOfA is 0 || squaresSumOfB is 0)
            return 0;

        var cursorA = 0;
        var cursorB = 0;
        double dotProduct = 0;
        while (cursorA < keysA.Count && cursorB < keysB.Count)
        {
            if (keysA[cursorA] == keysB[cursorB])
            {
                dotProduct += valuesA[cursorA] * valuesB[cursorB];
                cursorA++;
                cursorB++;
                continue;
            }

            if (keysA[cursorA] < keysB[cursorB])
            {
                cursorA++;
                continue;
            }
            
            cursorB++;
        }

        return dotProduct / (Math.Sqrt(squaresSumOfA) * Math.Sqrt(squaresSumOfB));
    }
    
    public static double SolveOptimized(List<int> keysA, List<double> valuesA, List<int> keysB, List<double> valuesB)
    {
        ReadOnlySpan<int> aKeysSpan = CollectionsMarshal.AsSpan(keysA);
        ReadOnlySpan<double> aValuesSpan = CollectionsMarshal.AsSpan(valuesA);
        ReadOnlySpan<int> bKeysSpan = CollectionsMarshal.AsSpan(keysB);
        ReadOnlySpan<double> bValuesSpan = CollectionsMarshal.AsSpan(valuesB);
        
        double squaresSumOfA = 0;
        double squaresSumOfB = 0;

        foreach (var value in aValuesSpan)
            squaresSumOfA += value * value;
        
        foreach (var value in bValuesSpan)
            squaresSumOfB += value * value;

        if (squaresSumOfA is 0 || squaresSumOfB is 0)
            return 0;

        var cursorA = 0;
        var cursorB = 0;
        double dotProduct = 0;
        while (cursorA < aKeysSpan.Length && cursorB < bKeysSpan.Length)
        {
            if (aKeysSpan[cursorA] == bKeysSpan[cursorB])
            {
                dotProduct += aValuesSpan[cursorA] * bValuesSpan[cursorB];
                cursorA++;
                cursorB++;
                continue;
            }

            if (aKeysSpan[cursorA] < bKeysSpan[cursorB])
            {
                cursorA++;
                continue;
            }
            
            cursorB++;
        }

        return dotProduct / (Math.Sqrt(squaresSumOfA) * Math.Sqrt(squaresSumOfB));
    }
}
