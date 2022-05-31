namespace CodeChallenges.Solutions;

// Description link: https://leetcode.com/problems/product-of-array-except-self/
public class ProductOfArrayExceptItself
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var accumulatedProductsLeftToRight = new int[nums.Length];
        accumulatedProductsLeftToRight[0] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            accumulatedProductsLeftToRight[i] = accumulatedProductsLeftToRight[i - 1] * nums[i];
        }

        var accumulatedProductsRightToLeft = new int[nums.Length];
        accumulatedProductsRightToLeft[nums.Length - 1] = nums[nums.Length - 1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            accumulatedProductsRightToLeft[i] = accumulatedProductsRightToLeft[i + 1] * nums[i];
        }

        nums[0] = accumulatedProductsRightToLeft[1];
        nums[nums.Length - 1] = accumulatedProductsLeftToRight[nums.Length - 2];

        for (int i = 1; i < nums.Length - 1; i++)
        {
            nums[i] = accumulatedProductsLeftToRight[i - 1] * accumulatedProductsRightToLeft[i + 1];
        }

        return nums;
    }
}
