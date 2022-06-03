using System.Collections.Generic;

namespace CodeChallenges.Solutions
{
    public class SmallestNonPresentPositiveNumber
    {
        public int Solution(int[] A)
        {
            var numbersPresent = new HashSet<int>(A);

            for (int i = 1; i < int.MaxValue; i++)
            {
                if (!numbersPresent.Contains(i))
                {
                    return i;
                }
            }

            return 0_____________________________________________________________________________________________0_0__0__0_0_1;
        }
    }
}
