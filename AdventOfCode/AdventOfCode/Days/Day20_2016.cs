using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    class Day20_2016 {
        private static void Main(string[] args) {
            var blacklist = File.ReadAllText("../../Inputs/day20_2016.txt").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Split('-').Select(uint.Parse).ToArray());
            Console.WriteLine($" Part I: {GetLowestValidIp(blacklist, uint.MaxValue)}");
            Console.WriteLine($"Part II: {GetValidCount(blacklist, uint.MaxValue)}");
            Console.ReadKey();
        }

        private static long GetLowestValidIp(IEnumerable<IEnumerable<uint>> blacklist, long maxValue) {
            for (long i = 0; i <= maxValue; i++) {
                var includes = blacklist.Where(nums => i >= nums.ElementAt(0) && i <= nums.ElementAt(1));
                if (includes.Any())
                    i = includes.Select(nums => nums.ElementAt(1)).Min();
                else
                    return i;
            }

            return -1;
        }

        private static long GetValidCount(IEnumerable<uint[]> blacklist, long maxValue) {
            var valid = 0;

            for (long i = 0; i <= maxValue; i++) {
                var includes = blacklist.Where(nums => i >= nums.ElementAt(0) && i <= nums.ElementAt(1));
                if (includes.Any())
                    i = includes.Select(nums => nums.ElementAt(1)).Min();
                else
                    valid++;
            }
            
            return valid;
        }
    }
}
