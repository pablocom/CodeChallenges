using System;
using System.Linq;

namespace CodeChallenges.Solutions;

public class LongestCommonPrefix
{
    public string Solve(string[] strs)
    {
        var prefixToFind = strs.MinBy(x => x.Length).AsSpan();

        if (prefixToFind.IsEmpty)
            return string.Empty;

        while (prefixToFind.Length > 0)
        {
            for (var i = 0; i < strs.Length; i++)
            {
                var wordSpan = strs[i].AsSpan();

                if (!wordSpan.StartsWith(prefixToFind))
                    break;

                if (i == strs.Length - 1)
                    return prefixToFind.ToString();
            }

            prefixToFind = prefixToFind[..^1];
        }

        return string.Empty;
    }
}