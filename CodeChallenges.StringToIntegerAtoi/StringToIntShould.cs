using NUnit.Framework;

namespace CodeChallenges.StringToIntegerAtoi
{
    public class StringToIntShould
    {
        [TestCase("42", 42)]
        [TestCase("7", 7)]
        [TestCase("   -42", -42)]
        public void ConvertStringIntoIntegerIfPossible(string numberInString, int expectedResult)
        {
            var number = Solution.MyAtoi(numberInString);

            Assert.That(number, Is.EqualTo(expectedResult));
        }
    }
}