using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day24 {
        private static void Main() {
            var components = File.ReadAllText("../../Inputs/day24.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Split('/').Select(int.Parse));

            var result = Compute(components);
            Console.WriteLine($" Part I: {result.Item1}");
            Console.WriteLine($"Part II: {result.Item2}");
            Console.ReadKey();
        }

        private static (int, int) Compute(IEnumerable<IEnumerable<int>> componentsOriginal) {
            var components = componentsOriginal.ToList();
            var permutations = new List<List<IEnumerable<int>>>();

            var startComponents = components.Where(i => i.ElementAt(0) == 0);

            foreach (var startComponent in startComponents) {
                var bridge = new List<IEnumerable<int>> { startComponent };
                AddBridge(bridge, components.Where(i => !i.SequenceEqual(startComponent)).ToArray(), permutations);
            }

            var strengths = permutations.Select(i => (strength : i.Select(x => x.Sum()).Sum(), length: i.Count));
            return (
                strengths.OrderByDescending(i => i.strength).First().strength, 
                strengths.GroupBy(i => i.length).OrderByDescending(i => i.Key).First().OrderByDescending(i => i.strength).First().strength);

        }

        private static void AddBridge(List<IEnumerable<int>> bridge, IEnumerable<IEnumerable<int>> components, ICollection<List<IEnumerable<int>>> permutations) {
            permutations.Add(bridge);

            if (!components.Any())
                return;

            var lastComponent = bridge.Last();
            var matchedComponents = components.Where(i => i.Contains(lastComponent.ElementAt(1)));

            if (!matchedComponents.Any())
                return;

            foreach (var matchedComponent in matchedComponents) {
                var newBridge = bridge.ToList();
                newBridge.Add(newBridge.Last().ElementAt(1) != matchedComponent.ElementAt(0)
                    ? matchedComponent.Reverse()
                    : matchedComponent);
                AddBridge(newBridge, components.Where(i => !i.SequenceEqual(matchedComponent)).ToArray(), permutations);
            }
        }
    }
}
