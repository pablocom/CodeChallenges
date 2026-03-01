using CodeChallenges.Solutions.BinaryTrees;

namespace CodeChallenges.UnitTests.BinaryTrees;

public sealed class BinaryTreeBuilder
{
    private readonly int _value;
    private BinaryTreeBuilder? _left;
    private BinaryTreeBuilder? _right;

    private BinaryTreeBuilder(int value) => _value = value;

    public static BinaryTreeBuilder Node(int value) => new(value);

    public BinaryTreeBuilder WithLeft(BinaryTreeBuilder subtree)
    {
        _left = subtree;
        return this;
    }

    public BinaryTreeBuilder WithRight(BinaryTreeBuilder subtree)
    {
        _right = subtree;
        return this;
    }

    public LeetCodeTreeNode Build() =>
        new(_value, _left?.Build(), _right?.Build());
}
