namespace CodeChallenges.Solutions;

public class GenerateParentheses
{
    public IList<string> GenerateParenthesis(int n)
    {
        var result = new List<string>();
        int opened = 0; 
        int closed = 0;
        
        GenerateCombinations(n, "", opened, closed, result);
        
        return result;
    }

    private static void GenerateCombinations(int n, string parentheses, int opened, int closed, List<string> result)
    {
        if (opened == closed && opened == n)
        {
            result.Add(parentheses);
            return;
        }

        if (opened < n)
            GenerateCombinations(n, parentheses + '(', opened + 1, closed, result);
        
        if (closed < opened)
            GenerateCombinations(n, parentheses + ')', opened, closed + 1, result);
    }
}