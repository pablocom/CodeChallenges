using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class LetterCombinations
{
    private static readonly Dictionary<char, string> LettersByDigit = new Dictionary<char, string>()
    {
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

    public IList<string> Solve(string digits)
    {
        if (!digits.Any())
        {
            return new List<string>(0);
        }

        int resultLength = 1;
        foreach (var length in digits.Select(d => LettersByDigit[d].Length))
        {
            resultLength *= length;
        }

        var list = new List<string>();

        Backtrack(list, digits, LettersByDigit, new List<char>(), 0);

        return list;
    }

    private static void Backtrack(List<string> list, string digits, Dictionary<char, string> dict, List<char> temp, int start)
    {
        if (temp.Count == digits.Length) 
            list.Add(string.Join("", temp));

        for (var i = start; i < digits.Length; i++)
        {
            for (var j = 0; j < dict[digits[i]].Length; j++)
            {
                temp.Add(dict[digits[i]][j]);

                Backtrack(list, digits, dict, temp, i + 1);

                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
