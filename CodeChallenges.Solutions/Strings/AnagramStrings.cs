namespace CodeChallenges.Solutions.Strings;

public class AnagramStrings 
{
    public bool IsAnagram(string s, string t) 
    {
        if (s == null || t == null)
            return false;
        if (s.Length != t.Length)
            return false;
        
        var alphabet = new int[26];
        for (var i = 0; i < s.Length; i++) 
        {
            alphabet[s[i] - 'a']++;
            alphabet[t[i] - 'a']--;
        }
        
        foreach (var i in alphabet) 
            if (i != 0) 
                return false;
        
        return true;
    }
}