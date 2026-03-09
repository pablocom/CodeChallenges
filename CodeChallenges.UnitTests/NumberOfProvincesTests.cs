using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class NumberOfProvincesTests
{
    [Fact]
    public void TwoProvinces()
    {
        var isConnected = new[]
        {
            new[] { 1, 1, 0 },
            new[] { 1, 1, 0 },
            new[] { 0, 0, 1 },
        };

        NumberOfProvinces.Solve(isConnected).Should().Be(2);
    }

    [Fact]
    public void ThreeProvinces()
    {
        var isConnected = new[]
        {
            new[] { 1, 0, 0 },
            new[] { 0, 1, 0 },
            new[] { 0, 0, 1 },
        };

        NumberOfProvinces.Solve(isConnected).Should().Be(3);
    }

    [Fact]
    public void SingleProvince()
    {
        var isConnected = new[]
        {
            new[] { 1, 1, 1 },
            new[] { 1, 1, 1 },
            new[] { 1, 1, 1 },
        };

        NumberOfProvinces.Solve(isConnected).Should().Be(1);
    }

    [Fact]
    public void SingleCity()
    {
        var isConnected = new[]
        {
            new[] { 1 },
        };

        NumberOfProvinces.Solve(isConnected).Should().Be(1);
    }

    [Fact]
    public void TransitiveConnection()
    {
        var isConnected = new[]
        {
            new[] { 1, 1, 0, 0 },
            new[] { 1, 1, 1, 0 },
            new[] { 0, 1, 1, 0 },
            new[] { 0, 0, 0, 1 },
        };

        NumberOfProvinces.Solve(isConnected).Should().Be(2);
    }
}
