using System.Text;

namespace CodeChallenges.Solutions;

// https://leetcode.com/problems/count-and-say/
public sealed class CountAndSay
{
    public string Solve(int n)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(n);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(n, 30);

        if (n is 1)
            return "1";

        return GetRunLengthEncoding(Solve(n - 1));
    }

    private static string GetRunLengthEncoding(string span)
    {
        var sb = new StringBuilder();

        var previous = span[0];
        var currentOccurrences = 1;
        foreach (char number in span.Skip(1))
        {
            if (number != previous)
            {
                sb.Append(currentOccurrences).Append(previous);
                currentOccurrences = 1;
            }
            else
            {
                currentOccurrences++;
            }

            previous = number;
        }

        sb.Append(currentOccurrences).Append(previous);

        return sb.ToString();
    }
}
