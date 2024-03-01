using System.Collections;
using System.Diagnostics;

namespace CodeChallenges.Solutions.LinkedLists;

[DebuggerDisplay("Node {GetHashCode()}")]
public class ListNode : IEnumerable<int>
{
    public int val { get; set; }
    public ListNode? next { get; set; }
    public ListNode? random { get; set; }
        
    // Do not change, is LeetCode ListNode implementation
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        next = null;
        random = null;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new LinkedListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    private class LinkedListEnumerator : IEnumerator<int>
    {
        private ListNode _startNode;
        private ListNode? _currentNode;
        private bool _hasStarted;

        public LinkedListEnumerator(ListNode startNode)
        {
            ArgumentNullException.ThrowIfNull(startNode);
            
            _startNode = startNode;
            Reset();
        }

        public int Current => _currentNode?.val ?? throw new InvalidOperationException();

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (!_hasStarted)
            {
                _currentNode = _startNode;
                _hasStarted = true;
                return true;
            }

            if (_currentNode!.next is null)
                return false;
            
            _currentNode = _currentNode.next;
            return true;
        }

        public void Reset()
        {
            _hasStarted = false;
            _currentNode = null;
        }

        public void Dispose() { }
    }
}