using System.Collections.Generic;

namespace CodeChallenges.LongestCommonSubsequence
{
    public class Solution
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var queue = new Queue<char>();
            var commonSubsequenceLength = 0;

            foreach (var character in text2.ToCharArray()) 
                queue.Enqueue(character);

            foreach (var character in text1.ToCharArray())
            {
                if (character == queue.Peek())
                {
                    queue.Dequeue();
                    commonSubsequenceLength++;
                }
            }

            return commonSubsequenceLength;
        }
    }
}