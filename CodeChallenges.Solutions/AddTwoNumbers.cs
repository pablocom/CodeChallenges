using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CodeChallenges.Solutions;

public static class AddTwoNumbers
{
    public static ListNode Solve(ListNode firstNumber, ListNode secondNumber)
    {
        var firstNumberStack = BuildStackFrom(firstNumber);
        var secondNumberStack = BuildStackFrom(secondNumber);

        var firstResult = ConvertToNumber(firstNumberStack);
        var secondResult = ConvertToNumber(secondNumberStack);
        
        return ConvertToReversedLinkedList(firstResult + secondResult);
    }

    private static Stack<int> BuildStackFrom(ListNode linkedList)
    {
        var stack = new Stack<int>();
        while (linkedList != null)
        {
            stack.Push(linkedList.val);
            linkedList = linkedList.next;
        }
        
        return stack;
    }

    private static double ConvertToNumber(Stack<int> firstNumberStack)
    {
        double result = 0;
        while (firstNumberStack.Any())
        {
            result += firstNumberStack.Peek() * Math.Pow(10, firstNumberStack.Count - 1);
            firstNumberStack.Pop();
        }

        return result;
    }

    private static ListNode ConvertToReversedLinkedList(double number)
    {
        var numberAsString = number.ToString(CultureInfo.InvariantCulture).Reverse().ToArray();
        
        var rootNode = new ListNode(numberAsString.First() - '0');
        var iterableNode = rootNode;
        foreach (var num in numberAsString.Skip(1))
        {
            iterableNode.next = new ListNode(num - '0');
            iterableNode = iterableNode.next;
        }

        return rootNode;
    }
}   