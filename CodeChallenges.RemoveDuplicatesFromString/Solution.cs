using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.RemoveDuplicatesFromString
{
    public class Solution
    {
        public string RemoveDuplicateLetters(string s)
        {
            var occurrencesByLetter = new Dictionary<char, int>();
            for (var letter = 'a'; letter <= 'z'; letter++)
            {
                var occurrences = s.Count(character => character == letter);
                occurrencesByLetter.Add(letter, occurrences);
            }

            var resultString = s;
            for (var letter = 'z'; letter >= 'a'; letter--) 
            {
                while (occurrencesByLetter[letter] > 1)
                {
                    resultString = RemoveFirstChar(resultString, letter);
                    occurrencesByLetter[letter]--;
                }

            }

            return resultString;
        }

        public string RemoveFirstChar(string text, char letter)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == letter)
                    return text.Remove(i, 1);
            }

            return text;
        }
    }
}