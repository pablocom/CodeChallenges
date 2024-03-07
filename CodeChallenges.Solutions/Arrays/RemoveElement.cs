namespace CodeChallenges.Solutions.Arrays;

public class RemoveElements
{
    public int RemoveElement(int[] nums, int val) {
        var positionToPlaceNonMatchingElements = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[positionToPlaceNonMatchingElements] = nums[i];
                positionToPlaceNonMatchingElements++;
            }
        }

        return positionToPlaceNonMatchingElements;
    }
}