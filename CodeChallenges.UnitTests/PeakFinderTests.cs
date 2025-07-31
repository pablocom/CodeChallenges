using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class PeakFinderTests
{
    [Fact]
    public void Example1()
    {
        var measures = new List<double> { 8, 10.7, 17.1, 11.2, 13.5, 9.9, 14.9, 9.4, 9.4, 3.1, 12.7 };

        var totalPeaks = PeakFinder.CountPeaks(measures);
        
        totalPeaks.Should().Be(3);
    }
}