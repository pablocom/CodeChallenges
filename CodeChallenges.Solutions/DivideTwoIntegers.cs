namespace CodeChallenges.Solutions;

public sealed class DivideTwoIntegers
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        if (dividend == int.MinValue && divisor == 1)
            return int.MinValue;

        var dividendIsNegative = dividend < 0;
        var divisorIsNegative = divisor < 0;
        var sign = (dividendIsNegative && !divisorIsNegative) || (!dividendIsNegative && divisorIsNegative) ? -1 : 1;
        
        var absDividend = Math.Abs((long)dividend);
        var absDivisor = Math.Abs((long)divisor);
        var quotient = 0;
        long currentMultipliedValue = 0;

        while (currentMultipliedValue < absDividend) 
        {
            currentMultipliedValue += absDivisor;
            quotient++;
        }

        if (currentMultipliedValue > absDividend)
            quotient--;

        return quotient * sign;
    }
}
