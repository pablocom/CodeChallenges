﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges.Solutions;

public class ReorderLogFiles
{
    public static string[] Solve(string[] logs)
    {
        Array.Sort(logs, new LogsComparer());
        return logs;
    }

    public class LogsComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var log1 = string.Join(string.Empty, x.Split(" ").Skip(1).Select(s => s[0].ToString()).ToArray());
            var log2 = string.Join(string.Empty, y.Split(" ").Skip(1).Select(s => s[0].ToString()).ToArray());

            if (string.Join("", x.Split(" ").Skip(1)) == string.Join("", y.Split(" ").Skip(1)))
            {
                var firstLogTag = x.Split(" ").FirstOrDefault();
                var firstOrDefault = log2.Split(" ").FirstOrDefault();

                return string.Compare(firstLogTag, firstOrDefault, StringComparison.Ordinal);
            }

            if (char.IsDigit(log1[0]) && char.IsDigit(log2[0]))
                return 0;

            if (char.IsLetter(log1[0]) && char.IsLetter(log2[0]))
                return string.Compare(log1, log2, StringComparison.Ordinal);

            if (char.IsLetter(log1[0]))
                return -1;
            return 1;
        }
    }
}