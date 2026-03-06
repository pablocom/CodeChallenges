using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.Solutions.Arrays;

public static class TopKFrequent
{
    public static int[] Solve(int[] nums, int k)
    {
        var occurrencesByNumber = new Dictionary<int, NumberAppearances>();

        foreach (var num in nums)
        {
            if (!occurrencesByNumber.TryAdd(num, new(num, 1)))
                occurrencesByNumber[num].Appearances++;
        }

        var numberAppearancesMaxHeap = new MaxHeap<NumberAppearances>(occurrencesByNumber.Values.ToArray());

        var result = new List<int>(k);

        for (var i = k; i > 0; i--) 
            result.Add(numberAppearancesMaxHeap.PopMax().Number);
        
        return result.ToArray();
    }
    
    private sealed class NumberAppearances : IComparable<NumberAppearances>
    {
        public int Number { get; }
        public int Appearances { get; set; }

        public NumberAppearances(int number, int appearances)
        {
            Number = number;
            Appearances = appearances;
        }

        public int CompareTo(NumberAppearances other) => Appearances.CompareTo(other.Appearances);

        public override int GetHashCode() => Number.GetHashCode();
    }
}