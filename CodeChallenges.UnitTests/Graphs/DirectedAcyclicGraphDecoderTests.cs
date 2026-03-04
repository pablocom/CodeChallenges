using CodeChallenges.Solutions.Graphs;
using static CodeChallenges.UnitTests.Graphs.DagBuilder;

namespace CodeChallenges.UnitTests.Graphs;

public sealed class DirectedAcyclicGraphDecoderTests
{
    [Fact]
    public void NullRootId_ReturnsNull()
    {
        var input = new SerializableDirectedAcyclicGraph([], [], null);

        DirectedAcyclicGraphDecoder.Decode(input).Should().BeNull();
    }

    [Fact]
    public void SingleNode_DecodesWithCorrectIdAndValue()
    {
        // (42)

        var id = Guid.NewGuid();
        var input = new SerializableDirectedAcyclicGraph(
            [new NodeIdValuePair(id, 42)],
            [new NodeAdjacency(id, [])],
            id);

        var result = DirectedAcyclicGraphDecoder.Decode(input)!;

        result.Id.Should().Be(id);
        result.Value.Should().Be(42);
        result.Neighbors.Should().BeEmpty();
    }

    [Fact]
    public void LinearChain_DecodesAllNodesInOrder()
    {
        // (10) -> (20) -> (30)

        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var c = Guid.NewGuid();
        var input = new SerializableDirectedAcyclicGraph(
            [new(a, 10), new(b, 20), new(c, 30)],
            [new(a, [b]), new(b, [c]), new(c, [])],
            a);

        var result = DirectedAcyclicGraphDecoder.Decode(input)!;

        result.Id.Should().Be(a);
        result.Value.Should().Be(10);
        result.Neighbors.Should().HaveCount(1);
        result.Neighbors[0].Id.Should().Be(b);
        result.Neighbors[0].Value.Should().Be(20);
        result.Neighbors[0].Neighbors[0].Id.Should().Be(c);
        result.Neighbors[0].Neighbors[0].Value.Should().Be(30);
    }

    [Fact]
    public void Branching_DecodesAllNeighbors()
    {
        //   (1)
        //   / \
        // (2) (3)

        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var c = Guid.NewGuid();
        var input = new SerializableDirectedAcyclicGraph(
            [new(a, 1), new(b, 2), new(c, 3)],
            [new(a, [b, c]), new(b, []), new(c, [])],
            a);

        var result = DirectedAcyclicGraphDecoder.Decode(input)!;

        result.Value.Should().Be(1);
        result.Neighbors.Should().HaveCount(2);
        result.Neighbors[0].Value.Should().Be(2);
        result.Neighbors[1].Value.Should().Be(3);
    }

    [Fact]
    public void Diamond_SharedDescendantIsSameInstance()
    {
        //    (1)
        //    / \
        //  (2) (3)
        //    \ /
        //    (4)

        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var c = Guid.NewGuid();
        var d = Guid.NewGuid();
        var input = new SerializableDirectedAcyclicGraph(
            [new(a, 1), new(b, 2), new(c, 3), new(d, 4)],
            [new(a, [b, c]), new(b, [d]), new(c, [d]), new(d, [])],
            a);

        var result = DirectedAcyclicGraphDecoder.Decode(input)!;

        var dFromB = result.Neighbors[0].Neighbors[0];
        var dFromC = result.Neighbors[1].Neighbors[0];

        dFromB.Value.Should().Be(4);
        dFromB.Should().BeSameAs(dFromC);
    }

    [Fact]
    public void ComplexDag_DecodesAllNodesWithSharedReferences()
    {
        //        A(10)
        //       / |  \
        //    B(5) C(5) D(10)
        //      \  / \  /
        //      E(3)  F(3)
        //        \  /
        //        G(5)

        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var c = Guid.NewGuid();
        var d = Guid.NewGuid();
        var e = Guid.NewGuid();
        var f = Guid.NewGuid();
        var g = Guid.NewGuid();
        var input = new SerializableDirectedAcyclicGraph(
            [new(a, 10), new(b, 5), new(c, 5), new(d, 10), new(e, 3), new(f, 3), new(g, 5)],
            [new(a, [b, c, d]), new(b, [e]), new(c, [e, f]), new(d, [f]), new(e, [g]), new(f, [g]), new(g, [])],
            a);

        var result = DirectedAcyclicGraphDecoder.Decode(input)!;

        var bNode = result.Neighbors[0];
        var cNode = result.Neighbors[1];
        var dNode = result.Neighbors[2];

        bNode.Neighbors[0].Should().BeSameAs(cNode.Neighbors[0]);
        cNode.Neighbors[1].Should().BeSameAs(dNode.Neighbors[0]);
        bNode.Neighbors[0].Neighbors[0].Should().BeSameAs(dNode.Neighbors[0].Neighbors[0]);
    }

    [Fact]
    public void RoundTrip_EncodeThenDecode_PreservesStructure()
    {
        //        A(10)
        //       / |  \
        //    B(5) C(5) D(10)
        //      \  / \  /
        //      E(3)  F(3)
        //        \  /
        //        G(5)

        var gBuilder = Node(5);
        var eBuilder = Node(3).WithNeighbors(gBuilder);
        var fBuilder = Node(3).WithNeighbors(gBuilder);
        var original = Node(10).WithNeighbors(
            Node(5).WithNeighbors(eBuilder),
            Node(5).WithNeighbors(eBuilder, fBuilder),
            Node(10).WithNeighbors(fBuilder)).Build();

        var json = DirectAcyclicGraphEncoder.Encode(original);
        var serialized = System.Text.Json.JsonSerializer.Deserialize<SerializableDirectedAcyclicGraph>(json)!;
        var decoded = DirectedAcyclicGraphDecoder.Decode(serialized)!;

        decoded.Id.Should().Be(original.Id);
        decoded.Value.Should().Be(original.Value);
        decoded.Neighbors.Should().HaveCount(3);
        decoded.Neighbors[0].Value.Should().Be(5);
        decoded.Neighbors[1].Value.Should().Be(5);
        decoded.Neighbors[2].Value.Should().Be(10);

        var eDecoded = decoded.Neighbors[0].Neighbors[0];
        eDecoded.Should().BeSameAs(decoded.Neighbors[1].Neighbors[0]);

        var fDecoded = decoded.Neighbors[1].Neighbors[1];
        fDecoded.Should().BeSameAs(decoded.Neighbors[2].Neighbors[0]);

        var gDecoded = eDecoded.Neighbors[0];
        gDecoded.Should().BeSameAs(fDecoded.Neighbors[0]);
    }
}
