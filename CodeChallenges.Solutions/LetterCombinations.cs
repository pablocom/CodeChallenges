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
            return new List<string>(0);

        var letterCombinations = new List<string>();
        Backtracking(letterCombinations, digits, LettersByDigit, new List<char>(), 0);
        return letterCombinations;
    }

    private static void Backtracking(List<string> allLetterCombinations, string digits, Dictionary<char, string> dict,
        List<char> backTrackList, int start)
    {
        if (backTrackList.Count == digits.Length) 
            allLetterCombinations.Add(string.Join("", backTrackList));

        for (var i = start; i < digits.Length; i++)
        {
            for (var j = 0; j < dict[digits[i]].Length; j++)
            {
                backTrackList.Add(dict[digits[i]][j]);
                Backtracking(allLetterCombinations, digits, dict, backTrackList, i + 1);
                backTrackList.RemoveLast();
            }
        }
    }
}

public static class ListExtensions
{
    public static void RemoveLast<T>(this List<T> list)
    {
        list.RemoveAt(list.Count - 1);
    }
}
