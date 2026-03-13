using CodeChallenges.Solutions.Mathematics;

namespace CodeChallenges.UnitTests.Math;

public class VectorSimilarityTests
{
    [Fact]
    public void EmptyVectors_ReturnZero()
    {
        var result = SparseVectorsSimilarity.SolveOptimized([], [], [], []);

        result.ShouldBe(0);
    }

    [Fact]
    public void IdenticalSingleEntry_ReturnsOne()
    {
        var result = SparseVectorsSimilarity.SolveOptimized(
            [42], [3.5],
            [42], [7.2]
        );

        result.ShouldBe(1);
    }

    [Fact]
    public void OppositeSingleEntry_ReturnsMinusOne()
    {
        var result = SparseVectorsSimilarity.SolveOptimized(
            [7], [2.0],
            [7], [-5.0]
        );

        result.ShouldBe(-1);
    }
    
    [Fact]
    public void DisjointIndicesReturnsZero()
    {
        var result = SparseVectorsSimilarity.SolveOptimized(
            [1, 3, 5], [2, 4, 6],
            [2, 4, 6], [1, 1, 1]
        );

        result.ShouldBe(0);
    }
    
    [Fact]
    public void MultipleMatchesMixedSigns()
    {
        var result = SparseVectorsSimilarity.SolveOptimized(
            [2, 4, 5, 8], [7, 5, 12, 1],
            [1, 2, 5, 8], [3, 4, -1, 2]
        );
        
        var expected = (7 * 4 + 12 * -1 + 1 * 2) /
                       (System.Math.Sqrt(7 * 7 + 5 * 5 + 12 * 12 + 1 * 1) *
                        System.Math.Sqrt(3 * 3 + 4 * 4 + 1 * 1 + 2 * 2));

        result.ShouldBe(expected);
    }
    
    [Fact]
    public void BigIndicesTwoMatches()
    {
        var result = SparseVectorsSimilarity.SolveOptimized(
            [736565921, 2014363605], [871.250834721723, 693.657922881496],
            [736565921, 2014363605], [160.05272192883, 758.489622156364]
        );

        var dot = 871.250834721723 * 160.05272192883 +
                  693.657922881496 * 758.489622156364;
        var normA = System.Math.Sqrt(
            871.250834721723 * 871.250834721723 +
            693.657922881496 * 693.657922881496);
        var normB = System.Math.Sqrt(
            160.05272192883 * 160.05272192883 +
            758.489622156364 * 758.489622156364);
        var expected = dot / (normA * normB);

        result.ShouldBe(expected, 1e-12);
    }
    
    
    [Fact]
    public void TheScenario()
    {
        var result = SparseVectorsSimilarity.SolveOptimized(
            [736565921, 2014363605], [871.250834721723, 693.657922881496],
            [736565921, 2014363605], [160.05272192883, 758.489622156364]
        );

        result.ShouldBe(0.770969008850541, 1e-15);
    }
}

