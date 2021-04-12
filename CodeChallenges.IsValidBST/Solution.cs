using System.Diagnostics;

namespace CodeChallenges.IsValidBST
{
    public class Solution
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
    
    [DebuggerDisplay("{val}")]
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}