namespace CodeChallenges.Solutions.Arrays;

public static class ValidMountain
{
    public static bool Solve(int[] arr)
    {
        ReadOnlySpan<int> span = arr.AsSpan();
        var i = 0;
        while (i < span.Length - 1 && span[i] < span[i + 1]) 
            i++;

        if (i == 0 || i == span.Length - 1)
            return false;

        while (i < span.Length - 1 && span[i] > span[i + 1])
            i++;

        return i == span.Length - 1;
    }
}