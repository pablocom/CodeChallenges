using CodeChallenges.Solutions.DataStructures;

namespace CodeChallenges.UnitTests.DataStructures;

public class MinStackTests
{
    [Fact]
    public void PushAndGetMin()
    {
        var stack = new MinStack();
        stack.Push(3);
        stack.Push(5);
        stack.Push(2);

        stack.GetMin().ShouldBe(2);
    }

    [Fact]
    public void PopUpdatesMin()
    {
        var stack = new MinStack();
        stack.Push(3);
        stack.Push(2);
        stack.Push(1);

        stack.Pop();
        stack.GetMin().ShouldBe(2);

        stack.Pop();
        stack.GetMin().ShouldBe(3);
    }

    [Fact]
    public void TopReturnsLastPushed()
    {
        var stack = new MinStack();
        stack.Push(10);
        stack.Push(20);

        stack.Top().ShouldBe(20);
    }

    [Fact]
    public void MinWithDuplicates()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Push(1);

        stack.Pop();
        stack.GetMin().ShouldBe(1);
    }

    [Fact]
    public void NegativeValues()
    {
        var stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);

        stack.GetMin().ShouldBe(-3);
        stack.Pop();
        stack.Top().ShouldBe(0);
        stack.GetMin().ShouldBe(-2);
    }

    [Fact]
    public void SingleElement()
    {
        var stack = new MinStack();
        stack.Push(42);

        stack.Top().ShouldBe(42);
        stack.GetMin().ShouldBe(42);
    }
}
