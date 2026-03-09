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

        queue.Dequeue().Should().Be(1);
        queue.Dequeue().Should().Be(2);
        queue.Dequeue().Should().Be(3);
    }

    [Fact]
    public void Peek_ReturnsFirstWithoutRemoving()
    {
        var queue = new StackBasedQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);

        queue.Peek().Should().Be(10);
        queue.Peek().Should().Be(10);
    }

    [Fact]
    public void InterleavedEnqueueAndDequeue()
    {
        var queue = new StackBasedQueue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Dequeue().Should().Be(1);

        queue.Enqueue(3);
        queue.Dequeue().Should().Be(2);
        queue.Dequeue().Should().Be(3);
    }

    [Fact]
    public void SingleElement()
    {
        var queue = new StackBasedQueue<string>();
        queue.Enqueue("only");

        queue.Peek().Should().Be("only");
        queue.Dequeue().Should().Be("only");
    }

    [Fact]
    public void WorksWithStrings()
    {
        var queue = new StackBasedQueue<string>();
        queue.Enqueue("a");
        queue.Enqueue("b");

        queue.Dequeue().Should().Be("a");
        queue.Dequeue().Should().Be("b");
    }
}
