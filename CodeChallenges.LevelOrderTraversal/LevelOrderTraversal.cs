using System.Collections.Generic;

namespace CodeChallenges.LevelOrderTraversal
{
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

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var nodesByLevel = new Dictionary<int, List<int>>();

            var queue = new Queue<TreeNode>();
            var levelQueue = new Queue<int>();

            int? currentLevel = 1;
            var actualNode = root;

            while (actualNode != null)
            {
                if (nodesByLevel.ContainsKey(currentLevel.Value))
                    nodesByLevel[currentLevel.Value].Add(actualNode.val);
                else
                    nodesByLevel.Add(currentLevel.Value, new List<int>() { actualNode.val });

                if (actualNode.left != null)
                {
                    queue.Enqueue(actualNode.left);
                    levelQueue.Enqueue(currentLevel.Value + 1);
                }
                if (actualNode.right != null)
                {
                    queue.Enqueue(actualNode.right);
                    levelQueue.Enqueue(currentLevel.Value + 1);
                }

                queue.TryDequeue(out actualNode);
                if (levelQueue.Count > 0) currentLevel = levelQueue.Dequeue();
                
            }

            IList<IList<int>> result = new List<IList<int>>();
            foreach (var level in nodesByLevel)
            {
                result.Add(level.Value);
            }

            return result;
        }
    }
}