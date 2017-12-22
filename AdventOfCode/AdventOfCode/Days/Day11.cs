using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day11 {
        private static void Main() {
            var input = File.ReadAllText("../../Inputs/day11.txt").Replace("\n","").Split(',');

            Console.WriteLine($" Part I: {CountDistance(input)}");
            //Console.WriteLine($"Part II: {}");

            Console.ReadKey();
        }

        public static int CountDistance(IEnumerable<string> input) {
            var grouped = input.GroupBy(i => i).Select(i => new { i.Key, count = i.Count() });

            var firstGroup = grouped.Where(i => i.Key == "n" || i.Key == "s").OrderByDescending(i => i.count);
            var first = new { firstGroup.First().Key, count = firstGroup.First().count - firstGroup.Skip(1).Sum(i => i.count) };

            var secondGroup = grouped.Where(i => i.Key == "ne" || i.Key == "sw").OrderByDescending(i => i.count);
            var second = new { secondGroup.First().Key, count = secondGroup.First().count - secondGroup.Skip(1).Sum(i => i.count) };

            var thirdGroup = grouped.Where(i => i.Key == "nw" || i.Key == "se").OrderByDescending(i => i.count);
            var third = new { thirdGroup.First().Key, count = thirdGroup.First().count - thirdGroup.Skip(1).Sum(i=>i.count) };

            var xPos = second.count + third.count + 0.0;
            var yPos = -first.count + 0.5* second.count - 0.5 * third.count;

            var count = 0;

            while (yPos != 0) {
                xPos--;
                yPos += 0.5;
                count++;
            }

            return Math.Abs(yPos) < 0.01 ? count + (int)Math.Abs(xPos) : count +(int) Math.Abs(yPos);
        }

        //public static int CountMaxDistance(IEnumerable<string> input)
        //{
            
        //}
    }
}
