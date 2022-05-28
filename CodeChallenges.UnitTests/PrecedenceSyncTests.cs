using System;
using System.Threading.Tasks;
using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class Tests
{
    [Test]
    public async Task Test1()
    {
        var foo = new PrecedenceSync();

        var task1 = new Task(() =>
        {
            foo.First(() => Console.WriteLine("First"));
        });
            
        var task2 = new Task(() =>
        {
            foo.Second(() => Console.WriteLine("Second"));
        });
            
        var task3 = new Task(() =>
        {
            foo.Third(() => Console.WriteLine("Third"));
        });
            
        task3.Start();
        task2.Start();
        task1.Start();

        await Task.WhenAll(task2, task3);
            
        Assert.Pass();
    }
}