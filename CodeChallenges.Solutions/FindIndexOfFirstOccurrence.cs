namespace CodeChallenges.Solutions;

public class FindIndexOfFirstOccurrence
{
    public int StrStr(string haystack, string needle)
    {
        var spanHaystack = haystack.AsSpan();
        var spanNeedle = needle.AsSpan();
        haystack.Contains(needle);

        for (var i = 0; i < spanHaystack.Length; i++)
        {
            if (spanHaystack.Slice(i, spanNeedle.Length).SequenceEqual(spanNeedle))
                return i;
        }
        return -1;
    }
}