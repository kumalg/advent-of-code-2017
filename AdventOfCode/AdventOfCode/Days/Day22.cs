using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day22 {
        private static void Main() {
            var input = File.ReadAllText("../../Inputs/day22.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select((i, indexY) =>
                    i.ToCharArray()
                        .Select((c, indexX) => new KeyValuePair<(int, int), bool>((indexX, indexY), c == '#')))
                .SelectMany(nodes => nodes).ToDictionary(node => node.Key, node => node.Value);

            Console.WriteLine($" Part I: {CountPartOne(input, 10000)}");
            var start = DateTime.Now.Ticks;
            var partTwo = CountPartTwo(input, 10000000);
            var end = DateTime.Now.Ticks;
            var time = (end - start) / TimeSpan.TicksPerMillisecond;
            Console.WriteLine($"Part II: {partTwo}  (Time: {time} ms)");

            Console.ReadKey();
        }

        public static int CountPartOne(Dictionary<(int, int), bool> input, int steps) {
            var map = input.ToDictionary(entry => entry.Key, entry => entry.Value);
            var count = 0;

            var actualX = (int)Math.Sqrt(map.Count) / 2;
            var actualY = actualX;
            var direction = Direction.Up;

            for (var step = 0; step < steps; step++) {
                if (!map.ContainsKey((actualX, actualY)))
                    map.Add((actualX, actualY), false);

                var infected = map[(actualX, actualY)];
                if (!infected)
                    count++;
                map[(actualX, actualY)] = !infected;

                var change = Turn(actualX, actualY, direction, infected ? Direction.Right : Direction.Left);

                actualX = change.Item1;
                actualY = change.Item2;
                direction = change.Item3;
            }

            return count;
        }

        public static int CountPartTwo(Dictionary<(int, int), bool> input, int steps) {
            var map = input.ToDictionary(entry => entry.Key, entry => entry.Value ? 2 : 0);
            var count = 0;

            var actualX = (int)Math.Sqrt(map.Count) / 2;
            var actualY = actualX;
            var direction = Direction.Up;

            for (var step = 0; step < steps; step++) {
                if (!map.ContainsKey((actualX, actualY)))
                    map.Add((actualX, actualY), 0);

                var state = map[(actualX, actualY)];
                if (state == 1)
                    count++;
                map[(actualX, actualY)] = (state + 1) % 4;

                var change = Turn(actualX, actualY, direction, (Direction)((state - 1) % 4));

                actualX = change.Item1;
                actualY = change.Item2;
                direction = change.Item3;
            }

            return count;
        }

        private static (int, int) Turn(int x, int y, Direction direction) {
            switch (direction) {
                case Direction.Up:
                    y--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Down:
                    y++;
                    break;
                case Direction.Left:
                    x--;
                    break;
            }
            return (x, y);
        }

        private static (int, int, Direction) Turn(int x, int y, Direction direction, Direction turnTo) {
            Direction newDirection;

            switch (turnTo) {
                case Direction.Up:
                    newDirection = direction;
                    break;
                case Direction.Right:
                    newDirection = direction == Direction.Left ? Direction.Up : (direction + 1);
                    break;
                case Direction.Down:
                    newDirection = (Direction)((int)(direction + 2) % 4);
                    break;
                default:
                    newDirection = direction == Direction.Up ? Direction.Left : (direction - 1);
                    break;
            }

            var newPosition = Turn(x, y, newDirection);
            return (newPosition.Item1, newPosition.Item2, newDirection);
        }
        
        public enum Direction {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }
    }
}