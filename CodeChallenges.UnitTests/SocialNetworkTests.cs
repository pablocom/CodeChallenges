using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public sealed class SocialNetworkTests
{
    private readonly SocialNetwork network = new();

    [Fact]
    public void InsightsAreDisplayed()
    {
        const int user = 12;
        const int insight = 69;
        
        network.ShareInsight(user, insight);

        var insightsInFeed = network.GetLastInsights(user);

        insightsInFeed.Should().Equal([insight]);
    }
    
    [Fact]
    public void InsightsAreDisplayedInDescendingOrderByTheTimeTheyWereShared()
    {
        const int user = 12;
        const int insight1 = 69;
        const int insight2 = 70;
        
        network.ShareInsight(user, insight1);
        network.ShareInsight(user, insight2);

        var insightsInFeed = network.GetLastInsights(user);

        insightsInFeed.Should().Equal([insight1, insight2]);
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
        
        network.AddConnection(user2, user1);
        
        network.ShareInsight(user1, insight1);
        network.ShareInsight(user2, insight2);
        network.ShareInsight(user1, insight3);
        network.ShareInsight(notConnectedUser, insight4);

        var insightsInFeed = network.GetLastInsights(user2);

        insightsInFeed.Should().Equal([insight1, insight2, insight3]);
    }
    
    [Fact]
    public void NoInsightsAreDisplayedIfUserDoesNotHaveAny()
    {
        const int user1 = 12;

        var insightsInFeed = network.GetLastInsights(user1);

        insightsInFeed.Should().BeEmpty();
    }
    
    [Fact]
    public void RemovesUserConnection()
    {
        const int user1 = 12;
        const int user2 = 13;
        const int insight1 = 69;
        const int insight2 = 70;
        const int insight3 = 71;
        
        network.AddConnection(user1, user2);
        network.ShareInsight(user1, insight1);
        network.ShareInsight(user2, insight2);
        network.ShareInsight(user1, insight3);
        network.RemoveConnection(user1, user2);

        var insights = network.GetLastInsights(user1);

        insights.Should().Equal([insight1, insight3]);
    }
}