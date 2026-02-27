namespace CodeChallenges.Solutions;

public static class LengthOfLastWord
{
    public static int Solve(string str)
    {
        var lastWordEndIndex = -1;
        int i;
        
        for (i = str.Length - 1; i >= 0; i--)
        {
            if (lastWordEndIndex is -1 && str[i] is ' ')
                continue;

            if (lastWordEndIndex is -1)
            {
                lastWordEndIndex = i;
            }
            else if(str[i] is ' ')
            {
                break;
            }
        }
        
        return lastWordEndIndex - i;
    }
}