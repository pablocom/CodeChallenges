using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions.BinaryTrees;

// Description link: https://leetcode.com/problems/validate-binary-search-tree/
public class ValidBST
{
    public static bool IsValidBinarySearchTreeBfs(LeetCodeTreeNode root)
    {
        var nodesToVisit = new Queue<BstIteration>();
        nodesToVisit.Enqueue(new BstIteration(root, long.MinValue, long.MaxValue));

        while (nodesToVisit.Any())
        {
            var iteration = nodesToVisit.Dequeue();
            if (iteration.Node is null)
                continue;

            if (iteration.Node.val <= iteration.LeftLimit || iteration.Node.val >= iteration.RightLimit)
                return false;

            nodesToVisit.Enqueue(new BstIteration(iteration.Node.right, iteration.Node.val, iteration.RightLimit));
            nodesToVisit.Enqueue(new BstIteration(iteration.Node.left, iteration.LeftLimit, iteration.Node.val));
        }
        
        return true;
    }
    
    public static bool IsValidBinarySearchTreeDfs(LeetCodeTreeNode root)
    {
        var nodesToVisit = new Stack<BstIteration>();
        nodesToVisit.Push(new BstIteration(root, long.MinValue, long.MaxValue));

        while (nodesToVisit.Any())
        {
            var iteration = nodesToVisit.Pop();
            if (iteration.Node is null)
                continue;

            if (iteration.Node.val <= iteration.LeftLimit || iteration.Node.val >= iteration.RightLimit)
                return false;

            nodesToVisit.Push(new BstIteration(iteration.Node.right, iteration.Node.val, iteration.RightLimit));
            nodesToVisit.Push(new BstIteration(iteration.Node.left, iteration.LeftLimit, iteration.Node.val));
        }
        
        return true;
    }

    private class BstIteration
    {
        public LeetCodeTreeNode Node { get; }
        public long LeftLimit { get; }
        public long RightLimit { get; }

        public BstIteration(LeetCodeTreeNode node, long leftLimit, long rightLimit)
        {
            Node = node;
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
        }
    }
}