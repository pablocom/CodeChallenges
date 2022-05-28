using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class LruCacheTests
{
        
    /**["LRUCache","put","put","get","put","get","put","get","get","get"]
            [[2],[1,1],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
        */
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var lru = new LRUCache(2);
            
        lru.Put(1, 1);
        lru.Put(2, 2);
            
        Assert.That(lru.Get(1), Is.EqualTo(1));
    }
        
    [Test]
    public void Test2()
    {
        var lru = new LRUCache(2);
            
        lru.Put(1, 1);
        lru.Put(2, 2);
        lru.Get(1);
        lru.Put(3, 3);
            
        Assert.That(lru.Get(2), Is.EqualTo(-1));
    }
        
    [Test]
    public void Test3()
    {
        var lru = new LRUCache(2);
            
        lru.Put(1, 1);
        lru.Put(2, 2);
        lru.Get(1);
        lru.Put(3, 3);
        lru.Get(2);
        lru.Put(4, 4);
            
        Assert.That(lru.Get(1), Is.EqualTo(-1));
        Assert.That(lru.Get(3), Is.EqualTo(3));
        Assert.That(lru.Get(4), Is.EqualTo(4));
    }
}