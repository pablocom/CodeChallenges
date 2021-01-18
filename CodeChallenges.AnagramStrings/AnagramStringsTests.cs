using NUnit.Framework;

namespace CodeChallenges.AnagramStrings
{
    public class AnagramStringsTests
    {
        [Test]
        public void Test1()
        {
            var text1 = "pablo";
            var text2 = "blpao";

            var isAnagram = new Solution().IsAnagram(text1, text2);
            
            Assert.True(isAnagram);
        }
    }
}