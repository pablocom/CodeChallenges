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

        result.RootId.ShouldBe(root.Id);
        result.NodeIdValuePairs.ShouldHaveSingleItem()
            .ShouldBe(new NodeIdValuePair(root.Id, 42));
        var conn = result.Connections.ShouldHaveSingleItem();
        conn.Neighbors.ShouldBeEmpty();
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

        result.RootId.ShouldBe(root.Id);
        result.NodeIdValuePairs.ShouldBe([
            new NodeIdValuePair(root.Id, 10),
            new NodeIdValuePair(b.Id, 20),
            new NodeIdValuePair(c.Id, 30)
        ], ignoreOrder: true);
        AssertConnections(result.Connections, [
            (root.Id, new[] { b.Id }),
            (b.Id, new[] { c.Id }),
            (c.Id, Array.Empty<Guid>())
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

        result.RootId.ShouldBe(root.Id);
        result.NodeIdValuePairs.ShouldBe([
            new NodeIdValuePair(root.Id, 1),
            new NodeIdValuePair(b.Id, 2),
            new NodeIdValuePair(c.Id, 3)
        ], ignoreOrder: true);
        AssertConnections(result.Connections, [
            (root.Id, new[] { b.Id, c.Id }),
            (b.Id, Array.Empty<Guid>()),
            (c.Id, Array.Empty<Guid>())
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

        result.RootId.ShouldBe(root.Id);
        result.NodeIdValuePairs.ShouldBe([
            new NodeIdValuePair(root.Id, 1),
            new NodeIdValuePair(b.Id, 2),
            new NodeIdValuePair(c.Id, 3),
            new NodeIdValuePair(dNode.Id, 4)
        ], ignoreOrder: true);
        AssertConnections(result.Connections, [
            (root.Id, new[] { b.Id, c.Id }),
            (b.Id, new[] { dNode.Id }),
            (c.Id, new[] { dNode.Id }),
            (dNode.Id, Array.Empty<Guid>())
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

        result.RootId.ShouldBe(root.Id);
        result.NodeIdValuePairs.Count().ShouldBe(7);
        result.NodeIdValuePairs.ShouldBe([
            new NodeIdValuePair(root.Id, 10),
            new NodeIdValuePair(bNode.Id, 5),
            new NodeIdValuePair(cNode.Id, 5),
            new NodeIdValuePair(dNode.Id, 10),
            new NodeIdValuePair(eNode.Id, 3),
            new NodeIdValuePair(fNode.Id, 3),
            new NodeIdValuePair(gNode.Id, 5)
        ], ignoreOrder: true);
        AssertConnections(result.Connections, [
            (root.Id, new[] { bNode.Id, cNode.Id, dNode.Id }),
            (bNode.Id, new[] { eNode.Id }),
            (cNode.Id, new[] { eNode.Id, fNode.Id }),
            (dNode.Id, new[] { fNode.Id }),
            (eNode.Id, new[] { gNode.Id }),
            (fNode.Id, new[] { gNode.Id }),
            (gNode.Id, Array.Empty<Guid>())
        ]);
    }

    private static void AssertConnections(
        IReadOnlyList<NodeAdjacency> actual,
        (Guid NodeId, Guid[] Neighbors)[] expected)
    {
        actual.Count.ShouldBe(expected.Length);
        foreach (var (nodeId, neighbors) in expected)
        {
            var match = actual.FirstOrDefault(a => a.NodeId == nodeId);
            match.ShouldNotBeNull($"Connection for node {nodeId} should exist");
            match.Neighbors.ShouldBe(neighbors);
        }
    }

    private static SerializableDirectedAcyclicGraph Decode(string json) =>
        JsonSerializer.Deserialize<SerializableDirectedAcyclicGraph>(json)
            ?? throw new InvalidOperationException($"Failed to deserialize: {json}");
}
