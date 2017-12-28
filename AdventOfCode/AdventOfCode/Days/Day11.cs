using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day11 {
        public static Dictionary<string, (int x, int y)> Directions = new Dictionary<string, (int x, int y)>{
            {  "n", ( 0,  2) },
            { "ne", ( 2,  1) },
            { "nw", (-2,  1) },
            {  "s", ( 0, -2) },
            { "se", ( 2, -1) },
            { "sw", (-2, -1) }};

        private static void Main() {
            var input = File.ReadAllText("../../Inputs/day11.txt").Replace("\n", "").Split(',');

            Console.WriteLine($" Part I: {CountDistance(input)}");
            Console.WriteLine($"Part II: {CountMaxDistance(input)}");

            Console.ReadKey();
        }

        public static int CountDistance(IEnumerable<string> input) {
            var grouped = input.GroupBy(i => i).Select(i => new { i.Key, count = i.Count() });

            var firstGroup = grouped.Where(i => i.Key == "n" || i.Key == "s").OrderByDescending(i => i.count);
            var first = new { firstGroup.First().Key, count = firstGroup.First().count - firstGroup.Skip(1).Sum(i => i.count) };

            var secondGroup = grouped.Where(i => i.Key == "ne" || i.Key == "sw").OrderByDescending(i => i.count);
            var second = new { secondGroup.First().Key, count = secondGroup.First().count - secondGroup.Skip(1).Sum(i => i.count) };

            var thirdGroup = grouped.Where(i => i.Key == "nw" || i.Key == "se").OrderByDescending(i => i.count);
            var third = new { thirdGroup.First().Key, count = thirdGroup.First().count - thirdGroup.Skip(1).Sum(i => i.count) };

            var xPos = (second.count + third.count) * 2;
            var yPos = -2 * first.count + second.count - third.count;

            return CalculateDistance((xPos, yPos));
        }

        public static int CountMaxDistance(IEnumerable<string> steps) {
            var maxDistance = 0;
            var actualPosition = (x: 0, y: 0);
            foreach (var step in steps) {
                var direction = Directions[step];
                actualPosition.x += direction.x;
                actualPosition.y += direction.y;
                maxDistance = Math.Max(maxDistance, CalculateDistance(actualPosition));
            }
            return maxDistance;
        }

        public static int CalculateDistance((int x, int y) position) {
            var count = 0;
            var positionAbs = (x: Math.Abs(position.x), y: Math.Abs(position.y));

            while (positionAbs.y != 0 && positionAbs.x != 0) {
                positionAbs.x -= 2;
                positionAbs.y -= 1;
                count++;
            }

            return positionAbs.y == 0
                ? count + positionAbs.x / 2
                : count + positionAbs.y / 2;
        }
    }
}
