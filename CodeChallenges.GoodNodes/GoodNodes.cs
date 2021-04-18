using System;

namespace CodeChallenges.GoodNodes
{
    public class Solution
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

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}