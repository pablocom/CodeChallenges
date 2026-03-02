using System.Text;

namespace CodeChallenges.Solutions.Strings;

public static class MergeStringsAlternately
{
    public static string Solve(string word1, string word2)
    {
        var sb = new StringBuilder(word1.Length + word2.Length);
        var cursor = 0;

        while (cursor < word1.Length || cursor < word2.Length)
        {
            if (cursor < word1.Length) 
                sb.Append(word1[cursor]);

            if (cursor < word2.Length) 
                sb.Append(word2[cursor]);

            cursor++;
        }
        
        return sb.ToString();
    }
}