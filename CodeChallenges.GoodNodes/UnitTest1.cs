using NUnit.Framework;

namespace CodeChallenges.GoodNodes
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var root = new TreeNode(3);
            
            root.left = new TreeNode(1);
            root.left.left = new TreeNode(3);
            
            root.right = new TreeNode(4);
            root.right.left = new TreeNode(1);
            root.right.right = new TreeNode(5);

            var result = Solution.GoodNodes(root);

            var expected = 4;
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void Test2()
        {
            var root = new TreeNode(3);
            
            root.left = new TreeNode(3);
            
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(2);

            var result = Solution.GoodNodes(root);

            var expected = 3;
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void Test3()
        {
            var root = new TreeNode(3);
            
            root.left = new TreeNode(4);
            
            root.left.left = new TreeNode(3);

            var result = Solution.GoodNodes(root);

            var expected = 3;
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}