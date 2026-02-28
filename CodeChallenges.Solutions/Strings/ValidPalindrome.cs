namespace CodeChallenges.Solutions.Strings;

// https://leetcode.com/problems/valid-palindrome/
public static class ValidPalindrome
{
    public static bool Solve(string word)
    {
        var wordSpan = word.AsSpan();
        var leftCursor = 0;
        var rightCursor = wordSpan.Length - 1;

        while (leftCursor < rightCursor)
        {
            var charAtLeft = wordSpan[leftCursor];
            var charAtRight = wordSpan[rightCursor];

            if (!char.IsLetterOrDigit(charAtLeft))
            {
                leftCursor++;
                continue;
            }

            if (!char.IsLetterOrDigit(charAtRight))
            {
                rightCursor--;
                continue;
            }
            
            if (char.ToUpperInvariant(charAtLeft) != char.ToUpperInvariant(charAtRight))
            {
                return false;
            }
            
            leftCursor++;
            rightCursor--;
        }

        return true;
    }
}