using System.Diagnostics;

namespace CodeChallenges.Solutions
{
    [DebuggerDisplay("Node {GetHashCode()}")]
    public class Node {
        public int val;
        public Node next;
        public Node random;
        
        public Node(int _val) {
            val = _val;
            next = null;
            random = null;
        }
    }
}