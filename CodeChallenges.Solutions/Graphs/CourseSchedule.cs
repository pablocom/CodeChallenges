namespace CodeChallenges.Solutions.Graphs;

public static class CourseSchedule
{
    public static bool Solve(int numCourses, int[][] prerequisites)
    {
        var adjacencyList = new Dictionary<int, List<int>>();
        for (var i = 0; i < numCourses; i++) 
            adjacencyList.Add(i, []);

        foreach (var prerequisite in prerequisites)
        {
            var course = prerequisite[0];
            var dependsOn = prerequisite[1];
            
            adjacencyList[course].Add(dependsOn);
        }

        var visiting = new HashSet<int>(numCourses);
        var visited = new HashSet<int>(numCourses);
        var currentCourse = 0;
        
        while (currentCourse < numCourses && visited.Count < numCourses)
        {
            var detectedCycle = TraverseGraph(currentCourse, adjacencyList, visited, visiting);
            if (detectedCycle)
                return false;
            
            visiting.Clear();
            currentCourse++;
        }
        
        return true;
    }

    private static bool TraverseGraph(int currentCourse, Dictionary<int, List<int>> adjacencyList, HashSet<int> visited, HashSet<int> visiting)
    {
        if (visited.Contains(currentCourse))
            return false;

        var detectedCycle = !visiting.Add(currentCourse);
        if (detectedCycle)
            return true;

        foreach (var adjacent in adjacencyList[currentCourse])
        {
            if (TraverseGraph(adjacent, adjacencyList, visited, visiting))
                return true;
        }

        visited.Add(currentCourse);
        return false;
    }
}