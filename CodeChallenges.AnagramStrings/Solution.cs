namespace CodeChallenges.AnagramStrings
{
    public class Solution 
    {
        public bool IsAnagram(string s, string t) 
        {
            if (s == null || t == null)
                return false;
            if (s.Length != t.Length)
                return false;
        
            var alphabet = new int[26];
            for (int i = 0; i < s.Length; i++) 
            {
                alphabet[s[i] - 'a']++;
                alphabet[t[i] - 'a']--;
            }
        
            foreach (int i in alphabet) 
                if (i != 0) 
                    return false;
        
            return true;
        }
    }
}