using System;

namespace CodeChallenges.StringToIntegerAtoi
{
    public class Solution
    {
        public static int MyAtoi(string numberInString)
        {
            var actualPow = numberInString.Length;
            var result = 0d;

            foreach (var character in numberInString.ToCharArray())
            {
                if (int.TryParse(character.ToString(), out var number))
                {
                    var pow = Math.Pow(10, --actualPow);
                    var numberToSum = number * pow;
                    result += numberToSum;
                }
            }

            return (int) result;
        }
    }
}