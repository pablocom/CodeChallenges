namespace CodeChallenges.Solutions.Searching;

public static class BinarySearch<T> where T : IComparable<T>
{
    public static int FindFirst(T[] orderedArray, T valueToFind)
    {
        var lowCursor = 0;
        var highCursor = orderedArray.Length - 1;

        while (lowCursor < highCursor)
        {
            var middlePoint = lowCursor + (highCursor - lowCursor) / 2;

            if (orderedArray[middlePoint].CompareTo(valueToFind) is 0)
                return middlePoint;

            if (orderedArray[middlePoint].CompareTo(valueToFind) < 0)
                lowCursor = middlePoint + 1;
            else
                highCursor = middlePoint - 1;
        }
        
        return -1;
    }
}