using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class GroupAnagramsSolution
{
    public IEnumerable<IList<string>> GroupAnagrams(string[] strs) {
        if (strs.Length == 0) return new List<IList<string>>();
        
        var anagrams = new Dictionary<string,  IList<string>>();
        foreach (var str in strs) {
            var characters = str.ToCharArray();
            Array.Sort(characters);
            var s = new string(characters);
            if (anagrams.ContainsKey(s)) {
                anagrams[s].Add(str);
            } else {
                anagrams.Add(s, new List<string> { str });
            }
        }
        
        return anagrams.Values.ToList();
    }
}