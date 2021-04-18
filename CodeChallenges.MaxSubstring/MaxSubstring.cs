using System;
using System.Collections.Generic;

namespace CodeChallenges.MaxSubstring
{
    public class Solution 
    {
        public static int LengthOfLongestSubstring(string s) 
        {
            var queue = new Queue<char>();
            var maxLength = 0;
            
            foreach (var character in s.ToCharArray()) 
            {
                while (queue.Contains(character)) 
                {
                    queue.Dequeue();
                }
                queue.Enqueue(character);
                maxLength = Math.Max(maxLength, queue.Count);
            }
            
            return maxLength;
        }
    }
}