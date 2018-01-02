using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day23 {
        public static readonly IEnumerable<string[]> Instructions = File.ReadAllText("../../Inputs/day23.txt")
            .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(i => i.Split(' '));
        private static void Main() {
           
            //Console.WriteLine(PartOne());
            Console.WriteLine(PartTwo());
            Console.ReadKey();
        }

        private static int PartOne() {
            var registers = new Dictionary<string, int> {
                { "a", 0}, { "b", 0}, { "c", 0}, { "d", 0}, { "e", 0}, { "f", 0}, { "g", 0}, { "h", 0}
            };
            var actualInstructionIndex = 0;
            var numberOfInstructions = Instructions.Count();
            var muls = 0;

            while (actualInstructionIndex < numberOfInstructions) {
                var actualInstriction = Instructions.ElementAt(actualInstructionIndex);
                var type = actualInstriction[0];
                var register = actualInstriction[1];
                var value = GetValue(registers, actualInstriction[2]);
                switch (type) {
                    case "set":
                    registers[register] = value;
                    break;
                    case "sub":
                    registers[register] -= value;
                    break;
                    case "mul":
                    muls++;
                    registers[register] *= value;
                    break;
                    case "jnz":
                    if (GetValue(registers, register) != 0) {
                        actualInstructionIndex += value;
                        continue;
                    }
                    break;
                }
                actualInstructionIndex++;
            }
            return muls;
        }
        private static int PartTwo() {
            var registers = new Dictionary<string, int> {
                { "a", 1}, { "b", 0}, { "c", 0}, { "d", 0}, { "e", 0}, { "f", 0}, { "g", 0}, { "h", 0}
            };
            var actualInstructionIndex = 0;
            var numberOfInstructions = Instructions.Count();

            var bylo = false;
            var bylo2 = false;

            while (actualInstructionIndex < numberOfInstructions) {
                var actualInstriction = Instructions.ElementAt(actualInstructionIndex);

                if (actualInstructionIndex == 16 && !bylo) {
                    bylo = true;
                    registers["e"] = 1;
                    registers["d"] = 0;
                    registers["b"] = 1;
                    actualInstructionIndex++;
                    continue;
                }

                //if (actualInstructionIndex == 20 && !bylo2) {
                //    bylo2 = true;
                //    registers["d"] = registers["b"];
                //    actualInstructionIndex++;
                //    continue;
                //}

                var type = actualInstriction[0];
                var register = actualInstriction[1];
                var value = GetValue(registers, actualInstriction[2]);
                switch (type) {
                    case "set":
                    registers[register] = value;
                    break;
                    case "sub":
                    registers[register] -= value;
                    break;
                    case "mul":
                    registers[register] *= value;
                    break;
                    case "jnz":
                    if (GetValue(registers, register) != 0) {
                        actualInstructionIndex += value;
                        continue;
                    }
                    break;
                }
                actualInstructionIndex++;

                if (register == "h")
                  Console.WriteLine(registers["h"]);
            }
            Console.WriteLine("End");
            return registers["h"];
        }
        public static int GetValue(Dictionary<string, int> registers, string register) {
            var isNumeric = int.TryParse(register, out var n);
            return isNumeric ? n : registers[register];
        }
    }
}
