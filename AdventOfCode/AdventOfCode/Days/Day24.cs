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
            Console.WriteLine($" Part I: {result.partOne}");
            Console.WriteLine($"Part II: {result.partTwo}");
            Console.ReadKey();
        }

        private static (int partOne, int partTwo) Compute(IEnumerable<IEnumerable<int>> componentsOriginal) {
            var components = componentsOriginal.ToList();
            var permutations = new List<(int strength, int lastPins, int components)>();

            var startComponents = components.Where(i => i.ElementAt(0) == 0);

            foreach (var startComponent in startComponents) {
                var bridge = (startComponent.Sum(), startComponent.Last(), 1);
                AddBridge(bridge, components.Where(i => !i.SequenceEqual(startComponent)).ToArray(), permutations);
            }

            return (
                permutations.OrderByDescending(i => i.strength).First().strength,
                permutations.OrderByDescending(i => i.components).ThenByDescending(i => i.strength).First().strength);
        }

        private static void AddBridge(
            (int strength, int lastPins, int components) bridge, 
            IEnumerable<IEnumerable<int>> components, 
            ICollection<(int strength, int lastPins, int components)> permutations) {

            permutations.Add(bridge);

            if (!components.Any())
                return;
            
            var matchedComponents = components.Where(i => i.Contains(bridge.lastPins));

            if (!matchedComponents.Any())
                return;

            foreach (var matchedComponent in matchedComponents) {
                var newBridge = bridge;
                newBridge.strength += matchedComponent.Sum();
                newBridge.components++;
                newBridge.lastPins = newBridge.lastPins != matchedComponent.ElementAt(0)
                    ? matchedComponent.Reverse().Last()
                    : matchedComponent.Last();

                AddBridge(newBridge, components.Where(i => !i.SequenceEqual(matchedComponent)).ToArray(), permutations);
            }
        }
    }
}
