namespace CodeChallenges.Solutions.Arrays;

public static class TwoSum
{
    public static int[] Solve(int[] nums, int target)
    {
        var positionsByNumber = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];

            if (positionsByNumber.TryGetValue(complement, out var index))
                return [index, i];

            positionsByNumber[nums[i]] = i;
        }

        throw new InvalidOperationException();
    }
}

public interface ITwoSumStrategy
{
    void Add(int number);
    int[] Find(int target);
}

public class WriteHeavyTwoSumStrategy : ITwoSumStrategy
{
    private readonly Dictionary<int, List<int>> _indicesByNumber = new();
    private int _nextIndex;

    public void Add(int number)
    {
        if (!_indicesByNumber.TryGetValue(number, out var indices))
        {
            indices = [];
            _indicesByNumber[number] = indices;
        }

        indices.Add(_nextIndex++);
    }

    public int[] Find(int target)
    {
        foreach (var (number, indices) in _indicesByNumber)
        {
            var complement = target - number;

            if (complement == number)
            {
                if (indices.Count > 1)
                    return [indices[0], indices[1]];
            }
            else if (_indicesByNumber.TryGetValue(complement, out var complementIndices))
            {
                return [System.Math.Min(indices[0], complementIndices[0]), System.Math.Max(indices[0], complementIndices[0])];
            }
        }

        throw new InvalidOperationException();
    }
}

public class ReadHeavyTwoSumStrategy : ITwoSumStrategy
{
    private readonly List<int> _numbers = [];
    private readonly Dictionary<int, int[]> _pairBySum = new();

    public void Add(int number)
    {
        for (var i = 0; i < _numbers.Count; i++)
        {
            var sum = _numbers[i] + number;
            _pairBySum.TryAdd(sum, [i, _numbers.Count]);
        }

        _numbers.Add(number);
    }

    public int[] Find(int target) =>
        _pairBySum.TryGetValue(target, out var pair)
            ? pair
            : throw new InvalidOperationException();
}
