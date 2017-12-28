using System;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day14 {
        private static void Main() {
            const string key = "ugkiagan";

            Console.WriteLine($" Part I: {PartOne(key)}");

            Console.ReadKey();
        }

        public static string HexToBinary(string hexValue) {
            ulong[] number = {
                ulong.Parse(hexValue.Substring(0,16), System.Globalization.NumberStyles.HexNumber),
                ulong.Parse(hexValue.Substring(16), System.Globalization.NumberStyles.HexNumber)
            };

            var bytes = BitConverter.GetBytes(number[0]).Reverse();
            var bytes2 = BitConverter.GetBytes(number[1]).Reverse();

            var binaryString = bytes.Aggregate(string.Empty, (current, singleByte) => current + Convert.ToString(singleByte, 2));
            return bytes2.Aggregate(binaryString, (current, singleByte) => current + Convert.ToString(singleByte, 2));
        }

        public static bool[][] GenerateGrid(string key) {
            var grid = new bool[128][];

            for (var i = 0; i < 128; i++) {
                grid[i] = new bool[128];
                var letters = $"{key}-{i}".ToCharArray().Select(c => (int)c);
                var bytes = HexToBinary(Day10.GetHash(letters, 256)).ToCharArray();
                for (var j = 0; j < bytes.Length; j++)
                    grid[i][j] = bytes[j] == '1';
            }
            return grid;
        }

        public static int PartOne(string key) => GenerateGrid(key).SelectMany(i => i).Count(i => i);
    }
}
