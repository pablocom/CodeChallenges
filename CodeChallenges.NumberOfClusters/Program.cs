using System;
using System.Collections.Generic;
using System.Linq;

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

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
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
            if (i < 0 || i >= rows || j < 0 || j >= cols || grid[i][j] == '0') return;
            grid[i][j] = '0';

            DiscoverClusterRecursively(grid, i + 1, j);
            DiscoverClusterRecursively(grid, i - 1, j);
            DiscoverClusterRecursively(grid, i, j + 1);
            DiscoverClusterRecursively(grid, i, j - 1);
        }
    }
}
