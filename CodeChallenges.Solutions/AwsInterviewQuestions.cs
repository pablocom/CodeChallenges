using System;
using System.Linq;

namespace CodeChallenges.Solutions;

public class AwsInterviewQuestions
{
    public static int MinSwapsRequired(string s)
    {
        if (s is null || s.Length == 0)
            return -1;

        if (s.Length == 1)
            return 0;
        
        var charArray = s.ToCharArray();
        int minSwapsRequired = 0;

        int leftCursor = 0;
        int rightCursor = charArray.Length - 1;

        while (leftCursor < rightCursor)
        {
            if (charArray[leftCursor] == charArray[rightCursor])
            {
                leftCursor++;
                rightCursor--;
                continue;
            }

            var rightCursorForReplace = rightCursor - 1;

            while (rightCursorForReplace > leftCursor)
            {
                if (rightCursorForReplace == leftCursor && 
                    charArray[rightCursorForReplace] != charArray[leftCursor])
                    return -1;
                
                if (charArray[rightCursorForReplace] != charArray[rightCursor])
                {
                    minSwapsRequired++;
                        
                    var aux = charArray[rightCursor];
                    charArray[rightCursor] = charArray[rightCursorForReplace];
                    charArray[rightCursorForReplace] = aux;
                    
                    break;
                }

                rightCursorForReplace--;
            }

            if (charArray[leftCursor] != charArray[rightCursor])
                return -1;
            leftCursor++;
            rightCursor--;
        }
        
        return minSwapsRequired;
    }
    
    public static int GetMaxFreqDeviation(string s)
    {
        if (s.Length < 1)
            return 0;
        
        if (s.Length == 1)
            return 0;

        if (s.Distinct().Count() == 1)
            return 0;
        
        int maxDeviation = 0, previousFrequency = 1, currentFrequency = 1;
        char previousChar = s[0];

        for (int i = 1; i <= s.Length; i++)
        {
            if (i == s.Length - 1)
            {
                maxDeviation = Math.Max(
                    maxDeviation, 
                    Math.Abs(previousFrequency - currentFrequency)
                );
                break;
            }
            
            if (previousChar == s[i])
            {
                currentFrequency++;
            }
            else
            {
                maxDeviation = Math.Max(
                    maxDeviation, 
                    Math.Abs(previousFrequency - currentFrequency)
                );
                
                previousFrequency = currentFrequency;
                
                if (i < s.Length - 1)
                    currentFrequency = 1;
            }

            previousChar = s[i];
        }
        
        return maxDeviation;
    }
}