using TaskScheduler = CodeChallenges.Solutions.DataStructures.TaskScheduler;

namespace CodeChallenges.UnitTests.DataStructures;

public class TaskSchedulerTests
{
    [Theory]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B' },          2, 8)]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B' },          0, 6)]
    [InlineData(new[] { 'A', 'A', 'A', 'A', 'A', 'A',
                        'B', 'C', 'D', 'E', 'F', 'G' },          2, 16)]
    [InlineData(new[] { 'A' },                                     2, 1)]
    [InlineData(new[] { 'A', 'B' },                                2, 2)]
    [InlineData(new[] { 'A', 'A' },                                1, 3)]
    [InlineData(new[] { 'A', 'A' },                                2, 4)]
    [InlineData(new[] { 'A', 'A', 'A' },                           2, 7)]
    [InlineData(new[] { 'A', 'B', 'C', 'D' },                     2, 4)]
    [InlineData(new[] { 'A', 'A', 'B', 'B', 'C', 'C' },          2, 6)]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B',
                        'C', 'C', 'C' },                          2, 9)]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B',
                        'C', 'C', 'C', 'D', 'D', 'E' },          2, 12)]
    public void Solve(char[] tasks, int n, int expected) =>
        TaskScheduler.Solve(tasks, n).Should().Be(expected);

    [Theory]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B' },          2, 8)]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B' },          0, 6)]
    [InlineData(new[] { 'A', 'A', 'A', 'A', 'A', 'A',
                        'B', 'C', 'D', 'E', 'F', 'G' },          2, 16)]
    [InlineData(new[] { 'A' },                                     2, 1)]
    [InlineData(new[] { 'A', 'B' },                                2, 2)]
    [InlineData(new[] { 'A', 'A' },                                1, 3)]
    [InlineData(new[] { 'A', 'A' },                                2, 4)]
    [InlineData(new[] { 'A', 'A', 'A' },                           2, 7)]
    [InlineData(new[] { 'A', 'B', 'C', 'D' },                     2, 4)]
    [InlineData(new[] { 'A', 'A', 'B', 'B', 'C', 'C' },          2, 6)]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B',
                        'C', 'C', 'C' },                          2, 9)]
    [InlineData(new[] { 'A', 'A', 'A', 'B', 'B', 'B',
                        'C', 'C', 'C', 'D', 'D', 'E' },          2, 12)]
    public void SolveWithFormula(char[] tasks, int n, int expected) =>
        TaskScheduler.SolveWithFormula(tasks, n).Should().Be(expected);
}
