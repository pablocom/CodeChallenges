using System.Text;

namespace CodeChallenges.Solutions;

public static class BinarySum
{
    // Time O(N) => N is the longest of the binary nums
    // Space O(N+1) => N is the longest of the binary nums
    public static string Solve(string a, string b)
    {
        var resultCapacity = a.Length > b.Length ? a.Length + 1 : b.Length + 1;
        var sb = new StringBuilder(resultCapacity);

        var aCursor = a.Length - 1;
        var bCursor = b.Length - 1;

        var carry = 0;

        while (aCursor >= 0 || bCursor >= 0)
        {
            var aDigit = aCursor >= 0 ? CharBinaryToInt(a[aCursor]) : 0;
            var bDigit = bCursor >= 0 ? CharBinaryToInt(b[bCursor]) : 0;

            var binaryDigitSum = carry + aDigit + bDigit;

            switch (binaryDigitSum) {
                case 0:
                    sb.Insert(0, '0');
                    carry = 0;
                    break;
                case 1:
                    sb.Insert(0, '1');
                    carry = 0;
                    break;
                case 2:
                    sb.Insert(0, '0');
                    carry = 1;
                    break;
                case 3:
                    sb.Insert(0, '1');
                    carry = 1;
                    break;
                default:
                    throw new InvalidOperationException("Binary digit sum unexpected");
            }

            if (aCursor >= 0) aCursor--;
            if (bCursor >= 0) bCursor--;
        }

        if (carry is 1)
            sb.Insert(0, '1');
        
        return sb.ToString();
    }

    private static int CharBinaryToInt(char character)
    {
        return character switch
        {
            '0' => 0,
            '1' => 1,
            _ => throw new InvalidOperationException()
        };
    }
}