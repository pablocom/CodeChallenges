using System;

namespace CodeChallenges.Solutions;

// Description link: https://leetcode.com/problems/product-of-array-except-self/
public class ProductOfArrayExceptItself
{
    public int[] ProductExceptSelf(int[] nums)
    {
        var accumulatedProductsLeftToRight = new int[nums.Length];
        accumulatedProductsLeftToRight[0] = nums[0];
        var accumulatedProductsIterator = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            accumulatedProductsLeftToRight[accumulatedProductsIterator] = accumulatedProductsLeftToRight[i - 1] * nums[i];
            accumulatedProductsIterator++;
        }

        var accumulatedProductsRightToLeft = new int[nums.Length];
        accumulatedProductsRightToLeft[nums.Length - 1] = nums[nums.Length - 1];
        accumulatedProductsIterator = nums.Length - 2;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            accumulatedProductsRightToLeft[accumulatedProductsIterator] = accumulatedProductsRightToLeft[i + 1] * nums[i];
            accumulatedProductsIterator--;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                nums[i] = accumulatedProductsRightToLeft[i + 1];
                continue;
            }
            if (i == nums.Length - 1)
            {
                nums[i] = accumulatedProductsLeftToRight[i - 1];
                continue;
            }

            nums[i] = accumulatedProductsLeftToRight[i - 1] * accumulatedProductsRightToLeft[i + 1];
        }

        return nums;
    }
}
