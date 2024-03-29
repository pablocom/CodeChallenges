namespace CodeChallenges.Solutions;

// Description link: https://leetcode.com/problems/valid-palindrome-ii/
public class ValidPalindrome2
{
    public bool Solve(string text)
    {
        var decisionsMade = 0;
        (int Left, int Right) decisionPoint = default;
        var leftToRightIterator = 0;
        var rightToLeftIterator = text.Length - 1;

        while (leftToRightIterator < rightToLeftIterator && leftToRightIterator < text.Length && rightToLeftIterator >= 0)
        {
            if (text[leftToRightIterator] != text[rightToLeftIterator])
            {
                if (decisionsMade == 2)
                    return false;

                if (decisionsMade == 0)
                {
                    decisionPoint = (leftToRightIterator, rightToLeftIterator);
                    rightToLeftIterator--;
                    decisionsMade++;
                    continue;
                }
                
                if (decisionsMade == 1)
                {
                    leftToRightIterator = decisionPoint.Left + 1;
                    rightToLeftIterator = decisionPoint.Right;
                    decisionsMade++;
                }
            }
            else
            {
                leftToRightIterator++;
                rightToLeftIterator--;
            }
        }
        
        return true;
    }
}