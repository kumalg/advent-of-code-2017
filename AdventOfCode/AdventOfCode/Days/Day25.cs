using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day25 {
        private static void Main() {
            var lines = File.ReadAllText("../../Inputs/day25.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($" Part I: {PartOne(lines)}");
            Console.WriteLine($"Part II: {1}");
            Console.ReadKey();
        }

        private static int PartOne(string[] lines) {
            var states = new Dictionary<string, StateInstructions>();
            var state = lines[0].Split(' ').Last().Replace(".", "");
            var steps = int.Parse(lines[1].Split(' ').Reverse().ElementAt(1));
            var tape = new Dictionary<int, int>();
            var slotIndex = 0;

            var stateIndexes = lines.Select((i, index) => new KeyValuePair<int, string>(index, i))
                .Where(i => i.Value.StartsWith("In state")).Select(i => i.Key);

            foreach (var stateIndex in stateIndexes) {
                var stateInstructions = new StateInstructions {
                    Zero = Instructions.Parse(lines.Skip(stateIndex + 2).Take(3)),
                    One = Instructions.Parse(lines.Skip(stateIndex + 6).Take(3))
                };
                states.Add(lines[stateIndex].Split(' ').Last().Replace(":", ""), stateInstructions);
            }

            for (var i = 0; i < steps; i++) {
                if (!tape.ContainsKey(slotIndex))
                    tape.Add(slotIndex, 0);

                var instructions = tape[slotIndex] == 0
                    ? states[state].Zero
                    : states[state].One;

                tape[slotIndex] = instructions.Value;
                slotIndex += instructions.SlotOffset;
                state = instructions.NextState;
            }

            return tape.Values.Count(i => i == 1);
        }

        public class StateInstructions {
            public Instructions Zero;
            public Instructions One;
        }

        public class Instructions {
            public int Value;
            public int SlotOffset;
            public string NextState;

            public static Instructions Parse(IEnumerable<string> lines) {
                return new Instructions {
                    Value = int.Parse(lines.ElementAt(0).Split(' ').Last().Replace(".", "")),
                    SlotOffset = lines.ElementAt(1).EndsWith("right.") ? 1 : -1,
                    NextState = lines.ElementAt(2).Split(' ').Last().Replace(".", "")
                };
            }
        }
    }
}
