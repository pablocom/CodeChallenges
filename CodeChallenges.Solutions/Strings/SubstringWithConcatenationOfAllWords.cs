namespace CodeChallenges.Solutions.Strings;

public class SubstringWithConcatenationOfAllWords
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        
        if (s == null || words == null || words.Length == 0) 
            return new List<int>();

        var wordLength = words[0].Length;
        var permutationLength = wordLength * words.Length;
        if (s.Length < permutationLength) 
            return new List<int>();

        var wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount.Add(word, 1);
        }

        var result = new List<int>();

        for (var i = 0; i < wordLength; i++)
        {
            var startingIndex = i;
            var wordsFound = new Dictionary<string, int>();
            var count = 0;

            for (var right = i; right <= s.Length - wordLength; right += wordLength)
            {
                var slice = s.Substring(right, wordLength);

                if (wordCount.ContainsKey(slice))
                {
                    if (wordsFound.ContainsKey(slice))
                    {
                        wordsFound[slice]++;
                    }
                    else
                    {
                        wordsFound.Add(slice, 1);
                    }

                    count++;

                    while (wordsFound[slice] > wordCount[slice])
                    {
                        var leftWord = s.Substring(startingIndex, wordLength);
                        wordsFound[leftWord]--;
                        count--;
                        startingIndex += wordLength;
                    }

                    if (count == words.Length)
                        result.Add(startingIndex);
                }
                else
                {
                    wordsFound.Clear();
                    count = 0;
                    startingIndex = right + wordLength;
                }
            }
        }

        return result;
    }
}