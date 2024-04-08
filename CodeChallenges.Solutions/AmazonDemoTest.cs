using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CodeChallenges.UnitTests;

public class AmazonDemoTest
{
    private static class Result
    {
        public static List<int> minimalHeaviestSetA(List<int> arr)
        {
            long sum = 0;
            for (var i = 0; i < arr.Count; i++)
                sum += arr[i];
            
            var span = CollectionsMarshal.AsSpan(arr);
            span.Sort();

            long accumulated = 0;
            for (int i = span.Length - 1; i >= 0; i--)
            {
                accumulated += span[i];

                if (accumulated > sum - accumulated)
                {
                    return new List<int>(span[i..].ToArray());
                }
            }

            throw new UnreachableException();
        }
        
        public static int countGroups(List<string> related)
        {
            var totalGroups = 0;
            var relativesTracked = new HashSet<int>();

            for (var i = 0; i < related.Count; i++)
            {
                if (relativesTracked.Contains(i))
                    continue;
                
                SearchRelativesOf(related, i, relativesTracked);
                totalGroups++;
            }
            
            return totalGroups;
        }

        private static void SearchRelativesOf(List<string> related, int relative, HashSet<int> relativesTracked)
        {
            if (!relativesTracked.Add(relative))
                return;

            for (var j = 0; j < related.Count; j++)
            {
                if (relative == j)
                    continue;
                
                var characters = related[relative].AsSpan();
                
                var hasReceivedBook = characters[j] is '1';
                if (hasReceivedBook) 
                    SearchRelativesOf(related, j, relativesTracked);
            }
            
            relativesTracked.Add(relative);
        }
    }
    
    //[Fact]
    //public void Exercise1_Test1()
    //{
    //    List<int> array = [5, 3, 2, 4, 1, 2];

    //    var solution = Result.minimalHeaviestSetA(array);

    //    solution.Should().Equal([4, 5]);
    //}

    //[Fact]
    //public void Exercise1_Test2()
    //{
    //    List<int> array = [4, 2, 5, 1, 6];

    //    var solution = Result.minimalHeaviestSetA(array);

    //    solution.Should().Equal([5, 6]);
    //}
    
    //[Fact]
    //public void Exercise2_Test1()
    //{
    //    List<string> array = [
    //        "1100", 
    //        "1110",
    //        "0110",
    //        "0001"
    //    ];

    //    var solution = Result.countGroups(array);

    //    solution.Should().Be(2);
    //}
    
    //[Fact]
    //public void Exercise2_Test3()
    //{
    //    List<string> array = [
    //        "10000", 
    //        "01000",
    //        "00100",
    //        "00010",
    //        "00001"
    //    ];

    //    var solution = Result.countGroups(array);

    //    solution.Should().Be(5);
    //}
    
    //[Fact]
    //public void Exercise2_Test2()
    //{
    //    List<string> array = [
    //        "10011", 
    //        "01000",
    //        "00100",
    //        "01010",
    //        "10001"
    //    ];

    //    var solution = Result.countGroups(array);

    //    solution.Should().Be(2);
    //}
    
    //[Fact]
    //public void Exercise2_Test4()
    //{
    //    List<string> array = [
    //        "11111", 
    //        "11111",
    //        "11111",
    //        "11111",
    //        "11111"
    //    ];

    //    var solution = Result.countGroups(array);

    //    solution.Should().Be(1);
    //}
    
    //[Fact]
    //public void Exercise2_Test5()
    //{
    //    List<string> array = [
    //        "1010", 
    //        "0101",
    //        "1010",
    //        "0101",
    //    ];

    //    var solution = Result.countGroups(array);

    //    solution.Should().Be(2);
    //}
    
    //[Fact]
    //public void Exercise2_Test6()
    //{
    //    List<string> array = [
    //        "1001",
    //        "0110",
    //        "0111",
    //        "1011"
    //    ];

    //    var solution = Result.countGroups(array);

    //    solution.Should().Be(1);
    //}
}
