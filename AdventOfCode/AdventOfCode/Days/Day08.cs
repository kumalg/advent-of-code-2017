using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day08 {
        private static void Main() {
            var instructions = File.ReadAllText("../../Inputs/day08.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Split(' '));

            var result = MaxValueInRegisters(instructions);
            Console.WriteLine(result.Item1);
            Console.WriteLine(result.Item2);
            Console.ReadKey();
        }
        
        private static (int, int) MaxValueInRegisters(IEnumerable<string[]> instructions) {
            var registers = new Dictionary<string, int>();
            var maxEver = 0;

            foreach (var instruction in instructions) {
                if (!registers.ContainsKey(instruction[0]))
                    registers.Add(instruction[0], 0);
                if (!registers.ContainsKey(instruction[4]))
                    registers.Add(instruction[4], 0);

                var condition = false;
                if (instruction[5] == "<")
                    condition = registers[instruction[4]] < int.Parse(instruction[6]);
                else if (instruction[5] == "<=")
                    condition = registers[instruction[4]] <= int.Parse(instruction[6]);
                else if (instruction[5] == "==")
                    condition = registers[instruction[4]] == int.Parse(instruction[6]);
                else if (instruction[5] == ">=")
                    condition = registers[instruction[4]] >= int.Parse(instruction[6]);
                else if (instruction[5] == ">")
                    condition = registers[instruction[4]] > int.Parse(instruction[6]);
                else if (instruction[5] == "!=")
                    condition = registers[instruction[4]] != int.Parse(instruction[6]);

                if (condition)
                    registers[instruction[0]] += instruction[1] == "inc"
                        ? int.Parse(instruction[2])
                        : -int.Parse(instruction[2]);

                if (registers[instruction[0]] > maxEver)
                    maxEver = registers[instruction[0]];
            }
            return (registers.Values.Max(), maxEver);
        }
    }
}
