namespace CodeChallenges.Solutions;

public class PeakFinder
{
    public static int CountPeaks(List<double> values) 
    {
        if (values.Count <= 2)
        {
            return 0;
        }

        var totalPeaks = 0;
        var previousWasPeak = false;

        for (var i = 1; i < values.Count; i++) 
        {
            if (previousWasPeak)
            {
                previousWasPeak = false;
                continue;
            }

            var previousValue = values[i - 1];
            var currentValue = values[i];

            if (Math.Abs(currentValue - previousValue) >= 5)
            {
                totalPeaks++;
                previousWasPeak = true;
            }
        }

        return totalPeaks;
    }
}