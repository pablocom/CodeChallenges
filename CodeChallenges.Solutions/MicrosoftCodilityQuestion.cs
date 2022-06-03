using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class MicrosoftCodilityQuestion
{
    public int Question2(int[] A, int K)
    {
        var result = 0;
        var addedNumbersCount = 0;
        var lastMinNumberAdded = int.MinValue;

        for (var i = 0; i < A.Length; i++)
        {
            if ((i + 1) % 2 == 0)
                continue;

            if (addedNumbersCount < K)
            {
                result += A[i];
                addedNumbersCount++;
                lastMinNumberAdded = Math.Min(lastMinNumberAdded, A[i]);
                continue;
            }

            if (addedNumbersCount == K && lastMinNumberAdded < A[i])
            {
                result = result + lastMinNumberAdded + A[i];
                lastMinNumberAdded = A[i];
            }
        }

        return result;
    }
    
    public int Question1(string S, int[] C)
    {
        var maxCost = int.MaxValue;
        var currentCosts = 0;
        var totalCost = 0;
        var lastSeenChar = ':';
        
        for (var i = 0; i < S.Length; i++)
        {
            if (S[i] == lastSeenChar)
            {
                maxCost = maxCost < C[i] ? C[i] : maxCost;
                
                currentCosts += C[i];
                if (i + 1 >= S.Length || S[i + 1] != lastSeenChar)
                {
                    totalCost += currentCosts - maxCost;
                    currentCosts = C[i];
                    maxCost = C[i];
                }
                
                continue;
            }

            currentCosts = C[i];
            lastSeenChar = S[i];
            maxCost = C[i];
        }

        return totalCost;
    }
    
}