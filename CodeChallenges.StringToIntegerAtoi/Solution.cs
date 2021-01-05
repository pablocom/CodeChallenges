using System;
using System.Linq;

namespace CodeChallenges.StringToIntegerAtoi
{
    public class Solution
    {
        public int MyAtoi(string s)
        {
            if (HasAnyWordBeforeNumber(s)) 
                return 0;

            var preparedNumberInString = PrepareNumberInString(s);

            if (HasToSignsInARow(s))
                return 0;

            var actualPow = preparedNumberInString.Length;
            var positive = true;
            var result = 0d;

            foreach (var character in preparedNumberInString)
            {
                if (character == '-')
                {
                    positive = false;
                    actualPow--;
                }
                else if (int.TryParse(character.ToString(), out var number))
                {
                    var pow = Math.Pow(10, --actualPow);
                    var numberToSum = number * pow;
                    result += numberToSum;
                }
            }

            if (positive)
            {
                if (result >= int.MaxValue)
                    return int.MaxValue;

                return (int) result;
            }

            return -(int) result;
        }

        private bool HasToSignsInARow(string number)
        {
            var previousCharIsSign = false;
            foreach (var digit in number)
            {
                if (previousCharIsSign && (digit == '-' || digit == '+'))
                    return true;
                if (digit == '-' || digit == '+')
                    previousCharIsSign = true;
                else
                    previousCharIsSign = false;
            }

            return false;
        }

        private static string PrepareNumberInString(string s)
        {
            var trimmedNumberInString = s.Where(c => char.IsDigit(c) || c == '-' || c == '.').ToArray();
            var preparedNumberInString = new string(trimmedNumberInString).Split('.')[0];
            return preparedNumberInString;
        }

        private bool HasAnyWordBeforeNumber(string s)
        {
            var isAnyNumberBeforeFirstWord = false;
            foreach (var character in s.ToCharArray())
            {
                if (isAnyNumberBeforeFirstWord)
                    break;

                if (character == ' ' || character == '-' || character == '+')
                    continue;

                if (char.IsDigit(character))
                    isAnyNumberBeforeFirstWord = true;
                else
                    return true;
            }

            return false;
        }
    }
}