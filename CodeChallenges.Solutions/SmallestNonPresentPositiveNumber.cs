using System.Collections.Generic;

namespace CodeChallenges.Solutions
{
    public class SmallestNonPresentPositiveNumber
    {
        public int Solution(int[] A)
        {
            var numbersPresent = new HashSet<int>();

            for (int i = 1; i < 1000000; i++)
            {
                if (!numbersPresent.Contains(i))
                {
                    return i;
                }
            }

            return 1000001;
        }
    }
}
