using CodeChallenges.Solutions.Strings;

namespace CodeChallenges.UnitTests.Strings;

public class LongestSubstringPalindromeTests
{
    private static bool IsPalindrome(string s)
    {
        for (var i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }

    [Fact]
    public void SingleCharacter_ReturnsThatCharacter()
    {
        var result = LongestSubstringPalindrome.Solve("a");

        result.Should().Be("a");
    }

    [Fact]
    public void TwoIdenticalCharacters_ReturnsBoth()
    {
        var result = LongestSubstringPalindrome.Solve("aa");

        result.Should().Be("aa");
    }

    [Fact]
    public void TwoDifferentCharacters_ReturnsFirstCharacter()
    {
        // Odd-length expansion from index 0 finds "a" (length 1),
        // then from index 1 finds "b" (length 1). First one wins.
        var result = LongestSubstringPalindrome.Solve("ab");

        result.Should().HaveLength(1);
        result.Should().Be("a");
    }

    [Fact]
    public void OddLengthPalindrome_Babad_ReturnsFirstFound()
    {
        // "babad": expanding from center index 1 ('a') finds "bab" (length 3).
        // Expanding from center index 2 ('b') finds "aba" (length 3), but
        // "bab" is already length 3 so it is not replaced.
        var result = LongestSubstringPalindrome.Solve("babad");

        result.Should().HaveLength(3);
        IsPalindrome(result).Should().BeTrue();
        result.Should().Be("bab");
    }

    [Fact]
    public void EvenLengthPalindrome_Cbbd_ReturnsBb()
    {
        var result = LongestSubstringPalindrome.Solve("cbbd");

        result.Should().Be("bb");
    }

    [Fact]
    public void EntireStringIsPalindrome_OddLength_ReturnsWholeString()
    {
        var result = LongestSubstringPalindrome.Solve("racecar");

        result.Should().Be("racecar");
    }

    [Fact]
    public void EntireStringIsPalindrome_EvenLength_ReturnsWholeString()
    {
        var result = LongestSubstringPalindrome.Solve("abba");

        result.Should().Be("abba");
    }

    [Fact]
    public void PalindromeAtStart_ReturnsIt()
    {
        // "abacxy" -> longest palindrome is "aba" at the start
        var result = LongestSubstringPalindrome.Solve("abacxy");

        result.Should().Be("aba");
    }

    [Fact]
    public void PalindromeAtEnd_ReturnsIt()
    {
        // "xyzaba" -> longest palindrome is "aba" at the end
        var result = LongestSubstringPalindrome.Solve("xyzaba");

        result.Should().Be("aba");
    }

    [Fact]
    public void PalindromeInMiddle_ReturnsIt()
    {
        // "xabacbay" -> longest palindromes: "aba" (length 3) at index 1, "bacab"? No.
        // Let's use "xracarx" -- no, keep it simple: "xymabamyz"
        // "aba" at index 3. But let's use a clearer example.
        // "xxabbaxx" -> the whole string is a palindrome of length 8.
        // Use "pqabbarst" -> "abba" at index 2 is the longest (length 4).
        var result = LongestSubstringPalindrome.Solve("pqabbarst");

        result.Should().Be("abba");
    }

    [Fact]
    public void AllSameCharacters_ReturnsEntireString()
    {
        var result = LongestSubstringPalindrome.Solve("aaaa");

        result.Should().Be("aaaa");
    }

    [Fact]
    public void AllSameCharacters_LongerString_ReturnsEntireString()
    {
        var result = LongestSubstringPalindrome.Solve("bbbbbbb");

        result.Should().Be("bbbbbbb");
    }

    [Fact]
    public void NestedPalindromes_ReturnsLongest()
    {
        // "abaXYZaba" has "aba" twice but no longer palindrome
        // Use "abacaba" -> expanding from center index 3 ('c') finds "abacaba" (length 7)
        var result = LongestSubstringPalindrome.Solve("abacaba");

        result.Should().Be("abacaba");
    }

    [Fact]
    public void MultiplePalindromesOfDifferentLengths_ReturnsLongest()
    {
        // "forgeeksskeegfor" contains "geeksskeeg" (length 10) as a palindrome
        var result = LongestSubstringPalindrome.Solve("forgeeksskeegfor");

        result.Should().Be("geeksskeeg");
    }

    [Fact]
    public void LeetCodeExample_SingleCharacterA_ReturnsA()
    {
        var result = LongestSubstringPalindrome.Solve("a");

        result.Should().Be("a");
    }

    [Fact]
    public void NoPalindromeExceedingSingleChar_ReturnsFirstCharacter()
    {
        // "abcde" has no palindrome longer than 1
        var result = LongestSubstringPalindrome.Solve("abcde");

        result.Should().HaveLength(1);
        result.Should().Be("a");
    }

    [Fact]
    public void EvenPalindromeAtStart_ReturnsIt()
    {
        // "aabcde" -> "aa" at the start is the longest palindrome (length 2)
        var result = LongestSubstringPalindrome.Solve("aabcde");

        result.Should().Be("aa");
    }

    [Fact]
    public void EvenPalindromeAtEnd_ReturnsIt()
    {
        // "xyzcc" -> "cc" at the end (length 2)
        var result = LongestSubstringPalindrome.Solve("xyzcc");

        result.Should().Be("cc");
    }

    [Fact]
    public void LongerEvenPalindrome_ReturnsIt()
    {
        // "abcddcba" is a full even-length palindrome of length 8
        var result = LongestSubstringPalindrome.Solve("abcddcba");

        result.Should().Be("abcddcba");
    }

    [Fact]
    public void OddAndEvenPalindromes_LongerOddWins()
    {
        // "aabaa" -> entire string is an odd palindrome of length 5
        // "aa" is an even palindrome of length 2
        // The odd one (length 5) wins
        var result = LongestSubstringPalindrome.Solve("aabaa");

        result.Should().Be("aabaa");
    }

    [Fact]
    public void OddAndEvenPalindromes_LongerEvenWins()
    {
        // "xabbayracecar" -> "racecar" (odd, length 7) vs "abba" (even, length 4)
        // "racecar" wins at length 7
        var result = LongestSubstringPalindrome.Solve("xabbayracecar");

        result.Should().Be("racecar");
    }

    [Fact]
    public void TwoCharacterPalindrome_InLongerString()
    {
        // "abcddxyz" -> "dd" is the longest palindrome
        var result = LongestSubstringPalindrome.Solve("abcddxyz");

        result.Should().Be("dd");
    }

    [Fact]
    public void LongStringWithPalindromeInCenter()
    {
        // "pqrlevelstu" -> "level" is the longest palindrome (length 5)
        var result = LongestSubstringPalindrome.Solve("pqrlevelstu");

        result.Should().Be("level");
    }

    [Fact]
    public void ResultIsAlwaysAValidPalindrome()
    {
        var inputs = new[]
        {
            "a", "ab", "abc", "aab", "baa", "abba", "racecar",
            "banana", "million", "abcba", "cbbd", "babad"
        };

        foreach (var input in inputs)
        {
            var result = LongestSubstringPalindrome.Solve(input);

            result.Should().NotBeEmpty(because: $"input \"{input}\" has at least one character");
            IsPalindrome(result).Should().BeTrue(
                because: $"the result \"{result}\" from input \"{input}\" must be a palindrome");
            input.Should().Contain(result,
                because: $"the result \"{result}\" must be a substring of input \"{input}\"");
        }
    }
}
