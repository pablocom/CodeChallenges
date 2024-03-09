namespace CodeChallenges.UnitTests;

public class NextPermutationTests
{
    [Fact]
    public void Test0()
    {
        int[] nums = [2, 1];
        int[] nextPermutation = [1, 2];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }

    [Fact]
    public void Test7()
    {
        int[] nums = [1, 2];
        int[] nextPermutation = [2, 1];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }

    [Fact]
    public void Test1()
    {
        int[] nums = [3, 2, 1];
        int[] nextPermutation = [1, 2, 3];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }

    [Fact]
    public void Test2()
    {
        int[] nums = [1, 2, 3];
        int[] nextPermutation = [1, 3, 2];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }

    [Fact]
    public void Test3()
    {
        int[] nums = [1, 1, 5];
        int[] nextPermutation = [1, 5, 1];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }


    [Fact]
    public void Test4()
    {
        int[] nums = [4, 7, 1, 4, 3, 2];
        int[] nextPermutation = [4, 7, 2, 1, 3, 4];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }

    [Fact]
    public void Test5()
    {
        int[] nums = [4, 7, 1, 4, 2, 3];
        int[] nextPermutation = [4, 7, 1, 4, 3, 2];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }


    [Fact]
    public void Test6()
    {
        int[] nums = [4, 7, 4, 9, 8, 7];
        int[] nextPermutation = [4, 7, 7, 4, 8, 9];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }


    [Fact]
    public void Test9()
    {
        int[] nums = [1, 9, 9, 6];
        int[] nextPermutation = [6, 1, 9, 9];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }


    [Fact]
    public void Test8()
    {
        int[] nums = [1, 3, 2];
        int[] nextPermutation = [2, 1, 3];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }

    [Fact]
    public void Test10()
    {
        int[] nums = [2, 3, 1];
        int[] nextPermutation = [3, 1, 2];

        new NextPermutation().ToNextPermutation(nums);

        nums.Should().Equal(nextPermutation);
    }
}
