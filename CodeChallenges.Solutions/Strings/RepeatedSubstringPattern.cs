namespace CodeChallenges.Solutions.Strings;

public static class RepeatedSubstringPattern
{
    public static bool Solve(string s) => SolveWithKmp(s);

    public static bool SolveWithKmp(string s)
    {
        var len = s.Length;
        var failure = new int[len];

        for (var i = 1; i < len; i++)
        {
            var j = failure[i - 1];

            while (j > 0 && s[i] != s[j])
                j = failure[j - 1];

            if (s[i] == s[j])
                j++;

            failure[i] = j;
        }

        var longestPrefixSuffix = failure[len - 1];
        var unitLength = len - longestPrefixSuffix;

        return longestPrefixSuffix != 0 && len % unitLength == 0;
    }

    public static bool SolveWithDivisors(string s)
    {
        var span = s.AsSpan();
        var divisor = 2;

        while (divisor < span.Length + 1)
        {
            if (span.Length % divisor != 0)
            {
                divisor++;
                continue;
            }

            var substringLength = (span.Length + 1) / divisor;
            var substring = span[..substringLength];

            for (var i = 1; i < divisor; i++)
            {
                if (!span.Slice(substringLength * i).StartsWith(substring))
                    break;

                if (i == divisor - 1)
                    return true;
            }

            divisor++;
        }

        return false;
    }
}
