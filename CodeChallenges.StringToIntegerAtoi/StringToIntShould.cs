using NUnit.Framework;

namespace CodeChallenges.StringToIntegerAtoi
{
    public class StringToIntShould
    {
        [TestCase("42", 42)]
        [TestCase("7", 7)]
        [TestCase("   42", 42)]
        [TestCase("4193 with words", 4193)]
        [TestCase("   -42", -42)]
        [TestCase("-4193 with words", -4193)]
        [TestCase("-91283472332", -2147483648)]
        [TestCase("words and 987", 0)]
        [TestCase("3.14159", 3)]
        [TestCase("+1", 1)]
        [TestCase("+-12", 0)]
        [TestCase("21474836460", 2147483647)]
        [TestCase("00000-42a1234", 0)]
        [TestCase("  -0012a42", -12)]
        public void ConvertStringIntoIntegerIfPossible(string numberInString, int expectedResult)
        {
            var number = new Solution().MyAtoi(numberInString);

            Assert.That(number, Is.EqualTo(expectedResult));
        }
    }
}