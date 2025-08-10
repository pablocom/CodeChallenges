using System.Text;

namespace CodeChallenges.Solutions;

public static class ReorganizeString
{
    private const string NotPossibleToReorganize = "";
    
    public static string Solve(string s)
    {
        var span = s.AsSpan();
        if (span.Length <= 1)
            return s;

        var threshold = span.Length % 2 is 0
            ? span.Length / 2
            : span.Length / 2 + 1;

        var occurrencesByChar = new Dictionary<char, short>();

        foreach (var character in span)
        {
            if (!occurrencesByChar.TryAdd(character, 1))
                occurrencesByChar[character]++;

            if (occurrencesByChar[character] > threshold)
                return NotPossibleToReorganize;
        }

        var stringBuilder = new StringBuilder(span.Length);
        
        var priorityQueue = new PriorityQueue<(char Character, short Count), int>();
        foreach (var keyValuePair in occurrencesByChar)
            priorityQueue.Enqueue((keyValuePair.Key, keyValuePair.Value), -keyValuePair.Value);

        (char Character, short Count) prev = default;
        var hasPrev = false;

        while (priorityQueue.Count > 0)
        {
            var current = priorityQueue.Dequeue();

            stringBuilder.Append(current.Character);
            current.Count--;
            
            if (hasPrev && prev.Count > 0)
                priorityQueue.Enqueue(prev, -prev.Count);

            if (current.Count > 0)
            {
                prev = current;
                hasPrev = true;
            }
            else
            {
                hasPrev = false;
            }
        }
        
        return stringBuilder.ToString();
    }
}