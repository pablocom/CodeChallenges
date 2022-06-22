using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class LetterCombinations
{
    private static readonly IReadOnlyDictionary<char, char[]> LettersByDigit = new Dictionary<char, char[]>()
    {
        {'2', new char[]{ 'a', 'b', 'c' } },
        {'3', new char[]{ 'd', 'e', 'f' } },
        {'4', new char[]{ 'g', 'h', 'i' } },
        {'5', new char[]{ 'j', 'k', 'l' } },
        {'6', new char[]{ 'm', 'n', 'o' } },
        {'7', new char[]{ 'p', 'q', 'r', 's' } },
        {'8', new char[]{ 't', 'u', 'v' } },
        {'9', new char[]{ 'w', 'x', 'y', 'z' } }
    };

    public IList<string> Solve(string digits)
    {
        if (!digits.Any())
        {
            return new List<string>(0);
        }

        var lengths = digits.Select(d => LettersByDigit[d].Length);
        int resultLength = 1;
        foreach (var length in lengths)
        {
            resultLength *= length;
        }

        var result = new string[resultLength];
        for (int d = 0; d < digits.Length; d++)
        {
            char digit = digits[d];

            for (int i = 0; i < resultLength; i++) 
            {
                var multiplier = d == 0 ? 1 : LettersByDigit[digit].Length * d;
                var positionOfCharToFill = ((i * multiplier) / LettersByDigit[digit].Length) % LettersByDigit[digit].Length;

                result[i] = string.Empty + result[i] + LettersByDigit[digit][positionOfCharToFill];
            }
        }

        return result.ToList();
    }
}
