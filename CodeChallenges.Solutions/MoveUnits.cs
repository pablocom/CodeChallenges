namespace CodeChallenges.Solutions;

public static class MoveUnits
{
    public static int Solve(List<int> population, string unit)
    {
        var maxPopulation = SumProtectedPopulation(unit, population);

        for (var i = 1; i < unit.Length; i++)
        {
            if (unit[i] is not '1' || unit[i - 1] is not '0')
                continue;

            var minPop = population[i];
            for (var j = i + 1; j < unit.Length && unit[j] is '1'; j++)
                minPop = Math.Min(minPop, population[j]);

            var gain = population[i - 1] - minPop;
            if (gain > 0)
                maxPopulation += gain;
        }

        return maxPopulation;
    }

    private static int SumProtectedPopulation(string units, List<int> population)
    {
        var currentProtectedPopulation = 0;

        for (var i = 0; i < units.Length; i++)
        {
            if (units[i] is not '1')
                continue;

            currentProtectedPopulation += population[i];
        }

        return currentProtectedPopulation;
    }
}
