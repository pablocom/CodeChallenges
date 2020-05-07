using System.Collections.Generic;
using System.Linq;

namespace TopKFrecuentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = new[] {1, 1, 1, 2, 2, 3};
        }

        public static class Solution
        {
            public static int[] TopKFrequent(int[] nums, int k)
            {
                var appearanceNumber = new Dictionary<int, int>();

                foreach (var number in nums.ToHashSet())
                {
                    appearanceNumber.Add(number, nums.Count(x => x == number));
                    nums = nums.Where(x => x != number).ToArray();
                }

                return appearanceNumber.OrderByDescending(x => x.Value)
                        .Take(k)
                        .Select(x => x.Key)
                        .ToArray();
            }
        }
    }
}
