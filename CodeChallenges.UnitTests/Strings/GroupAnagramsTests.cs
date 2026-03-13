using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public class GroupAnagramsTests
{
    [Fact]
    public void Test1()
    {
        var list = new[] {"eat", "tea", "tan", "ate", "nat", "bat"};
        var expectedList = new string[][] { ["bat"], ["nat", "tan"], ["ate", "eat", "tea"]};

        var result = new GroupAnagramsSolution().GroupAnagrams(list);

        var normalize = (IEnumerable<IEnumerable<string>> groups) =>
            groups.Select(g => string.Join(",", g.Order())).Order().ToList();
        normalize(result).ShouldBe(normalize(expectedList));
    }
}
