namespace CodeChallenges.Solutions.Graphs;

public sealed class GraphNode
{
    public Guid Id { get; } = Guid.NewGuid();
    public int Value { get; set; }
    public IList<GraphNode> Neighbors { get; set; }

    public GraphNode(int value)
    {
        Value = value;
        Neighbors = [];
    }

    public GraphNode(int value, IList<GraphNode> neighbors)
    {
        Value = value;
        Neighbors = neighbors;
    }
}
