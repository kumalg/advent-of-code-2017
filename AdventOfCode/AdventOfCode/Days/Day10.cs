using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day10 {
        private static void Main() {
            var input = File.ReadAllText("../../Inputs/day10.txt");

            Console.WriteLine($" Part I: {GetMultiply(input.Split(',').Select(int.Parse), 256)}");
            Console.WriteLine($"Part II: {GetHash(input.Replace("\n", "").ToCharArray().Select(i => (int)i), 256)}");

            Console.ReadKey();
        }

        private static int GetMultiply(IEnumerable<int> lengths, int size) {
            var permutation = GetPermutation(lengths, size, 1);
            return permutation.ElementAt(0) * permutation.ElementAt(1);
        }

        private static IEnumerable<int> GetPermutation(IEnumerable<int> lengths, int size, int rounds) {
            var permutation = Enumerable.Range(0, size).ToArray();

            var position = 0;
            var skipSize = 0;

            for (var round = 0; round < rounds; round++) {
                foreach (var length in lengths) {
                    var maxIndex = length - 1;
                    for (var i = 0; i < length / 2; i++)
                        Swap(ref permutation[(i + position) % permutation.Length],
                            ref permutation[(maxIndex-- + position) % permutation.Length]);
                    position += length + skipSize++;
                }
            }

            return permutation;
        }

        public static string GetHash(IEnumerable<int> lengths, int size) {
            var newLengths = lengths.Concat(new[] { 17, 31, 73, 47, 23 }).ToArray();
            var permutation = GetPermutation(newLengths, size, 64);

            var output = string.Empty;
            for (var i = 0; i < 16; i++)
                output += permutation
                    .Skip(i * 16)
                    .Take(16)
                    .Aggregate((total, next) => total ^ next)
                    .ToString("x2");

            return output;
        }

        public static void Swap<T>(ref T lhs, ref T rhs) {
            var temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
