namespace CodeChallenges.Solutions;

public sealed class SocialNetwork
{
    private readonly List<int> _insights = new();
    private readonly Dictionary<int, List<int>> _insightsByUserId = new();
    private readonly Dictionary<int, HashSet<int>> _connectionsByUserId = new();

    public void ShareInsight(int userId, int insightId)
    {
        if (_insightsByUserId.TryGetValue(userId, out var insights))
            insights.Add(insightId);
        else
            _insightsByUserId.Add(userId, [insightId]);

        _insights.Add(insightId);
    }

    public IEnumerable<int> GetLastInsights(int userId)
    {
        const int maxInsightsToDisplay = 10;
        
        var connectedUserIds = GetConnectedUserIds(userId);
        var insightIdsOfConnectedUsers = GetInsightsOfUsers(connectedUserIds);

        var result = new List<int>(maxInsightsToDisplay);
        
        foreach (var insight in _insights)
        {
            if (!insightIdsOfConnectedUsers.Contains(insight)) 
                continue;
            
            result.Add(insight);
                
            if (result.Count == result.Capacity)
                break;
        }
        
        return result;
    }

    public void AddConnection(int followerUserId, int followedUserId)
    {
        if (_connectionsByUserId.TryGetValue(followerUserId, out var connections))
            connections.Add(followedUserId);
        else
            _connectionsByUserId.Add(followerUserId, [followedUserId]);
    }

    public void RemoveConnection(int followerUserId, int unfollowedUserId)
    {
        if (_connectionsByUserId.TryGetValue(followerUserId, out var connections))
            connections.Remove(unfollowedUserId);
    }

    private HashSet<int> GetConnectedUserIds(int userId)
    {
        var usersToVisit = new Stack<int>();
        var visitedUsers = new HashSet<int>();
        
        usersToVisit.Push(userId);

        while (usersToVisit.Count > 0)
        {
            var user = usersToVisit.Pop();
            
            if (visitedUsers.Contains(user))
                continue;

            visitedUsers.Add(user);

            if (!_connectionsByUserId.TryGetValue(user, out var connections)) 
                continue;
            
            foreach (var connection in connections) 
                usersToVisit.Push(connection);
        }

        return visitedUsers;
    }

    private HashSet<int> GetInsightsOfUsers(IEnumerable<int> userIds)
    {
        var result = new HashSet<int>();
        
        foreach (var userId in userIds)
        {
            if (!_insightsByUserId.TryGetValue(userId, out var insightsIds))
                continue;
            
            foreach (var insightId in insightsIds) 
                result.Add(insightId);
        }

        return result;
    }
}