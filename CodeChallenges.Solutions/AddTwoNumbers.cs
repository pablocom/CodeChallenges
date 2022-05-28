namespace CodeChallenges.Solutions;

public static class AddTwoNumbers
{
    public static ListNode Solve(ListNode numberOne, ListNode numberTwo)
    {
        var dummyHead = new ListNode(0);
        var iterableOne = numberOne;
        var iterableTwo = numberTwo;
        var resultAppendingHead = dummyHead;

        var sumCarry = 0;
        while (iterableOne is not null && iterableTwo is not null)
        {
            var sum = iterableOne.val + iterableTwo.val + sumCarry;
            resultAppendingHead.next = new ListNode(sum % 10);
            
            if (sum >= 10)
                sumCarry = 1;
            else
                sumCarry = 0;
            
            iterableOne = iterableOne.next;
            iterableTwo = iterableTwo.next;
            resultAppendingHead = resultAppendingHead.next;
        }

        while (iterableOne is not null)
        {
            var valueWithCarry = iterableOne.val + sumCarry;
            resultAppendingHead.next = new ListNode(valueWithCarry % 10);
            
            sumCarry = valueWithCarry >= 10 ? 1 : 0;
            
            resultAppendingHead = resultAppendingHead.next;
            iterableOne = iterableOne.next;
            
        }
        
        while (iterableTwo is not null)
        {
            var valueWithCarry = iterableTwo.val + sumCarry;
            resultAppendingHead.next = new ListNode(valueWithCarry % 10);
            
            sumCarry = valueWithCarry >= 10 ? 1 : 0;
            
            resultAppendingHead = resultAppendingHead.next;
            iterableTwo = iterableTwo.next;
        }

        if (sumCarry == 1)
            resultAppendingHead.next = new ListNode(1);
        
        return dummyHead.next;
    }
}   