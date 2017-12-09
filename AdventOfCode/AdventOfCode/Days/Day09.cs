using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days {
    public class Day09 {
        private const string Pattern = @"<(!!)*>|<(.*?)[^!](!!)*>";

        private static void Main() {
            var input = File.ReadAllText("../../Inputs/day09.txt");
            
            Console.WriteLine($" Part I: {CountTotalScore(input)}");
            Console.WriteLine($"Part II: {CountGarbage(input)}");
            Console.ReadKey();
        }

        public static int CountTotalScore(string input) {
            var score = 0;
            var level = 0;
            var cleanInput = Regex.Replace(input, Pattern, "");

            foreach (var c in cleanInput) {
                if (c == '{') score += ++level;
                else if (c == '}') level--;
            }
            return score;
        }

        public static int CountGarbage(string input) {
            var regex = new Regex(Pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(input);

            var garbageCount = 0;
            while (match.Success) {
                var skip = false;
                var count = 0;
                foreach (var c in match.Value) {
                    if (skip) {
                        skip = false;
                        continue;
                    }
                    if (c == '!')
                        skip = true;
                    else
                        count++;
                }
                garbageCount += count - 2;
                match = match.NextMatch();
            }

            return garbageCount;
        }
    }
}
