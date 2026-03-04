using System.Text.Json;
using CodeChallenges.Solutions.Graphs;
using static CodeChallenges.UnitTests.Graphs.DagBuilder;

namespace CodeChallenges.UnitTests.Graphs;

public sealed class DirectAcyclicGraphEncoderTests
{
    [Fact]
    public void SingleNode_EncodesRootWithNoConnections()
    {
        // (42)

        var root = Node(42).Build();

        var result = Decode(DirectAcyclicGraphEncoder.Encode(root));

        result.RootId.Should().Be(root.Id);
        result.NodeIdValuePairs.Should().ContainSingle()
            .Which.Should().Be(new NodeIdValuePair(root.Id, 42));
        result.Connections.Should().ContainSingle()
            .Which.Neighbors.Should().BeEmpty();
    }

    [Fact]
    public void LinearChain_EncodesAllNodesInBfsOrder()
    {
        // (10) -> (20) -> (30)

        var root = Node(10).WithNeighbors(
            Node(20).WithNeighbors(
                Node(30))).Build();

        var b = root.Neighbors[0];
        var c = b.Neighbors[0];

        var result = Decode(DirectAcyclicGraphEncoder.Encode(root));

        result.RootId.Should().Be(root.Id);
        result.NodeIdValuePairs.Should().BeEquivalentTo([
            new NodeIdValuePair(root.Id, 10),
            new NodeIdValuePair(b.Id, 20),
            new NodeIdValuePair(c.Id, 30)
        ]);
        result.Connections.Should().BeEquivalentTo([
            new NodeAdjacency(root.Id, [b.Id]),
            new NodeAdjacency(b.Id, [c.Id]),
            new NodeAdjacency(c.Id, [])
        ]);
    }

    [Fact]
    public void Branching_EncodesAllNeighbors()
    {
        //   (1)
        //   / \
        // (2) (3)

        var root = Node(1).WithNeighbors(
            Node(2),
            Node(3)).Build();

        var b = root.Neighbors[0];
        var c = root.Neighbors[1];

        var result = Decode(DirectAcyclicGraphEncoder.Encode(root));

        result.RootId.Should().Be(root.Id);
        result.NodeIdValuePairs.Should().BeEquivalentTo([
            new NodeIdValuePair(root.Id, 1),
            new NodeIdValuePair(b.Id, 2),
            new NodeIdValuePair(c.Id, 3)
        ]);
        result.Connections.Should().BeEquivalentTo([
            new NodeAdjacency(root.Id, [b.Id, c.Id]),
            new NodeAdjacency(b.Id, []),
            new NodeAdjacency(c.Id, [])
        ]);
    }

    [Fact]
    public void Diamond_SharedDescendantEncodedOnce()
    {
        //    (1)
        //    / \
        //  (2) (3)
        //    \ /
        //    (4)

        var d = Node(4);
        var root = Node(1).WithNeighbors(
            Node(2).WithNeighbors(d),
            Node(3).WithNeighbors(d)).Build();

        var b = root.Neighbors[0];
        var c = root.Neighbors[1];
        var dNode = b.Neighbors[0];

        var result = Decode(DirectAcyclicGraphEncoder.Encode(root));

        result.RootId.Should().Be(root.Id);
        result.NodeIdValuePairs.Should().BeEquivalentTo([
            new NodeIdValuePair(root.Id, 1),
            new NodeIdValuePair(b.Id, 2),
            new NodeIdValuePair(c.Id, 3),
            new NodeIdValuePair(dNode.Id, 4)
        ]);
        result.Connections.Should().BeEquivalentTo([
            new NodeAdjacency(root.Id, [b.Id, c.Id]),
            new NodeAdjacency(b.Id, [dNode.Id]),
            new NodeAdjacency(c.Id, [dNode.Id]),
            new NodeAdjacency(dNode.Id, [])
        ]);
    }

    [Fact]
    public void ComplexDag_MultipleParentsAndSharedDescendantsEncodedOnce()
    {
        //        A(10)
        //       / |  \
        //    B(5) C(5) D(10)
        //      \  / \  /
        //      E(3)  F(3)
        //        \  /
        //        G(5)

        var g = Node(5);
        var e = Node(3).WithNeighbors(g);
        var f = Node(3).WithNeighbors(g);
        var b = Node(5).WithNeighbors(e);
        var c = Node(5).WithNeighbors(e, f);
        var d = Node(10).WithNeighbors(f);
        var root = Node(10).WithNeighbors(b, c, d).Build();

        var bNode = root.Neighbors[0];
        var cNode = root.Neighbors[1];
        var dNode = root.Neighbors[2];
        var eNode = bNode.Neighbors[0];
        var fNode = cNode.Neighbors[1];
        var gNode = eNode.Neighbors[0];

        var encoded = DirectAcyclicGraphEncoder.Encode(root);
        var result = Decode(encoded);

        result.RootId.Should().Be(root.Id);
        result.NodeIdValuePairs.Should().HaveCount(7);
        result.NodeIdValuePairs.Should().BeEquivalentTo([
            new NodeIdValuePair(root.Id, 10),
            new NodeIdValuePair(bNode.Id, 5),
            new NodeIdValuePair(cNode.Id, 5),
            new NodeIdValuePair(dNode.Id, 10),
            new NodeIdValuePair(eNode.Id, 3),
            new NodeIdValuePair(fNode.Id, 3),
            new NodeIdValuePair(gNode.Id, 5)
        ]);
        result.Connections.Should().BeEquivalentTo([
            new NodeAdjacency(root.Id, [bNode.Id, cNode.Id, dNode.Id]),
            new NodeAdjacency(bNode.Id, [eNode.Id]),
            new NodeAdjacency(cNode.Id, [eNode.Id, fNode.Id]),
            new NodeAdjacency(dNode.Id, [fNode.Id]),
            new NodeAdjacency(eNode.Id, [gNode.Id]),
            new NodeAdjacency(fNode.Id, [gNode.Id]),
            new NodeAdjacency(gNode.Id, [])
        ]);
    }

    private static SerializableDirectedAcyclicGraph Decode(string json) =>
        JsonSerializer.Deserialize<SerializableDirectedAcyclicGraph>(json)
            ?? throw new InvalidOperationException($"Failed to deserialize: {json}");
}
