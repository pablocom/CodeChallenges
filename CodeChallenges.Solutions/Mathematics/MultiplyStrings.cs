using System.Runtime.CompilerServices;

namespace CodeChallenges.Solutions.Mathematics;

public static class MultiplyStrings
{
    public static string Solve(string num1, string num2)
    {
        var sign1 = true;
        var sign2 = true;
        
        var numSpan1 = num1.AsSpan();
        var numSpan2 = num2.AsSpan();

        if (numSpan1.StartsWith('-'))
        {
            sign1 = false;
            numSpan1.Slice(1);
        }
        
        if (numSpan2.StartsWith('-'))
        {
            sign2 = false;
            numSpan2.Slice(1);
        }
        
        if (numSpan1 is "0" || numSpan2 is "0") 
            return "0"; 

        var biggestNum = numSpan1.Length > numSpan2.Length ? numSpan1 : numSpan2;
        var smallestNum = numSpan1.Length > numSpan2.Length ? numSpan2 : numSpan1;

        var individualMultiplications = new List<char[]>(smallestNum.Length);

        for (var i = smallestNum.Length - 1; i >= 0; i--)
        {
            var currentNum = smallestNum[i] - '0'; 
            var multiplication = Multiply(biggestNum, currentNum);
            individualMultiplications.Add(multiplication);
        }

        return SumAll(individualMultiplications);
    }

    private static string SumAll(List<char[]> individualMultiplications)
    {
        Span<char> result = stackalloc char[individualMultiplications[0].Length + individualMultiplications.Count];
        result.Fill('0'); 
        
        for (var offsetFromRight = 0; offsetFromRight < individualMultiplications.Count; offsetFromRight++)
        {
            var currentMultiplication = individualMultiplications[offsetFromRight];

            var carry = 0;
            var positionInResult = 0;

            for (var i = currentMultiplication.Length - 1; i >= 0; i--)
            {
                var distanceFromEnd = currentMultiplication.Length - 1 - i;
                positionInResult = result.Length - 1 - offsetFromRight - distanceFromEnd;
                
                var numInMultiplication = currentMultiplication[i] - '0';
                var numInResult = result[positionInResult] - '0';

                var sum = numInMultiplication + numInResult + carry;
                
                var digit = sum % 10;
                
                result[positionInResult] = (char)(digit + '0'); 
                
                carry = sum / 10;
            }

            if (carry > 0)
            {
                var finalNum = result[positionInResult - 1] - '0' + carry;
                result[positionInResult - 1] = (char)(finalNum + '0');
            }
        }

        return new string(result).TrimStart('0');
    }

    private static char[] Multiply(ReadOnlySpan<char> biggestNum, int multiplicator)
    {
        var multiplicationsLength = biggestNum.Length + 1;
        var results = new char[multiplicationsLength];

        var carry = 0;

        for (var i = biggestNum.Length - 1; i >= 0; i--)
        {
            var currentMultiplied = biggestNum[i] - '0';
            var multiplied = multiplicator * currentMultiplied;

            var currentResult = multiplied + carry;
            
            results[i + 1] = (char)(currentResult % 10 + '0'); 
            
            carry = currentResult / 10;
        }

        results[0] = (char)(carry + '0'); 

        return results;
    }
}