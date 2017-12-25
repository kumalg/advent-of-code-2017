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
            var bridges = new List<Bridge>();

            var startComponents = components.Where(i => i.ElementAt(0) == 0);

            foreach (var startComponent in startComponents) {
                var bridge = new Bridge {
                    Strength = startComponent.Sum(),
                    LastPins = startComponent.Last(),
                    Components = 1
                };
                AddBridge(bridge, components.Where(i => !i.SequenceEqual(startComponent)).ToArray(), bridges);
            }

            return (
                bridges.OrderByDescending(i => i.Strength).First().Strength,
                bridges.OrderByDescending(i => i.Components).ThenByDescending(i => i.Strength).First().Strength);
        }

        private static void AddBridge(Bridge bridge, IEnumerable<IEnumerable<int>> components, ICollection<Bridge> bridges) {
            bridges.Add(bridge);

            if (!components.Any())
                return;

            var matchedComponents = components.Where(i => i.Contains(bridge.LastPins));

            if (!matchedComponents.Any())
                return;

            foreach (var matchedComponent in matchedComponents) {
                var newBridge = new Bridge {
                    Strength = bridge.Strength + matchedComponent.Sum(),
                    Components = bridge.Components + 1,
                    LastPins = bridge.LastPins != matchedComponent.ElementAt(0)
                        ? matchedComponent.Reverse().Last()
                        : matchedComponent.Last()
                };

                AddBridge(newBridge, components.Where(i => !i.SequenceEqual(matchedComponent)).ToArray(), bridges);
            }
        }

        public class Bridge {
            public int Strength;
            public int LastPins;
            public int Components;
        }
    }
}
