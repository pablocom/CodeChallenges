using System.Diagnostics;

namespace CodeChallenges.Solutions
{
    [DebuggerDisplay("Node {GetHashCode()}")]
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode random;
        
        public ListNode(int val) {
            val = val;
            next = null;
            random = null;
        }
    }
}