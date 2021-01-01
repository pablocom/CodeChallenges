using NUnit.Framework;

namespace CodeChallenges.RemoveDuplicatesFromString
{
    public class RemoveDuplicatesTests
    {
        [Test]
        public void Test1()
        {
            var text = "bcabc";

            var result = new Solution().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("abc"));
        } 
        
        [Test]
        public void Test2()
        {
            var text = "cbacdcbc";

            var result = new Solution().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("acdb"));
        }
        
        [Test]
        public void Test3()
        {
            var text = "cdadabcc";

            var result = new Solution().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("adbc"));
        }
        
        [Test]
        public void Test4()
        {
            var text = "leetcode";

            var result = new Solution().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("letcod"));
        }
    }
}