namespace CodeChallenges.Solutions.Mathematics;

public static class GrayCode
{
    public static IList<int> Solve(int n)
    {
        var result = new List<int> { 0 };
        
        for (var i = 0; i < n; i++) {
            var addition = 1 << i;
            
            for (var j = result.Count - 1; j >= 0; j--) {
                result.Add(result[j] + addition);
            }
        }
        
        return result;
    }
}