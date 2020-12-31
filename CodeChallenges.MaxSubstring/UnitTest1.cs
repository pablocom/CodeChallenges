using NUnit.Framework;

namespace CodeChallenges.MaxSubstring
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var word = " ";

            var maxLength = Solution.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(1));
        }
        
        [Test]
        public void Test2()
        {
            var word = "dvdf";

            var maxLength = Solution.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(3));
        }
        
        [Test]
        public void Test3()
        {
            var word = "abcabcbb";

            var maxLength = Solution.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(3));
        }
        
        [Test]
        public void Test4()
        {
            var word = "bbbbb";

            var maxLength = Solution.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(1));
        }
        
        [Test]
        public void Test5()
        {
            var word = "cdd";

            var maxLength = Solution.LengthOfLongestSubstring(word);
            
            Assert.That(maxLength, Is.EqualTo(2));
        }
    }
}