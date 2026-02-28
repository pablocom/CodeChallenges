namespace CodeChallenges.Solutions.Strings;

public static class MaxSubstring 
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
            maxLength = System.Math.Max(maxLength, queue.Count);
        }
            
        return maxLength;
    }
}