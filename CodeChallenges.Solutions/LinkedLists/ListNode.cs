using System.Diagnostics;

namespace CodeChallenges.Solutions.LinkedLists;

[DebuggerDisplay("Node {GetHashCode()}")]
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode random;
        
    // Do not change, is LeetCode ListNode implementation
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        next = null;
        random = null;
    }
}