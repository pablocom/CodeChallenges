namespace CodeChallenges.Solutions.BinaryTrees;

public class ValidBST
{
    public static bool IsValidBST(TreeNode root)
    {
        return DepthFirstSearch(root, long.MinValue, long.MinValue);
    }

    private static bool DepthFirstSearch(TreeNode root, long minValue, long maxValue)
    {
        if (root == null)
        {
            return true;
        }

        if (root.val > minValue && root.val < maxValue)
        {
            return DepthFirstSearch(root.left, minValue, root.val) &&
                   DepthFirstSearch(root.right, root.val, maxValue);
        }

        return false;
    }
}