using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.Strings;

public static class LongestSubstringPalindrome
{
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static string Solve(string s)
    {
        var text = s.AsSpan();
        ReadOnlySpan<char> result = "";

        for (var i = 0; i < text.Length; i++)
        {
            var leftPointer = i;
            var rightPointer = i;

            while (leftPointer >= 0 && rightPointer < text.Length && text[leftPointer] == text[rightPointer])
            {
                var palindromeLength = rightPointer - leftPointer + 1;
                if (palindromeLength > result.Length) 
                    result = text.Slice(leftPointer, palindromeLength);

                leftPointer--;
                rightPointer++;
            }
            
            leftPointer = i;
            rightPointer = i + 1;

            while (leftPointer >= 0 && rightPointer < text.Length && text[leftPointer] == text[rightPointer])
            {
                var palindromeLength = rightPointer - leftPointer + 1;
                if (palindromeLength > result.Length) 
                    result = text.Slice(leftPointer, palindromeLength);

                leftPointer--;
                rightPointer++;
            }
        }
        
        return new string(result);
    }
}