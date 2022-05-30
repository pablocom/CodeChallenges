using System;

namespace CodeChallenges.Solutions;

public class RomanToInt
{
    public int Solve(string s)
    {
        ReadOnlySpan<char> romanNumeralSpan = s.AsSpan();
        var arabicNumber  = 0;
        
        foreach (var arabicToRoman in ArabicToRomanNumerals.All)
        {
            while (romanNumeralSpan.StartsWith(arabicToRoman.Character))
            {
                arabicNumber += arabicToRoman.Arabic;
                romanNumeralSpan = romanNumeralSpan.Slice(arabicToRoman.Character.Length);
            }
        }

        return arabicNumber;
    }
    
    public int SolveWithoutSpan(string s)
    {
        string romanNumeral = s;
        var arabicNumber  = 0;
        
        foreach (var arabicToRoman in ArabicToRomanNumerals.All)
        {
            while (romanNumeral.StartsWith(arabicToRoman.Character))
            {
                arabicNumber += arabicToRoman.Arabic;
                romanNumeral = romanNumeral.Substring(arabicToRoman.Character.Length);
            }
        }

        return arabicNumber;
    }
    
    private class ArabicToRomanNumerals
    {
        private static readonly ArabicToRomanNumerals Thousand = new ArabicToRomanNumerals(1000, "M");
        private static readonly ArabicToRomanNumerals NineHundred = new ArabicToRomanNumerals(900, "CM");
        private static readonly ArabicToRomanNumerals FiveHundred = new ArabicToRomanNumerals(500, "D");
        private static readonly ArabicToRomanNumerals FortyHundred = new ArabicToRomanNumerals(400, "CD");
        private static readonly ArabicToRomanNumerals Hundred = new ArabicToRomanNumerals(100, "C");
        private static readonly ArabicToRomanNumerals Ninety = new ArabicToRomanNumerals(90, "XC");
        private static readonly ArabicToRomanNumerals Fifty = new ArabicToRomanNumerals(50, "L");
        private static readonly ArabicToRomanNumerals Forty = new ArabicToRomanNumerals(40, "XL");
        private static readonly ArabicToRomanNumerals Ten = new ArabicToRomanNumerals(10, "X");
        private static readonly ArabicToRomanNumerals Nine = new ArabicToRomanNumerals(9, "IX");
        private static readonly ArabicToRomanNumerals Five = new ArabicToRomanNumerals(5, "V");
        private static readonly ArabicToRomanNumerals Four = new ArabicToRomanNumerals(4, "IV");
        private static readonly ArabicToRomanNumerals One = new ArabicToRomanNumerals(1, "I");

        public static readonly ArabicToRomanNumerals[] All = new[]
        {
            Thousand, NineHundred, FiveHundred, FortyHundred, Hundred,
            Ninety, Fifty, Forty, Ten, Nine, Five, Four, One
        };
        
        public string Character { get; }
        public int Arabic { get; }

        private ArabicToRomanNumerals(int arabic, string character)
        {
            Character = character;
            Arabic = arabic;
        }
    }
}