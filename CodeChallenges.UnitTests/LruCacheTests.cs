using CodeChallenges.Solutions;

namespace CodeChallenges.UnitTests;

public class LruCacheTests
{
        
    /**["LRUCache","put","put","get","put","get","put","get","get","get"]
            [[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
        */

    [Fact]
    public void Test1()
    {
        var lru = new LRUCache(2);
            
        lru.Put(1, 1);
        lru.Put(2, 2);

        lru.Get(1).Should().Be(1);
    }
        
    [Fact]
    public void Test2()
    {
        var lru = new LRUCache(2);
            
        lru.Put(1, 1);
        lru.Put(2, 2);
        lru.Get(1);
        lru.Put(3, 3);
            
        lru.Get(2).Should().Be(-1);
    }
        
    [Fact]
    public void Test3()
    {
        var lru = new LRUCache(2);
            
        lru.Put(1, 1);
        lru.Put(2, 2);
        lru.Get(1);
        lru.Put(3, 3);
        lru.Get(2);
        lru.Put(4, 4);
            
        lru.Get(1).Should().Be(-1);
        lru.Get(3).Should().Be(3);
        lru.Get(4).Should().Be(4);
    }
}