using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    class Day20_2016 {
        private static void Main(string[] args) {
            var blacklist = File.ReadAllText("../../Inputs/day20_2016.txt").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(i => i.Split('-').Select(uint.Parse).ToArray());
            Console.WriteLine($" Part I: {GetLowestValidIp(blacklist)}");
            Console.WriteLine($"Part II: {GetValidCount(blacklist, uint.MaxValue)}");
            Console.ReadKey();
        }

        private static uint GetLowestValidIp(IEnumerable<IEnumerable<uint>> blacklist) {
            var lowestValidIp = 0u;
            
            foreach (var blackRange in blacklist.OrderBy(i => i.Last()))
                if (lowestValidIp >= blackRange.ElementAt(0))
                    lowestValidIp = blackRange.ElementAt(1) + 1;

            return lowestValidIp;
        }

        private static long GetValidCount(IEnumerable<uint[]> blacklist, long maxValue) {
            var valid = 0;

            for (long i = 0; i <= maxValue; i++) {
                var includes = blacklist.Where(nums => i >= nums.ElementAt(0) && i <= nums.ElementAt(1));
                if (includes.Any())
                    i = includes.OrderBy(nums => nums.ElementAt(1)).First().ElementAt(1);
                else
                    valid++;
            }
            
            return valid;
        }
    }
}
