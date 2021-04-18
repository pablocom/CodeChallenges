using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.TopKFrequentWords
{
    public static class TopKFrequentWords
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