using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class AwsTest
{

    /*
     * Complete the 'processLogs' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY logs
     *  2. INTEGER threshold
     */

    public static List<string> ProcessLogs(List<string> logs, int threshold)
    {
        var userOccurrencesById = new Dictionary<int, int>();

        foreach (var log in logs)
        {
            var split = log.Split(' ');
            var senderUserId = int.Parse(split[0]);
            var receiverUserId = int.Parse(split[1]);

            if (senderUserId == receiverUserId)
            {
                AddOccurrenceToUser(userOccurrencesById, senderUserId);
                continue;
            }

            AddOccurrenceToUser(userOccurrencesById, senderUserId);
            AddOccurrenceToUser(userOccurrencesById, receiverUserId);
        }

        return userOccurrencesById.Where(x => x.Value >= threshold).OrderBy(x => x).Select(x => x.Key.ToString()).ToList();
    }

    private static void AddOccurrenceToUser(Dictionary<int, int> userOccurrencesById, int userId)
    {
        if (!userOccurrencesById.ContainsKey(userId))
        {
            userOccurrencesById.Add(userId, 1);
            return;
        }

        userOccurrencesById[userId]++;
    }
    
    
    public static List<int> numberOfItems(string s, List<int> startIndices, List<int> endIndices)
    {
        var accumulatedResults = new int[s.Length];

        bool hasSeenWall = false;
        int currentResult = 0;
        int potentialObjectsInContainer = 0;
        var span = s.AsSpan();
        for (var index = 0; index < span.Length; index++)
        {
            var character = span[index];
            if (character == '|' && !hasSeenWall)
            {
                hasSeenWall = true;
            }
            else if (character == '|' && hasSeenWall)
            {
                currentResult += potentialObjectsInContainer;
                potentialObjectsInContainer = 0;
            }
            else if (character == '*' && hasSeenWall)
            {
                potentialObjectsInContainer++;
            }

            accumulatedResults[index] = currentResult;
        }

        var results = new List<int>(startIndices.Count);
        for (var i = 0; i < startIndices.Count; i++)
        {
            results.Add(accumulatedResults[endIndices[i] - 1] - accumulatedResults[startIndices[i] - 1]);
        }

        return results;
    }
}