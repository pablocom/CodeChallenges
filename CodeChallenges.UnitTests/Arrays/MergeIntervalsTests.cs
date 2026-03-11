using CodeChallenges.Solutions.Arrays;

namespace CodeChallenges.UnitTests.Arrays;

public class MergeIntervalsTests
{
    [Fact]
    public void Merges_Overlapping_Intervals()
    {
        var intervals = new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(3);
        result[0].Should().BeEquivalentTo(new[] { 1, 6 });
        result[1].Should().BeEquivalentTo(new[] { 8, 10 });
        result[2].Should().BeEquivalentTo(new[] { 15, 18 });
    }

    [Fact]
    public void Merges_Intervals_Touching_At_Boundary()
    {
        var intervals = new[] { new[] { 1, 4 }, new[] { 4, 5 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo(new[] { 1, 5 });
    }

    [Fact]
    public void Single_Interval_Returns_As_Is()
    {
        var intervals = new[] { new[] { 5, 10 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo(new[] { 5, 10 });
    }

    [Fact]
    public void No_Overlapping_Intervals_Returns_All()
    {
        var intervals = new[] { new[] { 1, 2 }, new[] { 4, 6 }, new[] { 8, 10 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(3);
        result[0].Should().BeEquivalentTo(new[] { 1, 2 });
        result[1].Should().BeEquivalentTo(new[] { 4, 6 });
        result[2].Should().BeEquivalentTo(new[] { 8, 10 });
    }

    [Fact]
    public void All_Intervals_Overlap_Into_One()
    {
        var intervals = new[] { new[] { 1, 4 }, new[] { 2, 6 }, new[] { 3, 8 }, new[] { 5, 10 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo(new[] { 1, 10 });
    }

    [Fact]
    public void Nested_Interval_Is_Absorbed()
    {
        var intervals = new[] { new[] { 1, 10 }, new[] { 2, 5 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo(new[] { 1, 10 });
    }

    [Fact]
    public void Unsorted_Input_Is_Handled_Correctly()
    {
        var intervals = new[] { new[] { 8, 10 }, new[] { 1, 3 }, new[] { 15, 18 }, new[] { 2, 6 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(3);
        result[0].Should().BeEquivalentTo(new[] { 1, 6 });
        result[1].Should().BeEquivalentTo(new[] { 8, 10 });
        result[2].Should().BeEquivalentTo(new[] { 15, 18 });
    }

    [Fact]
    public void Larger_Interval_Contains_Smaller_One()
    {
        var intervals = new[] { new[] { 1, 6 }, new[] { 2, 3 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(1);
        result[0].Should().BeEquivalentTo(new[] { 1, 6 });
    }

    [Fact]
    public void Adjacent_Non_Overlapping_Intervals_Stay_Separate()
    {
        var intervals = new[] { new[] { 1, 3 }, new[] { 5, 7 } };

        var result = MergeIntervals.Solve(intervals);

        result.Should().HaveCount(2);
        result[0].Should().BeEquivalentTo(new[] { 1, 3 });
        result[1].Should().BeEquivalentTo(new[] { 5, 7 });
    }
}
