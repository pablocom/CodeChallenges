using System;

namespace CodeChallenges.Solutions
{
    public class LongestPalindromeFinder
    {
        public static string LongestPalindrome(string text)
        {
            if (string.IsNullOrEmpty(text)) 
                return string.Empty;

            int start = 0, end = 0;

            for (var i = 0; i < text.Length; i++)
            {
                var length1 = ExpandAroundCenter(text, i, i);
                var length2 = ExpandAroundCenter(text, i, i + 1);
                var length = Math.Max(length1, length2);
                if (length > end - start)
                {
                    start = i - (length - 1) / 2;
                    end = i + length / 2;
                }
            }

            return text.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string text, int left, int right)
        {
            int leftCursor = left, rightCursor = right;
            while (leftCursor >= 0 && rightCursor < text.Length && text[leftCursor] == text[rightCursor])
            {
                leftCursor--;
                rightCursor++;
            }

            return rightCursor - leftCursor - 1;
        }
    }
}