using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days {
    public class Day19 {
        private static void Main() {
            var map = File.ReadAllText("../../Inputs/day19.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.ToCharArray().ToList());

            var result = PartOne(map);
            Console.WriteLine($" Part I: {result.text}");
            Console.WriteLine($"Part II: {result.steps}");
            Console.ReadKey();
        }

        private static (string text, int steps) PartOne(IEnumerable<List<char>> map) {
            var position = (x: map.ElementAt(0).IndexOf('|'), y: 0);
            var direction = Direction.Down;
            var steps = 0;
            var lettersCount = map.SelectMany(i => i).Count(c => c >= 'A' && c <= 'Z');
            var dimension = (x: map.ElementAt(0).Count, y: map.Count());
            var result = new StringBuilder();

            while (result.Length < lettersCount) {
                steps++;
                var actuaChar = map.ElementAt(position.y)[position.x];
                if (actuaChar == ' ') {
                    Console.WriteLine("No coś nie pykło");
                    break;
                }
                if (actuaChar == '|' || actuaChar == '-') {
                    position.x += direction.x;
                    position.y += direction.y;
                }
                else {
                    if (actuaChar != '+')
                        result.Append(map.ElementAt(position.y)[position.x]);

                    var directions = new[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left }
                        .Where(i => i.x != -direction.x || i.y != -direction.y);

                    foreach (var valueTuple in directions) {
                        var newPos = (x: position.x + valueTuple.x, y: position.y + valueTuple.y);
                        if (newPos.x <= 0 || newPos.x >= dimension.x ||
                            newPos.y <= 0 || newPos.y >= dimension.y ||
                            map.ElementAt(newPos.y)[newPos.x] == ' ')
                            continue;
                        position = newPos;
                        direction = valueTuple;
                        break;
                    }
                }
            }

            return (result.ToString(), steps);
        }

        public static class Direction {
            public static (int x, int y) Up = (0, -1);
            public static (int x, int y) Down = (0, 1);
            public static (int x, int y) Right = (1, 0);
            public static (int x, int y) Left = (-1, 0);
        }
    }
}
