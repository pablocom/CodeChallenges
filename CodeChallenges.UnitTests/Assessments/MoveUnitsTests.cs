using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests.Assessments;

public sealed class MoveUnitsTests
{
    public static TheoryData<List<int>, string, int> Scenarios => new()
    {
        { [10, 5, 8, 9, 6],                              "01101",      27 },
        { [20, 10, 9, 30, 20, 19],                       "011011",     80 },
        { [5, 4, 5, 1],                                  "0111",       14 },
        { [20, 10, 9, 30, 20, 19, 3, 42, 54, 66],       "0110110110", 176 },
    };

    [Theory, MemberData(nameof(Scenarios))]
    public void Solve(List<int> population, string unit, int expected) =>
        MoveUnits.Solve(population, unit).ShouldBe(expected);
}
