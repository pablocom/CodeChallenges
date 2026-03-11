namespace CodeChallenges.Solutions.Graphs;

public static class CourseSchedule2
{
    public static int[] Solve(int courses, int[][] prerequisites)
    {
        var coursePrerequisites = Enumerable.Range(0, courses)
            .Select(x => new KeyValuePair<int, List<int>>(x, []))
            .ToDictionary();

        Span<int> span = stackalloc int[123];
        
        
        foreach (var entry in prerequisites)
        {
            var course = entry[0];
            var pre = entry[1];
            
            coursePrerequisites[course].Add(pre);
        }

        var visit = new HashSet<int>();
        var cycle = new HashSet<int>();
        var result = new List<int>(courses);
        
        for (var i = 0; i < courses; i++)
        {
            if (visit.Contains(i))
                continue;

            var hasDetectedCycle = TraverseCourses(result, visit, cycle, coursePrerequisites, i);
            if (hasDetectedCycle)
                return [];
        }
        
        return result.ToArray();
    }

    private static bool TraverseCourses(
        List<int> result,
        HashSet<int> visit, 
        HashSet<int> cycle, 
        Dictionary<int, List<int>> coursePrerequisites,
        int course)
    {
        if (cycle.Contains(course))
            return true;
        if (visit.Contains(course))
            return false;

        cycle.Add(course);

        foreach (var pre in coursePrerequisites[course])
            if (TraverseCourses(result, visit, cycle, coursePrerequisites, pre))
                return true;

        cycle.Remove(course);
        visit.Add(course);
        result.Add(course);
        
        return false;
    }
}