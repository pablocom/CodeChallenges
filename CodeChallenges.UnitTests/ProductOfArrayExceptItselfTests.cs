using CodeChallenges.Solutions;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CodeChallenges.UnitTests
{
    public class ProductOfArrayExceptItselfTests
    {
        [Test]
        public void Test1()
        {
            var nums = new int[] { 1, 2, 3, 4 };

            var solution = new ProductOfArrayExceptItself().ProductExceptSelf(nums);

            CollectionAssert.AreEquivalent(new int[] { 24, 12, 8, 6 }, solution);
        }
    }
}
