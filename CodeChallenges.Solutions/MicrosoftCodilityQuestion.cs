using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class MicrosoftCodilityQuestion
{
    public int Solution(string text, int[] costs)
    {
        var encounteredLetters = new HashSet<char>();
        var seenCharsMinCost = new Dictionary<char, CharsByCostLocator>();
        
        for (var i = 0; i < costs.Length; i++)
        {
            if (!seenCharsMinCost.ContainsKey(text[i]))
            {
                seenCharsMinCost.Add(text[i], new CharsByCostLocator(i, costs[i]));
                continue;
            }

            if (seenCharsMinCost[text[i]].Cost > costs[i])
            {
                seenCharsMinCost[text[i]].Cost = costs[i];
                seenCharsMinCost[text[i]].Position = i;
            }
        }
        
        int totalCost = 0;
        for (int i = 0; i < costs.Length; i++)
        {
            if (encounteredLetters.Contains(text[i]))
            {
                if (i != seenCharsMinCost[text[i]].Position)
                {
                    totalCost += costs[i];
                }
                    
            }

            encounteredLetters.Add(text[i]);
        }


        return 0;
    }

    private class CharsByCostLocator
    {
        public int Position { get; set; }
        public int Cost { get; set; }

        public CharsByCostLocator(int position, int cost)
        {
            Position = position;
            Cost = cost;
        }
    }
}