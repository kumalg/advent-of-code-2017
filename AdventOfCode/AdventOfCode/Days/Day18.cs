using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day18 {
        private static void Main() {
            var instructions = File.ReadAllText("../../Inputs/day18.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Split(' '));

            var result = PartOne(instructions);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static long PartOne(IEnumerable<string[]> instructions) {
            var registers = instructions.Select(i => i[1][0]).Distinct().Where(r => r >= 'a' && r <= 'z').ToDictionary(r => r.ToString(), r => 0l);
            var actualInstructionIndex = 0;
            var numberOfInstructions = instructions.Count();
            var freq = 0l;

            while (actualInstructionIndex < numberOfInstructions) {
                var actualInstriction = instructions.ElementAt(actualInstructionIndex);
                var type = actualInstriction[0];
                var register = actualInstriction[1];
                var value = actualInstriction.Length > 2 ? GetValue(registers, actualInstriction[2]) : 0l;
                switch (type) {
                    case "snd":
                        freq = GetValue(registers, register);
                        break;
                    case "set":
                        registers[register] = value;
                        break;
                    case "add":
                        registers[register] += value;
                        break;
                    case "mul":
                        registers[register] *= value;
                        break;
                    case "mod":
                        registers[register] %= value;
                        break;
                    case "rcv":
                        if (GetValue(registers, register) != 0) {
                            return freq;
                        }
                        break;
                    case "jgz":
                        if (GetValue(registers, register) > 0) {
                            actualInstructionIndex += (int)value;
                            continue;
                        }
                        break;
                }
                actualInstructionIndex++;
            }
            return 0;
        }

        public static long GetValue(Dictionary<string, long> registers, string register) {
            var isNumeric = long.TryParse(register, out var n);
            return isNumeric ? n : registers[register];
        }
    }
}
