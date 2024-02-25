using CodeChallenges.Solutions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CodeChallenges.UnitTests;

public class GroupAnagramsTests
{
    [Ignore("Not solved")]
    [Test]
    public void Test1()
    {
        var list = new[] {"eat", "tea", "tan", "ate", "nat", "bat"};
        var expectedList = new[] {new[] {"bat"}, new[] {"nat", "tan"}, new[] {"ate", "eat", "tea"}};

        var result = new GroupAnagramsSolution().GroupAnagrams(list);
            
        CollectionAssert.AreEquivalent(expectedList, result);
    }
}