
using System;

namespace CodeChallenges.Solutions;

public class SubstringWithConcatenationOfAllWords
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        var totalWordsToCheck = words.Length;
        var wordLength = words[0].Length;
        var span = s.AsSpan();
        var occurrencesByWord = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (occurrencesByWord.TryGetValue(word, out var occurrences))
            {
                occurrencesByWord[word] = occurrences + 1;
                continue;
            }

            occurrencesByWord.Add(word, 1);
        }

        var indexes = new HashSet<int>();
        for (int index = 0; index < span.Length; index++)
        {
            if (IsConcatenatedSubstringFrom(index, span, occurrencesByWord, wordLength, totalWordsToCheck))
                indexes.Add(index);
        }

        return indexes.ToList();
    }

    private bool IsConcatenatedSubstringFrom(int index, ReadOnlySpan<char> span, 
        Dictionary<string, int> occurrencesByWord, int wordLength, int totalWordsToCheck)
    {
        var wordsUsages = 0;
        var wordsUsed = new Dictionary<string, int>();

        for (int i = index; i < span.Length - wordLength; i++)
        {
            var slice = span.Slice(i, wordLength).ToString();

            if (occurrencesByWord.TryGetValue(slice, out var occurrences))
            {
                if (wordsUsed.TryGetValue(slice, out var timesUsed))
                {
                    if (timesUsed == occurrences)
                        return false;

                    wordsUsed[slice] = timesUsed + 1;
                    
                }

                wordsUsed.Add(slice, 1);
                wordsUsages++;

                i += wordLength - 1;
            }

            if (wordsUsages == totalWordsToCheck)
                return true;
        }

        return false;
    }
}
