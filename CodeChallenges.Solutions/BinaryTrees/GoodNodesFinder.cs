using System;

namespace CodeChallenges.Solutions.BinaryTrees;

public class GoodNodesFinder
{
    public static int GoodNodes(LeetCodeTreeNode root) 
    {
        return GoToNode(root, long.MinValue);
    }
    
    public static int GoToNode(LeetCodeTreeNode node, long max)
    {
        if (node == null) return 0;
        max = Math.Max((long) node.val, max);
        var count = max <= node.val ? 1 : 0;
        return count + GoToNode(node.left, max) + GoToNode(node.right, max);
    }
}