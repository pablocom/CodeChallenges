using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.UnitTests.DataStructures;

public class StackBasedQueueTests
{
    [Fact]
    public void EnqueueDequeue_FifoOrder()
    {
        var queue = new StackBasedQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        queue.Dequeue().ShouldBe(1);
        queue.Dequeue().ShouldBe(2);
        queue.Dequeue().ShouldBe(3);
    }

    [Fact]
    public void Peek_ReturnsFirstWithoutRemoving()
    {
        var queue = new StackBasedQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        queue.Peek().ShouldBe(10);
        queue.Peek().ShouldBe(10);
    }

    [Fact]
    public void InterleavedEnqueueAndDequeue()
    {
        var queue = new StackBasedQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue().ShouldBe(1);

        queue.Enqueue(3);
        queue.Dequeue().ShouldBe(2);
        queue.Dequeue().ShouldBe(3);
    }

    [Fact]
    public void SingleElement()
    {
        var queue = new StackBasedQueue<string>();
        queue.Enqueue("only");

        queue.Peek().ShouldBe("only");
        queue.Dequeue().ShouldBe("only");
    }

    [Fact]
    public void WorksWithStrings()
    {
        var queue = new StackBasedQueue<string>();
        queue.Enqueue("a");
        queue.Enqueue("b");

        queue.Dequeue().ShouldBe("a");
        queue.Dequeue().ShouldBe("b");
    }
}
