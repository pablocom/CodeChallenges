using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests
{
    public class GoodNodesTests
    {
        [Test]
        public void Test1()
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(3)
                },
                right = new TreeNode(4)
                {
                    left = new TreeNode(1), 
                    right = new TreeNode(5)
                }
            };

            var result = GoodNodesFinder.GoodNodes(root);

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

            var result = GoodNodesFinder.GoodNodes(root);

            var expected = 3;
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void Test3()
        {
            var root = new TreeNode(3);
            
            root.left = new TreeNode(4);
            
            root.left.left = new TreeNode(3);

            var result = GoodNodesFinder.GoodNodes(root);

            var expected = 2;
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}