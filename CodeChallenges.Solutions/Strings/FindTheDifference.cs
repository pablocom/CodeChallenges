namespace CodeChallenges.Solutions.Strings;

public static class FindTheDifference
{
    public static char SolveWithDictionary(string s, string t)
    {
        var charAppearances = new Dictionary<char, int>();

        foreach (var character in t)
        {
            if (charAppearances.TryGetValue(character, out var count))
                charAppearances[character] = count + 1;
            else 
                charAppearances.Add(character, 1);
        }

        foreach (var character in s)
        {
            if (!charAppearances.TryGetValue(character, out var count)) 
                continue;
            
            if (count is 1)
                charAppearances.Remove(character);
            else
                charAppearances[character] = count - 1;
        }
        
        return charAppearances.Keys.First();
    }

    public static char SolveWithXor(string s, string t)
    {
        var xorValue = 0;
        
        foreach(var character in s) 
            xorValue ^= character;
        
        foreach(var character in t)
            xorValue ^= character;
        
        return (char) xorValue;
    }
}