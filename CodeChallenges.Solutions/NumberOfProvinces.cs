namespace CodeChallenges.Solutions;

public static class NumberOfProvinces
{
    public static int Solve(int[][] isConnected)
    {
        var provinces = 0;
        var visited = new HashSet<int>(isConnected.Length);

        for (var i = 0; i < isConnected.Length; i++)
        {
            if (visited.Contains(i))
                continue;
            
            TraverseConnections(i, isConnected, visited);
            provinces++;
        }
        
        return provinces;
    }

    private static void TraverseConnections(int i, int[][] isConnected, HashSet<int> visited)
    {
        visited.Add(i);

        for (var j = 0; j < isConnected[i].Length; j++)
        {
            if (i == j || visited.Contains(j))
                continue;

            if (isConnected[i][j] is 1)
                TraverseConnections(j, isConnected, visited);
        }
    }
}