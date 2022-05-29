using System.Linq;

namespace CodeChallenges.Solutions;

public class FindMedianSortedArrays 
{
    public double Solve(int[] nums1, int[] nums2)
    {
        if (!nums2.Any())
        {
            var middlePosition = nums1.Length / 2;
            if (nums1.Length % 2 == 0)
            {
                return (double)(nums1[middlePosition - 1] + nums1[middlePosition]) / 2;
            }
            
            return nums1[middlePosition];
        }
        
        if (!nums1.Any())
        {
            var middlePosition = nums2.Length / 2;
            if (nums2.Length % 2 == 0)
            {
                return (double)(nums2[middlePosition - 1] + nums2[middlePosition]) / 2;
            }
            
            return nums2[middlePosition];
        }
        
        var numbersAtLeftOfMedianCount = 0;
        var numbersAtRightOfMedianCount = nums1.Length + nums2.Length;

        var lastIterationWasInOne = false;
        int iteratorOne = 0, iteratorTwo = 0;
        while (numbersAtLeftOfMedianCount < numbersAtRightOfMedianCount)
        {
            numbersAtLeftOfMedianCount++;
            numbersAtRightOfMedianCount--;
            
            if (iteratorTwo == nums2.Length || (iteratorOne != nums1.Length && nums1[iteratorOne] <= nums2[iteratorTwo]))
            {
                iteratorOne++;
                lastIterationWasInOne = true;
                continue;
            }

            iteratorTwo++;
            lastIterationWasInOne = false;
        }

        if (MergedArraysCountIsEven(nums1, nums2))
        {
            if (lastIterationWasInOne)
            {
                var isAtLastPositionOfArray = iteratorOne == nums1.Length;
                if (isAtLastPositionOfArray)
                    return (double)(nums1[iteratorOne - 1] + nums2[iteratorTwo]) / 2;
                
                if (iteratorTwo == nums2.Length)
                    return (double)(nums1[iteratorOne - 1] + nums1[iteratorOne]) / 2;
                
                var nextOnOne = nums1[iteratorOne];
                if (nextOnOne >= nums2[iteratorTwo])
                {
                    return (double)(nums1[iteratorOne - 1] + nums2[iteratorTwo]) / 2;
                }
            }
            else
            {
                var isAtLastPositionOfArray = iteratorTwo == nums2.Length;
                if (isAtLastPositionOfArray)
                    return (double)(nums2[iteratorTwo - 1] + nums1[iteratorOne]) / 2;
                
                if (iteratorOne >= nums1.Length)
                    return (double)(nums2[iteratorTwo - 1] + nums2[iteratorTwo]) / 2;
                
                var nextOnTwo = nums2[iteratorTwo];
                if (nextOnTwo >= nums1[iteratorOne])
                {
                    return (double)(nums2[iteratorTwo - 1] + nums1[iteratorOne]) / 2;
                }
            }
        }

        if (lastIterationWasInOne)
        {
            if (MergedArraysCountIsEven(nums1, nums2))
                return (double)(nums1[iteratorOne - 1] + nums1[iteratorOne]) / 2;
            
            return nums1[iteratorOne - 1];
        }
        
        if (MergedArraysCountIsEven(nums1, nums2))
            return (double)(nums2[iteratorTwo - 1] + nums2[iteratorTwo]) / 2;
        
        return nums2[iteratorTwo - 1];
    }

    private static bool MergedArraysCountIsEven(int[] nums1, int[] nums2)
    {
        return (nums1.Length + nums2.Length) % 2 == 0;
    }
}