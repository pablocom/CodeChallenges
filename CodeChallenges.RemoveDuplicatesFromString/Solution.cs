using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenges.RemoveDuplicatesFromString
{
    public class Solution
    {
        public string RemoveDuplicateLetters(string s)
        {
            var occurrencesByLetter = new Dictionary<char, int>();
            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                if (s.Contains(letter))
                {
                    var occurrences = s.Count(character => character == letter);
                    occurrencesByLetter.Add(letter, occurrences);
                }
            }

            var lettersByIndex = new Dictionary<char, int>();
            var lastAdditionIndex = int.MaxValue;
            var letters = s.ToCharArray().ToHashSet().OrderBy(x => x);

            foreach (var letter in letters)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == letter && occurrencesByLetter[letter] > 1 && i <= lastAdditionIndex)
                    {
                        occurrencesByLetter[letter]--;
                        continue;
                    }

                    if (s[i] == letter && occurrencesByLetter[letter] > 1 && i > lastAdditionIndex)
                    {
                        lettersByIndex.Add(letter, i);
                        lastAdditionIndex = i;
                        break;
                    }

                    if (s[i] == letter && occurrencesByLetter[letter] == 1 || s[i] == letter && i > lastAdditionIndex)
                    {
                        lettersByIndex.Add(letter, i);
                        lastAdditionIndex = Math.Min(i, lastAdditionIndex);
                        break;
                    }
                }
            }

            var removeDuplicateLetters = lettersByIndex.OrderBy(x => x.Value)
                .Select(x => x.Key).ToArray();
            return new string(removeDuplicateLetters);
        }
    }
}