using CodeChallenges.Solutions.Graphs;

namespace CodeChallenges.UnitTests.Graphs;

public sealed class DagBuilder
{
    private readonly int _value;
    private readonly List<DagBuilder> _neighbors = [];
    private GraphNode? _built;

    private DagBuilder(int value) => _value = value;

    public static DagBuilder Node(int value) => new(value);

    public DagBuilder WithNeighbors(params DagBuilder[] neighbors)
    {
        _neighbors.AddRange(neighbors);
        return this;
    }

    public GraphNode Build()
    {
        if (_built is not null) return _built;

        _built = new GraphNode(_value);
        foreach (var neighbor in _neighbors)
            _built.Neighbors.Add(neighbor.Build());
        return _built;
    }
}
