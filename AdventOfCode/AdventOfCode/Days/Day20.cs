using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days {
    public class Day20 {
        private static void Main() {
            var particles = File.ReadAllText("../../Inputs/day20.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => Regex
                                .Split(i, @"(, )")
                                .Where(x => x != ", ")
                                .Select(y => new KeyValuePair<char, int[]>(y.First(), y
                                    .Substring(3)
                                    .Replace(">", " ")
                                    .Split(',')
                                    .Select(int.Parse)
                                    .ToArray()))
                                .ToDictionary(node => node.Key, node => node.Value)).ToArray();

            //Console.WriteLine(PartOne(particles));
            Console.WriteLine(PartTwo(particles));

            Console.ReadKey();
        }

        public static int PartOne(Dictionary<char, int[]>[] particlesOriginal) {
            var particles = particlesOriginal.Select(i => i.ToDictionary(x => x.Key, x => x.Value)).ToArray();
            var loops = 1000;
            for (var i = 0; i < loops; i++) {
                for (var particleIndex = 0; particleIndex < particles.Count(); particleIndex++) {
                    for (var dim = 0; dim < 3; dim++) {
                        particles[particleIndex]['v'][dim] += particles[particleIndex]['a'][dim];
                        particles[particleIndex]['p'][dim] += particles[particleIndex]['v'][dim];
                    }
                }
            }
            var particle = particles.Select((i, index) => new KeyValuePair<int,int>(index, i['p'].Select(Math.Abs).Sum())).OrderBy(i => i.Value).First();
            return particle.Key;
        }


        public static int PartTwo(Dictionary<char, int[]>[] particlesOriginal) {
            var particles = particlesOriginal.Select(i => i.ToDictionary(x => x.Key, x => x.Value)).ToArray();
            var skipList = new HashSet<int>();
            var loops = 1000;
            for (var i = 0; i < loops; i++) {

                var multiples = particles.Select((x, index) => (string.Join(",", x['p']), index))
                    .Where(x => !skipList.Contains(x.Item2))
                    .GroupBy(p => p.Item1).Where(x => x.Count() > 1);

                if (multiples.Any()) {
                    foreach (var multiple in multiples) {
                        foreach (var valueTuple in multiple)
                            skipList.Add(valueTuple.Item2);
                    }
                }

                for (var particleIndex = 0; particleIndex < particles.Count(); particleIndex++) {
                    if (skipList.Contains(particleIndex))
                        continue;

                    for (var dim = 0; dim < 3; dim++) {
                        particles[particleIndex]['v'][dim] += particles[particleIndex]['a'][dim];
                        particles[particleIndex]['p'][dim] += particles[particleIndex]['v'][dim];
                    }
                }
                
            }
            return particles.Length - skipList.Count;
        }
    }
}
