using TreeNode = CodeChallenges.Solutions.BinaryTrees.LeetCodeTreeNode;

namespace CodeChallenges.Solutions;

public sealed class DeleteNodeInBinarySearchTree
{
    public TreeNode? DeleteNode(TreeNode? root, int key)
    {
        if (root is null)
            return root;

        var keyIsInLeftSubtree = key < root.val;
        var keyIsInRightSubtree = key > root.val;

        if (keyIsInLeftSubtree)
            root.left = DeleteNode(root.left, key);
        else if (keyIsInRightSubtree)
            root.right = DeleteNode(root.right, key);
        else
        {
            if (root.left is null)
                return root.right;
            else if (root.right is null)
                return root.left;

            root.val = MinValue(root.right);
            root.right = DeleteNode(root.right, root.val);
        }
        return root;
    }

    public static int MinValue(TreeNode node)
    {
        var minimumValue = node.val;
        while (node.left is not null)
        {
            minimumValue = node.left.val;
            node = node.left;
        }
        return minimumValue;
    }
}
