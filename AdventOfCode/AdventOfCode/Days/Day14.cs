//using System;
//using System.Linq;
//using System.Collections.Generic;
//using System.Collections.Immutable;

//namespace AdventOfCode.Days {
//    public class Day14 {
//        public static (int x, int y)[] Directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };
//        private static void Main() {
//            const string key = "ugkiagan";
//            //const string key = "flqrgnkx";

//            Console.WriteLine($" Part I: {PartOne(key)}");
//            Console.WriteLine($"Part II: {PartTwo(key)}");

//            Console.ReadKey();
//        }

//        public static string HexToBinary(string hexValue) {
//            ulong[] number = {
//                ulong.Parse(hexValue.Substring(0,16), System.Globalization.NumberStyles.HexNumber),
//                ulong.Parse(hexValue.Substring(16), System.Globalization.NumberStyles.HexNumber)
//            };

//            var bytes = BitConverter.GetBytes(number[0]).Reverse();
//            var bytes2 = BitConverter.GetBytes(number[1]).Reverse();

//            var binaryString = bytes.Aggregate(string.Empty, (current, b) => current + Convert.ToString(b, 2).PadLeft(8, '0'));
//            var result = bytes2.Aggregate(string.Empty, (current, b) => current + Convert.ToString(b, 2).PadLeft(8, '0'));
//            return binaryString + result;
//        }

//        public static bool[][] GenerateGrid(string key) {
//            var grid = new bool[128][];

//            for (var i = 0; i < 128; i++) {
//                grid[i] = new bool[128];
//                var letters = $"{key}-{i}".ToCharArray().Select(c => (int)c);
//                var bytes = HexToBinary(Day10.GetHash(letters, 256)).ToCharArray();
//                for (var j = 0; j < bytes.Length; j++)
//                    grid[i][j] = bytes[j] == '1';
//            }
//            return grid;
//        }

//        public static int PartOne(string key) => GenerateGrid(key).SelectMany(i => i).Count(i => i);

//        public static int PartTwo(string key) {
//            var grid2 = GenerateGrid(key)
//                .Select((row, yIndex) => row.Select((value, xIndex) => (value, x: xIndex, y: yIndex)))
//                .SelectMany(i => i).Where(i => i.value)
//                .Select(i => (i.x, i.y))
//                .ToList();

//            var count = 0;
//            while (grid2.Any()) {
//                count++;
//                GetGroup(grid2, grid2.First());
//            }

//            return count;
//        }

//        public static ImmutableList<(int x, int y)> GetGroup(List<(int x, int y)> grid, (int x, int y) first) {
//            var list = new[] { first }.ToImmutableList();
//            return GetNeighbours(grid, list, first);
//        }

//        public static ImmutableList<(int x, int y)> GetNeighbours(List<(int x, int y)> grid, ImmutableList<(int x, int y)> list, (int x, int y) first) {
//            grid.Remove(first);
//            var someList = list.Add(first);

//            foreach (var valueTuple in Directions) {
//                var value = (first.x + valueTuple.x, first.y + valueTuple.y);
//                if (!grid.Contains(value))
//                    continue;
//                grid.Remove(value);
//                someList = GetNeighbours(grid, someList, value);
//            }

//            return someList;
//        }
//    }
//}
