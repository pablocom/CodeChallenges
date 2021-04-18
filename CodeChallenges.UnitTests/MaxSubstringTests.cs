using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class MaxSubstringTests
    {
        [Test]
        public void Test1()
        {
            var word = " ";

            var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(1));
        }
        
        [Test]
        public void Test2()
        {
            var word = "dvdf";

            var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(3));
        }
        
        [Test]
        public void Test3()
        {
            var word = "abcabcbb";

            var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(3));
        }
        
        [Test]
        public void Test4()
        {
            var word = "bbbbb";

            var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(1));
        }
        
        [Test]
        public void Test5()
        {
            var word = "cdd";

            var maxLength = MaxSubstring.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(2));
        }
    }
}