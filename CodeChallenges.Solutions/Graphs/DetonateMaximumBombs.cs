namespace CodeChallenges.Solutions.Graphs;

public static class DetonateMaximumBombs
{
    public static int Solve(int[][] bombs)
    {
        var adjacencyList = new Dictionary<int, List<int>>(bombs.Length);
        for (var i = 0; i < bombs.Length; i++) 
            adjacencyList[i] = [];

        for (var i = 0; i < bombs.Length; i++)
        for (var j = i + 1; j < bombs.Length; j++)
        {
            var (x1, y1, radius1) = (bombs[i][0], bombs[i][1], bombs[i][2]);
            var (x2, y2, radius2) = (bombs[j][0], bombs[j][1], bombs[j][2]);

            var distance = EuclideanDistance((x1, y1), (x2, y2));

            if (distance <= radius1)
                adjacencyList[i].Add(j);
            
            if (distance <= radius2)
                adjacencyList[j].Add(i);
        }

        var result = 0;
        var visitedInPath = new HashSet<int>(bombs.Length);
        
        for (var i = 0; i < bombs.Length; i++)
        {
            visitedInPath.Clear(); 
            TraverseExplosionFrom(i, visitedInPath, adjacencyList);
            result = Math.Max(result, visitedInPath.Count); 
        }
        
        return result;
    }

    private static void TraverseExplosionFrom(int id, HashSet<int> visitedInPath, Dictionary<int, List<int>> adjacencyByNodeId)
    {
        if (!visitedInPath.Add(id))
            return; 
        
        foreach (var adjacent in adjacencyByNodeId[id]) 
            TraverseExplosionFrom(adjacent, visitedInPath, adjacencyByNodeId);
    }
    
    private static double EuclideanDistance((int X, int Y) a, (int X, int Y) b)
    {
        var xDistanceSquare = Math.Pow(b.X - a.X, 2);
        var yDistanceSquare = Math.Pow(b.Y - a.Y, 2);
        return Math.Sqrt(xDistanceSquare + yDistanceSquare);
    }
}
