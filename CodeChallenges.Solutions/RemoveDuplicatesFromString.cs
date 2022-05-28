using System.Collections.Generic;

namespace CodeChallenges.Solutions;

public class RemoveDuplicatesFromString
{
    public string RemoveDuplicateLetters(string text)
    {
        if (text.Length <= 1)
            return text;
            
        var lastIndex = new int[26];
        for (var i = 0; i < text.Length; i++)
            lastIndex[text[i] - 'a'] = i;

        var lexiStack = new Stack<char>();
        var addedCharacters = new HashSet<char>();

        for (var i = 0; i < text.Length; i++)
        {
            var character = text[i];

            if (addedCharacters.Contains(character))
                continue;

            while (lexiStack.Count > 0 && 
                   lexiStack.Peek() > character && i < lastIndex[lexiStack.Peek() - 'a']) 
                addedCharacters.Remove(lexiStack.Pop());

            addedCharacters.Add(character);
            lexiStack.Push(character);
        }
            
        var result = string.Empty;
        while (lexiStack.Count > 0) 
            result = lexiStack.Pop() + result;

        return result;
    }
}