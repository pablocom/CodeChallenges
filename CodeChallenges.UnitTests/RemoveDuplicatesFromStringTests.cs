using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class RemoveDuplicatesFromStringTests
    {
        [Test]
        public void Test1()
        {
            var text = "bcabc";

            var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("abc"));
        } 
        
        [Test]
        public void Test2()
        {
            var text = "cbacdcbc";

            var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("acdb"));
        }
        
        [Test]
        public void Test3()
        {
            var text = "cdadabcc";

            var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("adbc"));
        }
        
        [Test]
        public void Test4()
        {
            var text = "leetcode";

            var result = new RemoveDuplicatesFromString().RemoveDuplicateLetters(text);

            Assert.That(result, Is.EqualTo("letcod"));
        }
    }
}