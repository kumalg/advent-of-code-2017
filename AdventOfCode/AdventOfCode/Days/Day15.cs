using System;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day15 {
        private static void Main() {
            Console.WriteLine($" Part I: {PartOne(40_000_000, 516, 190)}");
            Console.WriteLine($"Part II: {PartTwo(5_000_000, 516, 190)}");
            Console.ReadKey();
        }

        public static int PartOne(long pairs, ulong aStart, ulong bStart) {
            var count = 0;
            var generatorAValue = aStart;
            var generatorBValue = bStart;
            const ulong generatorAFactor = 16807;
            const ulong generatorBFactor = 48271;
            const ulong mod = 2147483647;
            const ulong mod2 = 65536;
            for (var i = 0L; i < pairs; i++) {
                generatorAValue = (generatorAValue * generatorAFactor) % mod;
                generatorBValue = (generatorBValue * generatorBFactor) % mod;
                if (generatorAValue % mod2 == generatorBValue % mod2)
                    count++;
            }
            return count;
        }

        public static int PartTwo(long pairs, ulong aStart, ulong bStart) {
            var count = 0;
            var generatorAValue = aStart;
            var generatorBValue = bStart;
            const ulong generatorAFactor = 16807;
            const ulong generatorBFactor = 48271;
            const ulong mod = 2147483647;
            const ulong mod2 = 65536;
            for (var i = 0L; i < pairs; i++) {
                do
                    generatorAValue = (generatorAValue * generatorAFactor) % mod;
                while (generatorAValue % 4 != 0);

                do
                    generatorBValue = (generatorBValue * generatorBFactor) % mod;
                while (generatorBValue % 8 != 0);

                if (generatorAValue % mod2 == generatorBValue % mod2)
                    count++;
            }
            return count;
        }
    }
}
