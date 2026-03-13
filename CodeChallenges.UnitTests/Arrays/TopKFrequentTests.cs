using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class TopKFrequentTests
{
    [Fact]
    public void ReturnsTopTwoFrequentElements()
    {
        var result = TopKFrequent.Solve(new[] { 1, 1, 1, 2, 2, 3 }, 2);
        result.ShouldBe(new[] { 1, 2 });
    }

    [Fact]
    public void SingleElement()
    {
        var result = TopKFrequent.Solve(new[] { 1 }, 1);
        result.ShouldBe(new[] { 1 });
    }

    [Fact]
    public void AllElementsEqualFrequency()
    {
        var result = TopKFrequent.Solve(new[] { 1, 2, 3 }, 3);
        result.ShouldBe(new[] { 1, 2, 3 }, ignoreOrder: true);
    }

    [Fact]
    public void NegativeNumbers()
    {
        var result = TopKFrequent.Solve(new[] { -1, -1, 2, 2, 2, 3 }, 1);
        result.ShouldBe(new[] { 2 });
    }

    [Fact]
    public void KEqualsArrayLength()
    {
        var result = TopKFrequent.Solve(new[] { 3, 0, 1, 0 }, 3);
        result.ShouldBe(new[] { 0, 3, 1 }, ignoreOrder: true);
    }
}
