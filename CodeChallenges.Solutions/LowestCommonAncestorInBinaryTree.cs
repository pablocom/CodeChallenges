using TreeNode = CodeChallenges.Solutions.BinaryTrees.LeetCodeTreeNode;

namespace CodeChallenges.Solutions;

public sealed class LowestCommonAncestorInBinaryTree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root is null)
            return null!;

        if (root.val == p.val || root.val == q.val) 
            return root;

        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        
        if (left is not null && right is not null) 
            return root;
        
        return left ?? right!;
    }
}
