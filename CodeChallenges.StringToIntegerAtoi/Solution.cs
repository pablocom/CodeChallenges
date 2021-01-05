using System;
using System.Text.RegularExpressions;

namespace CodeChallenges.StringToIntegerAtoi
{
    public class Solution
    {
        public int MyAtoi(string str)
        {
            var index = 0;
            double sum = 0;
            var isNegative = false;
            str = str.Trim();
            if (str == null || str == string.Empty)
            {
                return 0;
            }
            var sign = 1;
            if (str[0] == '-')
            {
                isNegative = true;
                sign = -1;
                index = 1;

            }
            if (str[0] == '+')
            {
                index = 1;
            }
            while (index < str.Length)
            {
                if (!char.IsDigit(str[index])) break;
                sum = sum * 10 + str[index] - '0';
                if (isNegative == false && sum > int.MaxValue)
                    return int.MaxValue;
                index++;
            }
            return (int)sum * sign;
        }
    }
}