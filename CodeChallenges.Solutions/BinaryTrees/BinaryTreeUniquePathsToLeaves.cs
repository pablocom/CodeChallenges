using System.Text;

namespace CodeChallenges.Solutions.BinaryTrees;

public static class BinaryTreeUniquePathsToLeaves
{
    public static List<string> Solve(LeetCodeTreeNode root)
    {
        var result = new List<string>();
        var sb = new StringBuilder();
        Traverse(root, ref result, ref sb);
        return result;
    }

    private static void Traverse(LeetCodeTreeNode node, ref List<string> result, ref StringBuilder pathBuilder)
    {
        var lengthBefore = pathBuilder.Length;

        if (pathBuilder.Length is not 0)
            pathBuilder.Append('-').Append('>').Append(node.val);
        else
            pathBuilder.Append(node.val);

        if (node.left is null && node.right is null)
            result.Add(pathBuilder.ToString());

        if (node.left is not null)
            Traverse(node.left, ref result, ref pathBuilder);
        if (node.right is not null)
            Traverse(node.right, ref result, ref pathBuilder);

        pathBuilder.Remove(lengthBefore, pathBuilder.Length - lengthBefore);
    }
}