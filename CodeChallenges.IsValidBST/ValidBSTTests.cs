using NUnit.Framework;

namespace CodeChallenges.IsValidBST
{
    [TestFixture]
    public class ValidBstTests
    {
        [Test]
        public void ValidatesBinarySearchTree()
        {
            var binarySearchTreeRoot = new TreeNode(1);

            binarySearchTreeRoot.left = new TreeNode(0, new TreeNode(-2));
            binarySearchTreeRoot.right = new TreeNode(3);

            var result = Solution.IsValidBST(binarySearchTreeRoot);
            
            Assert.IsTrue(result);
        }
        
        [Test]
        public void NotValidBst()
        {
            var binarySearchTreeRoot = new TreeNode(5);

            binarySearchTreeRoot.left = new TreeNode(1, new TreeNode(3));
            binarySearchTreeRoot.right = new TreeNode(6);

            var result = Solution.IsValidBST(binarySearchTreeRoot);
            
            Assert.IsFalse(result);
        }
    }
}