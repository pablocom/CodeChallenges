using System;

namespace CodeChallenges.NumberOfClusters
{
    class Program
    {
        public static int rows { get; set; }
        public static int cols { get; set; }

        static void Main(string[] args)
        {
            var map = new[]
            {
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '1', '0', '0', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' },
                new []{ '1', '0', '1', '1', '0', '1', '1' }
                
            };

            Console.WriteLine(NumIslands(map));
        }

        public static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length <= 0) return 0;
            int count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DiscoverClusterRecursively(grid, i, j);
                        count++;
                    }
                }
            }
            return count;
        }

        private static void DiscoverClusterRecursively(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0') return;
            grid[i][j] = '0';

            DiscoverClusterRecursively(grid, i + 1, j);
            DiscoverClusterRecursively(grid, i - 1, j);
            DiscoverClusterRecursively(grid, i, j + 1);
            DiscoverClusterRecursively(grid, i, j - 1);
        }
    }
}
