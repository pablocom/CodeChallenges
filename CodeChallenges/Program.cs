using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.TopKFrequentWords
{
    class Program
    {
        static void Main()
        {
            var wordList = new[] {"i", "love", "leetcode", "i", "love", "coding"};
            var result = Solution.TopKFrequent(wordList, 2);

        }
    }

    public static class Solution
    {
        public static IList<string> TopKFrequent(string[] words, int k)
        {
            var wordsAppearanceDictionary = new Dictionary<string, int>();

            foreach (var wordToSearch in words.Distinct())
            {
                var count = words.Count(w => w == wordToSearch);
                wordsAppearanceDictionary.Add(wordToSearch, count);
            }

            var list = wordsAppearanceDictionary.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => x.Key)
                .Take(k)
                .ToArray();

            return list;
        }
    }
}
