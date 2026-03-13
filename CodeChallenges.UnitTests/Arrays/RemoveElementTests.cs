using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class RemoveElementTests
{
    [Fact]
    public void EmptyArray_ReturnsZero()
    {
        var nums = Array.Empty<int>();

        var result = new RemoveElements().RemoveElement(nums, 3);

        result.ShouldBe(0);
    }

    [Fact]
    public void SingleElement_MatchingVal_ReturnsZero()
    {
        var nums = new[] { 3 };

        var result = new RemoveElements().RemoveElement(nums, 3);

        result.ShouldBe(0);
    }

    [Fact]
    public void SingleElement_NotMatchingVal_ReturnsOne()
    {
        var nums = new[] { 5 };

        var result = new RemoveElements().RemoveElement(nums, 3);

        result.ShouldBe(1);
        nums[0].ShouldBe(5);
    }

    [Fact]
    public void AllElementsMatchVal_ReturnsZero()
    {
        var nums = new[] { 2, 2, 2, 2 };

        var result = new RemoveElements().RemoveElement(nums, 2);

        result.ShouldBe(0);
    }

    [Fact]
    public void NoElementsMatchVal_ReturnsOriginalLength()
    {
        var nums = new[] { 1, 2, 3, 4 };

        var result = new RemoveElements().RemoveElement(nums, 5);

        result.ShouldBe(4);
        nums[0].ShouldBe(1);
        nums[1].ShouldBe(2);
        nums[2].ShouldBe(3);
        nums[3].ShouldBe(4);
    }

    [Fact]
    public void LeetCodeExample1_RemovesAllTwos()
    {
        var nums = new[] { 3, 2, 2, 3 };

        var result = new RemoveElements().RemoveElement(nums, 3);

        result.ShouldBe(2);
        var remaining = nums.Take(result).Order().ToArray();
        remaining.ShouldBe(new[] { 2, 2 });
    }

    [Fact]
    public void LeetCodeExample2_RemovesAllTwos()
    {
        var nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 };

        var result = new RemoveElements().RemoveElement(nums, 2);

        result.ShouldBe(5);
        var remaining = nums.Take(result).Order().ToArray();
        remaining.ShouldBe(new[] { 0, 0, 1, 3, 4 });
    }

    [Fact]
    public void MixedElements_VerifiesLengthAndFirstKElements()
    {
        var nums = new[] { 4, 1, 4, 2, 4, 3 };

        var result = new RemoveElements().RemoveElement(nums, 4);

        result.ShouldBe(3);
        var remaining = nums.Take(result).Order().ToArray();
        remaining.ShouldBe(new[] { 1, 2, 3 });
    }

    [Fact]
    public void DuplicatesOfValScatteredThroughout_RemovesAll()
    {
        var nums = new[] { 1, 7, 3, 7, 5, 7, 7, 9 };

        var result = new RemoveElements().RemoveElement(nums, 7);

        result.ShouldBe(4);
        var remaining = nums.Take(result).Order().ToArray();
        remaining.ShouldBe(new[] { 1, 3, 5, 9 });
    }

    [Fact]
    public void ValAtBeginning_RemovesCorrectly()
    {
        var nums = new[] { 5, 5, 1, 2, 3 };

        var result = new RemoveElements().RemoveElement(nums, 5);

        result.ShouldBe(3);
        var remaining = nums.Take(result).Order().ToArray();
        remaining.ShouldBe(new[] { 1, 2, 3 });
    }

    [Fact]
    public void ValAtEnd_RemovesCorrectly()
    {
        var nums = new[] { 1, 2, 3, 5, 5 };

        var result = new RemoveElements().RemoveElement(nums, 5);

        result.ShouldBe(3);
        nums[0].ShouldBe(1);
        nums[1].ShouldBe(2);
        nums[2].ShouldBe(3);
    }

    [Fact]
    public void TwoElements_BothMatch_ReturnsZero()
    {
        var nums = new[] { 1, 1 };

        var result = new RemoveElements().RemoveElement(nums, 1);

        result.ShouldBe(0);
    }

    [Fact]
    public void TwoElements_NoneMatch_ReturnsTwo()
    {
        var nums = new[] { 1, 2 };

        var result = new RemoveElements().RemoveElement(nums, 3);

        result.ShouldBe(2);
        nums[0].ShouldBe(1);
        nums[1].ShouldBe(2);
    }
}
