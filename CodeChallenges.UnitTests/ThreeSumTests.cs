using CodeChallenges.Solutions;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace CodeChallenges.UnitTests;

public class ThreeSumTests
{
    [Test]
    public void Test1()
    {
        var inputArray = new[] { -1, 0, 1, 2, -1, -4 };

        IList<IList<int>> solution = new ThreeSum().Solve(inputArray);

        CollectionAssert.AreEquivalent(
            new List<int[]>() { new[] { -1, -1, 2 },new[] { -1, 0, 1 }},
            solution
        );
    }
}
