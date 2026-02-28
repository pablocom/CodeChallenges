namespace CodeChallenges.Solutions.Strings;

public static class IsSubsequence
{
    public static bool Solve(string s, string t)
    {
        if (s.Length > t.Length)
            return false;

        if (s == t)
            return true;

        var sCursor = 0;

        for (var tCursor = 0; tCursor < t.Length; tCursor++)
        {
            if (sCursor == s.Length)
                return true;

            if (s[sCursor] == t[tCursor])
                sCursor++;
        }
        
        return sCursor == s.Length;
    }
}