using CodeChallenges.Solutions;
using Xunit;
using FluentAssertions;

namespace CodeChallenges.UnitTests;
public class LetterCombinationsTests
{
    [Fact]
    public void Test1()
    {
        var input = "23";

        var solution = new LetterCombinations().Solve(input);

        solution.Should().BeEquivalentTo(["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"]);
    }

    [Fact]
    public void Test2()
    {
        var input = "2";

        var solution = new LetterCombinations().Solve(input);

        solution.Should().BeEquivalentTo(["a", "b", "c"]);
    }

    [Fact]
    public void Test3()
    {
        var input = "234";

        var solution = new LetterCombinations().Solve(input);

        solution.Should().BeEquivalentTo([
            "adg", "adh", "adi", "aeg", "aeh", "aei", "afg", "afh", "afi",
            "bdg", "bdh", "bdi", "beg", "beh", "bei", "bfg", "bfh", "bfi",
            "cdg", "cdh", "cdi", "ceg", "ceh", "cei", "cfg", "cfh", "cfi"
        ]);
    }

    [Fact]
    public void Test4()
    {
        var input = "5678";

        var solution = new LetterCombinations().Solve(input);

        solution.Should().BeEquivalentTo([
            "jmpt", "jmpu", "jmpv", "jmqt", "jmqu", "jmqv", "jmrt", "jmru", "jmrv", "jmst", "jmsu", "jmsv", "jnpt", "jnpu",
            "jnpv", "jnqt", "jnqu", "jnqv", "jnrt", "jnru", "jnrv", "jnst", "jnsu", "jnsv", "jopt", "jopu", "jopv", "joqt",
            "joqu", "joqv", "jort", "joru", "jorv", "jost", "josu", "josv", "kmpt", "kmpu", "kmpv", "kmqt", "kmqu", "kmqv",
            "kmrt", "kmru", "kmrv", "kmst", "kmsu", "kmsv", "knpt", "knpu", "knpv", "knqt", "knqu", "knqv", "knrt", "knru",
            "knrv", "knst", "knsu", "knsv", "kopt", "kopu", "kopv", "koqt", "koqu", "koqv", "kort", "koru", "korv", "kost",
            "kosu", "kosv", "lmpt", "lmpu", "lmpv", "lmqt", "lmqu", "lmqv", "lmrt", "lmru", "lmrv", "lmst", "lmsu", "lmsv",
            "lnpt", "lnpu", "lnpv", "lnqt", "lnqu", "lnqv", "lnrt", "lnru", "lnrv", "lnst", "lnsu", "lnsv", "lopt", "lopu",
            "lopv", "loqt", "loqu", "loqv", "lort", "loru", "lorv", "lost", "losu", "losv"
        ]);
    }
}
