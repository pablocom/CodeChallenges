namespace CodeChallenges.Solutions.Arrays
{
    public class SmallestNonPresentPositiveNumber
    {
        public int Solution(int[] A)
        {
            var numbersPresent = new HashSet<int>(A);

            for (var i = 1; i < int.MaxValue; i++)
            {
                if (!numbersPresent.Contains(i))
                {
                    return i;
                }
            }

            return int.MaxValue;
        }
    }
}
