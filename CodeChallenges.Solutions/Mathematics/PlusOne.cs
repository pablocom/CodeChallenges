namespace CodeChallenges.Solutions.Mathematics;

public static class PlusOne
{
    public static int[] Solve(int[] digits)
    {
        if (digits[^1] is not 9)
        {
            digits[^1]++;
            return digits;
        }

        digits[^1] = 0;

        for (var i = digits.Length - 2; i >= 0; i--)
        {
            if (digits[i] is not 9)
            {
                digits[i]++;
                return digits;
            }

            digits[i] = 0;
        }

        var newDigits = new int[digits.Length + 1];
        newDigits[0] = 1;
        Array.Copy(digits, 0, newDigits, 1, digits.Length);

        return newDigits;
    }
}