using System;
using CodeChallenges.Solutions;
using NUnit.Framework;

namespace CodeChallenges.UnitTests;

public class FindMedianSortedArraysTests
{
    [Test]
    public void Test0()
    {
        var firstArray = new[] { 2, 3 };
        var secondArray = new[] { 1 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2d));
    }
    
    [Test]
    public void Test1()
    {
        var firstArray = new[] { 1, 3 };
        var secondArray = new[] { 2 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2d));
    }
    
    [Test]
    public void Test2()
    {
        var firstArray = new[] { 1, 2, 3 };
        var secondArray = new[] { 4, 5 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(3d));
    }
    
    [Test]
    public void Test3()
    {
        var firstArray = new[] { 1, 2 };
        var secondArray = new[] { 2, 4 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2d));
    }

    [Test]
    public void Test4()
    {
        var firstArray = new[] { 1, 2 };
        var secondArray = new[] { 2, 3 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2.0d));
    }
    
    [Test]
    public void Test5()
    {
        var firstArray = new[] { 1, 3 };
        var secondArray = new[] { 2, 4, 5 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(3.0d));
    }
    
    [Test]
    public void Test6()
    {
        var firstArray = new[] { 1 };
        var secondArray = new[] { 3, 3, 4, 5, 6 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(3.5d));
    }
    
    [Test]
    public void Test7()
    {
        var firstArray = new[] { 1, 2, 3, 6, 7 };
        var secondArray = new[] { 4 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(3.5d));
    }
    
    [Test]
    public void Test8()
    {
        var firstArray = new[] { 1, 2, 3, 6, 7 };
        var secondArray = Array.Empty<int>();

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(3d));
    }
    
    [Test]
    public void Test9()
    {
        var firstArray = Array.Empty<int>();
        var secondArray = new[] { 1, 2, 3, 4 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2.5d));
    }
    
    [Test]
    public void Test10()
    {
        var firstArray = new[] {1, 3};
        var secondArray = new[] { 2, 7 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2.5d));
    }
    
    [Test]
    public void Test11()
    {
        var firstArray = new[] {2, 3};
        var secondArray = Array.Empty<int>();

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2.5d));
    }
    
    [Test]
    public void Test12()
    {
        var firstArray = new[] {2, 2, 4, 4};
        var secondArray = new[] {2, 2, 4, 4};

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(3d));
    }
    
    [Test]
    public void Test13()
    {
        var firstArray = new[] {1, 2};
        var secondArray = new[] {-1, 3};

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(1.5d));
    }
    
    [Test]
    public void Test14()
    {
        var firstArray = new[] { 100001};
        var secondArray = new[] { 100000};

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(100000.5d));
    }
    
    [Test]
    public void Test15()
    {
        var firstArray = new[] { 2, 3, 4 };
        var secondArray = new[] { 1 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2.5d));
    }
    
    [Test]
    public void Test16()
    {
        var firstArray = new[] { 4 };
        var secondArray = new[] { 1, 2, 3 };

        var median = new FindMedianSortedArrays().Solve(firstArray, secondArray);
        
        Assert.That(median, Is.EqualTo(2.5d));
    }
}