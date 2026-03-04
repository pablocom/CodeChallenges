using System.Text.Json;

namespace CodeChallenges.Solutions.Graphs;

public static class DirectAcyclicGraphEncoder
{
    public static string Encode(GraphNode? startNode)
    {
        if (startNode is null)
            return "";
        
        var rootId = startNode.Id;

        var (nodeIdValuePairs, nodeAdjacencyList) = TraverseForEncoding(startNode);
        
        return JsonSerializer.Serialize(new SerializableDirectedAcyclicGraph(nodeIdValuePairs, nodeAdjacencyList, rootId));
    }

    private static (NodeIdValuePair[] nodeIdValuePairs, NodeAdjacency[] nodeAdjacencyList) TraverseForEncoding(
        GraphNode startNode)
    {
        var nodeIdValuePairs = new List<NodeIdValuePair>();
        var adjacentByNode = new List<NodeAdjacency>();
        
        var neighborsToVisit = new Queue<GraphNode>();
        var visitedNodeIds = new HashSet<Guid>();

        neighborsToVisit.Enqueue(startNode);

        while (neighborsToVisit.Count > 0)
        {
            var currentNode = neighborsToVisit.Dequeue();
            
            if (!visitedNodeIds.Add(currentNode.Id))
                continue;
            
            nodeIdValuePairs.Add(new(currentNode.Id, currentNode.Value));
            adjacentByNode.Add(new(currentNode.Id, currentNode.Neighbors.Select(x => x.Id).ToArray()));

            foreach (var node in currentNode.Neighbors) 
                neighborsToVisit.Enqueue(node);
        }
        
        return ([..nodeIdValuePairs], [..adjacentByNode]);
    }
}

public sealed record NodeIdValuePair(Guid NodeId, int Value);
public sealed record NodeAdjacency(Guid NodeId, Guid[] Neighbors);
public sealed record SerializableDirectedAcyclicGraph(
    NodeIdValuePair[] NodeIdValuePairs,
    NodeAdjacency[] Connections,
    Guid RootId
);
