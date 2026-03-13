using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public sealed class SocialNetworkTests
{
    private readonly SocialNetwork _network = new();

    [Fact]
    public void InsightsAreDisplayed()
    {
        const int user = 12;
        const int insight = 69;
        
        _network.ShareInsight(user, insight);

        var insightsInFeed = _network.GetLastInsights(user);

        insightsInFeed.ShouldBe([insight]);
    }
    
    [Fact]
    public void InsightsAreDisplayedInDescendingOrderByTheTimeTheyWereShared()
    {
        const int user = 12;
        const int insight1 = 69;
        const int insight2 = 70;
        
        _network.ShareInsight(user, insight1);
        _network.ShareInsight(user, insight2);

        var insightsInFeed = _network.GetLastInsights(user);

        insightsInFeed.ShouldBe([insight1, insight2]);
    }
    
    [Fact]
    public void InsightsAreDisplayedForAllConnectedUsers()
    {
        const int user1 = 12;
        const int user2 = 13;
        const int notConnectedUser = 14;
        const int insight1 = 69;
        const int insight2 = 70;
        const int insight3 = 71;
        const int insight4 = 72;
        
        _network.AddConnection(user2, user1);
        
        _network.ShareInsight(user1, insight1);
        _network.ShareInsight(user2, insight2);
        _network.ShareInsight(user1, insight3);
        _network.ShareInsight(notConnectedUser, insight4);

        var insightsInFeed = _network.GetLastInsights(user2);

        insightsInFeed.ShouldBe([insight1, insight2, insight3]);
    }
    
    [Fact]
    public void NoInsightsAreDisplayedIfUserDoesNotHaveAny()
    {
        const int user1 = 12;

        var insightsInFeed = _network.GetLastInsights(user1);

        insightsInFeed.ShouldBeEmpty();
    }
    
    [Fact]
    public void RemovesUserConnection()
    {
        const int user1 = 12;
        const int user2 = 13;
        const int insight1 = 69;
        const int insight2 = 70;
        const int insight3 = 71;
        
        _network.AddConnection(user1, user2);
        _network.ShareInsight(user1, insight1);
        _network.ShareInsight(user2, insight2);
        _network.ShareInsight(user1, insight3);
        _network.RemoveConnection(user1, user2);

        var insights = _network.GetLastInsights(user1);

        insights.ShouldBe([insight1, insight3]);
    }
}