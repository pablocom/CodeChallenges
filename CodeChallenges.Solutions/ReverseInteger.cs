using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CodeChallenges.Solutions;

public static class ReverseInteger
{ 
    // 32-bit max value 2147483647
    // 32-bit min value -2147483648
    
    private static FrozenDictionary<int, int> MaxDigitInInt32ByPosition = new KeyValuePair<int, int>[]
    {
        new(0, 2), new(1, 1), new(2, 4), new(3, 7), new(4, 4), new(5, 8), new(6, 3), new(7, 6), new(8, 4), new(9, 7)
    }.ToFrozenDictionary();
    
    public static int ReverseOptimized(int input)
    {
        var y = 0;
        
        while (input != 0) {
            if (y is > int.MaxValue / 10 or < int.MinValue / 10) {
                return 0;
            }
            y *= 10;
            y += input % 10;
            input /= 10;
        }

        return y;
    }
    
    public static int Reverse(int input)
    {
        var sign = input >= 0 ? 1 : -1;

        if (input is int.MinValue)
            return 0;
        
        var inputAsPositive = sign > 0 ? input : input * -1;
        var reversedDigits = GetReversedDigitsOf(inputAsPositive);

        var result = 0;
        var currentPow = reversedDigits.Length - 1;
        var maxDigitTracker = true;
        
        for (var i = 0; i < reversedDigits.Length; i++)
        {
            var digit = reversedDigits[i];

            if (reversedDigits.Length is 10)
            {
                if (maxDigitTracker && digit > MaxDigitInInt32ByPosition[i])
                    return 0;
                
                if (digit < MaxDigitInInt32ByPosition[i])
                    maxDigitTracker = false;
            }
            
            result += (int)(digit * Math.Pow(10, currentPow));
            currentPow--;
        }

        return result * sign;
    }

    private static ReadOnlySpan<int> GetReversedDigitsOf(int number)
    {
        var result = new List<int>();
        
        while (number >= 10) 
        {
            result.Add(number % 10);
            number /= 10;
        }
        
        result.Add(number % 10);
        
        return CollectionsMarshal.AsSpan(result);
    }
}