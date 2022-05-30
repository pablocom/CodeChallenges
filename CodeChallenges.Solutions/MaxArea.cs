using System;

namespace CodeChallenges.Solutions;

public class MaxArea
{
    public int Solve(int[] heights)
    {
        var highestVolume = 0;
        var left = 0;
        var right = heights.Length - 1;

        while (left < right)
        {
            var volume = CalculateVolume(heights, left, right);
            highestVolume = Math.Max(highestVolume, volume);

            if (heights[left] < heights[right])
                left++;
            else
                right--;
        }

        return highestVolume;
    }

    private static int CalculateVolume(int[] heights, int left, int right)
    {
        return (right - left) * Math.Min(heights[left], heights[right]);
    }
}