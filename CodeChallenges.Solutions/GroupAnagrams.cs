using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class GroupAnagramsSolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        if (strs.Length == 0) return new List<IList<string>>();
        
        Dictionary<string, IList<string>> anagrams = new Dictionary<string,  IList<string>>();
        foreach (string str in strs) {
            char[] characters = str.ToCharArray();
            Array.Sort(characters);
            string s = new string(characters);
            if (anagrams.ContainsKey(s)) {
                anagrams[s].Add(str);
            } else {
                anagrams.Add(s, new List<string> { str });
            }
        }
        
        return anagrams.Values.ToList();
    }
}