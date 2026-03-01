namespace CodeChallenges.Solutions.BinaryTrees;

public static class NodesEqualToAverageOfSubtree
{
    public static int Solve(LeetCodeTreeNode root)
    {
        var averageNodesCount = 0;
        Traverse(root, ref averageNodesCount);
        return averageNodesCount;
    }

    private static (int Sum, int NodeCount) Traverse(LeetCodeTreeNode node, ref int matches)
    {
        var (leftSum, leftCount) = node.left is not null ? Traverse(node.left, ref matches) : (0, 0);
        var (rightSum, rightCount) = node.right is not null ? Traverse(node.right, ref matches) : (0, 0);

        var subtreeSum = leftSum + rightSum + node.val;
        var subtreeCount = leftCount + rightCount + 1;

        if (node.val == subtreeSum / subtreeCount)
            matches++;

        return (subtreeSum, subtreeCount);
    }
}
