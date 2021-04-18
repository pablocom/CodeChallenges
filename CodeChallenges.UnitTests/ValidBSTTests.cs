using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
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

            var result = ValidBST.IsValidBST(binarySearchTreeRoot);
            
            Assert.False(result);
        }
        
        [Test]
        public void NotValidBst()
        {
            var binarySearchTreeRoot = new TreeNode(5);

            binarySearchTreeRoot.left = new TreeNode(1, new TreeNode(3));
            binarySearchTreeRoot.right = new TreeNode(6);

            var result = ValidBST.IsValidBST(binarySearchTreeRoot);
            
            Assert.IsFalse((bool) result);
        }
    }
}