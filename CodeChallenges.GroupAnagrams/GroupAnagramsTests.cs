using NUnit.Framework;

namespace CodeChallenges.GroupAnagrams
{
    public class GroupAnagramsTests
    {
        [Test]
        public void Test1()
        {
            var list = new[] {"eat", "tea", "tan", "ate", "nat", "bat"};
            var expectedList = new[] {new[] {"bat"}, new[] {"nat", "tan"}, new[] {"ate", "eat", "tea"}};

            var result = new Solution().GroupAnagrams(list);
            
            CollectionAssert.AreEquivalent(expectedList, result);
        }
    }
}