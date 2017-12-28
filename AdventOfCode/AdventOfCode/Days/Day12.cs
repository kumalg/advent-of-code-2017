using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day12 {
        private static void Main() {
            var input = File.ReadAllText("../../Inputs/day12.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Substring(i.IndexOf('>') + 2).Split(',').Select(int.Parse));

            Console.WriteLine($" Part I: {PartOne(input, 0)}");
            Console.WriteLine($"Part II: {PartTwo(input)}");

            Console.ReadKey();
        }

        public static int PartOne(IEnumerable<IEnumerable<int>> input, int id) {
            var connectedWithId = new HashSet<int> { id };
            Go(connectedWithId, input, id);
            return connectedWithId.Count;
        }

        public static int PartTwo(IEnumerable<IEnumerable<int>> input) {
            var programs = input.Count();
            var connectedWithId = new bool[programs];
            var groups = 0;
            while (connectedWithId.Count(i => !i) > 0) {
                Go(connectedWithId, input, connectedWithId.Select((i, index) => (i, index)).First(i => !i.i).index);
                groups++;
            }
            return groups;
        }

        public static void Go(HashSet<int> connected, IEnumerable<IEnumerable<int>> input, int id) {
            var list = input.ElementAt(id);
            foreach (var i in list) {
                if (connected.Add(i))
                    Go(connected, input, i);
            }
        }

        public static void Go(bool[] connected, IEnumerable<IEnumerable<int>> input, int id) {
            var list = input.ElementAt(id);
            foreach (var i in list) {
                if (connected[i]) continue;
                connected[i] = true;
                Go(connected, input, i);
            }
        }
    }
}
