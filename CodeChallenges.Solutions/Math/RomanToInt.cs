namespace CodeChallenges.Solutions.Math;

public class RomanToInt
{
    public int Solve(string s)
    {
        var romanNumeralSpan = s.AsSpan();
        var arabicNumber = 0;
        
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
        var romanNumeral = s;
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
    
    public sealed class ArabicToRomanNumerals
    {
        private static readonly ArabicToRomanNumerals Thousand = new(1000, "M");
        private static readonly ArabicToRomanNumerals NineHundred = new(900, "CM");
        private static readonly ArabicToRomanNumerals FiveHundred = new(500, "D");
        private static readonly ArabicToRomanNumerals FortyHundred = new(400, "CD");
        private static readonly ArabicToRomanNumerals Hundred = new(100, "C");
        private static readonly ArabicToRomanNumerals Ninety = new(90, "XC");
        private static readonly ArabicToRomanNumerals Fifty = new(50, "L");
        private static readonly ArabicToRomanNumerals Forty = new(40, "XL");
        private static readonly ArabicToRomanNumerals Ten = new(10, "X");
        private static readonly ArabicToRomanNumerals Nine = new(9, "IX");
        private static readonly ArabicToRomanNumerals Five = new(5, "V");
        private static readonly ArabicToRomanNumerals Four = new(4, "IV");
        private static readonly ArabicToRomanNumerals One = new(1, "I");

        public static readonly IReadOnlyList<ArabicToRomanNumerals> All =
        [
            Thousand, NineHundred, FiveHundred, FortyHundred, Hundred,
            Ninety, Fifty, Forty, Ten, Nine, Five, Four, One
        ];
        
        public string Character { get; }
        public int Arabic { get; }

        private ArabicToRomanNumerals(int arabic, string character)
        {
            Character = character;
            Arabic = arabic;
        }
    }
}