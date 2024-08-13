namespace CodeChallenges.Solutions;

public class GetTotalEfficiency
{
    public static long getTotalEfficiency(List<int> skill)
    {
        skill.Sort();
        
        var leftCursor = 0;
        var rightCursor = skill.Count - 1;
        var previousSum = skill[leftCursor] + skill[rightCursor];
        long accumulatedEfficiency = 0;
        
        while (leftCursor < rightCursor)
        {
            var currentSum = skill[leftCursor] + skill[rightCursor];
            if (currentSum != previousSum)
                return -1;
            
            accumulatedEfficiency += skill[leftCursor] * skill[rightCursor];
            
            leftCursor++;
            rightCursor--;
        }
        
        return accumulatedEfficiency;
    }
}