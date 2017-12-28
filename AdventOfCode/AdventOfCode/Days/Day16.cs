using System;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day16 {
        public static string[] Commands = File.ReadAllText("../../Inputs/day16.txt").Split(',');
        public static string Programs = new string(Enumerable.Range('a', 16).Select(i => (char)i).ToArray());

        private static void Main() {
            Console.WriteLine($" Part I: {Dance(Programs)}");
            Console.WriteLine($"Part II: {Dances(Programs, 1_000_000_000)}");
            Console.ReadKey();
        }

        public static string Dance(string programs) {
            return Commands.Aggregate(programs, Change);
        }

        public static string Dances(string programs, int iterations) {
            return Enumerable
                .Range(0, iterations % 36)
                .Aggregate(programs, (a, b) => Dance(a));
        }

        public static string Change(string order, string command) {
            switch (command.Substring(0, 1)) {
                case "s": {
                    var spin = int.Parse(command.Substring(1)) % 16;
                    return order.Substring(order.Length - spin) + order.Substring(0, order.Length - spin);
                }
                case "x": {
                    var indexes = command.Substring(1).Split('/').Select(int.Parse).OrderBy(i => i).ToArray();
                    return
                        order.Substring(0, indexes.First()) +
                        order.Substring(indexes.Last(), 1) +
                        order.Substring(indexes.First() + 1, indexes.Last() - indexes.First() - 1) +
                        order.Substring(indexes.First(), 1) +
                        order.Substring(indexes.Last() + 1);
                }
                case "p": {
                    var indexes = command.Substring(1).Split('/').Select(i => order.IndexOf(i)).OrderBy(i => i).ToArray();
                    return
                        order.Substring(0, indexes.First()) +
                        order.Substring(indexes.Last(), 1) +
                        order.Substring(indexes.First() + 1, indexes.Last() - indexes.First() - 1) +
                        order.Substring(indexes.First(), 1) +
                        order.Substring(indexes.Last() + 1);
                }
                default:
                    return order;
            }
        }
    }
}
