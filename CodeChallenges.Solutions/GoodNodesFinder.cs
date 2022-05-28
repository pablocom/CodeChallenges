using System;

namespace CodeChallenges.Solutions;

public class GoodNodesFinder
{
    public static int GoodNodes(TreeNode root) 
    {
        return GoToNode(root, long.MinValue);
    }
    
    public static int GoToNode(TreeNode node, long max)
    {
        if (node == null) return 0;
        max = Math.Max((long) node.val, max);
        var count = max <= node.val ? 1 : 0;
        return count + GoToNode(node.left, max) + GoToNode(node.right, max);
    }
}