namespace CodeChallenges.Solutions.BinaryTrees;

public class LeetCodeTreeNode
{
    public int val { get; }
    public LeetCodeTreeNode left { get; set; }
    public LeetCodeTreeNode right { get; set; }

    public LeetCodeTreeNode(int val = 0, LeetCodeTreeNode left = null, LeetCodeTreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}