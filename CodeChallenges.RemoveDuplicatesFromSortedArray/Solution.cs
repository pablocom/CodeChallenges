namespace CodeChallenges.RemoveDuplicatesFromSortedArray
{
    public class Solution
    {
        public int RemoveDuplicates(int[] array)
        {
            if (array == null || array.Length == 0)
                return 0;
            
            var positionToAdd = 1;

            for (var i = 1; i < array.Length; i++)
            {
                if (array[i - 1] != array[i])
                    array[positionToAdd++] = array[i];
            }
            
            return positionToAdd;
        }
    }
}