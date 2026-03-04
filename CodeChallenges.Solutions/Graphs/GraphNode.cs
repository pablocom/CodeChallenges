namespace CodeChallenges.Solutions.Graphs;

public sealed class GraphNode
{
    public Guid Id { get; }
    public int Value { get; set; }
    public IList<GraphNode> Neighbors { get; set; }

    public GraphNode(Guid id, int value)
    {
        Id = id;
        Value = value;
        Neighbors = [];
    }
    
    public GraphNode(Guid id, int value, IList<GraphNode> neighbors)
    {
        Id = id;
        Value = value;
        Neighbors = neighbors;
    }
    
    public GraphNode(int value)
    {
        Id = Guid.NewGuid();
        Value = value;
        Neighbors = [];
    }

    public GraphNode(int value, IList<GraphNode> neighbors)
    {
        Id = Guid.NewGuid();
        Value = value;
        Neighbors = neighbors;
    }
}
