using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Solutions;

public class FindAndReplaceString
{
    public string FindReplaceString(string text, int[] indexes, string[] sources, string[] targets)
    {
        var indexesByPosition = new Dictionary<int, int>(); // keys represent replacement start (indexes value)

        for (var i = 0; i < indexes.Length; i++)
        {
            if (text.Substring(indexes[i]).StartsWith(sources[i])) // filter non matching sources for replacements
                indexesByPosition.Add(indexes[i], i);
        }

        var stringBuilder = new StringBuilder();
        for (var i = 0; i < text.Length;)
        {
            if (indexesByPosition.ContainsKey(i))
            {
                stringBuilder.Append(targets[indexesByPosition[i]]);
                i += sources[indexesByPosition[i]].Length;
            }
            else
            {
                stringBuilder.Append(text[i]);
                i++;
            }
        }

        return stringBuilder.ToString();
    }
}