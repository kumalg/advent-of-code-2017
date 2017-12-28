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
            
            Console.WriteLine($" Part I: {PartOne(instructions)}");
            Console.WriteLine($"Part II: {PartTwo(instructions)}");
            Console.ReadKey();
        }

        private static long PartOne(IEnumerable<string[]> instructions) {
            var registers = instructions.Select(i => i[1][0]).Distinct().Where(r => r >= 'a' && r <= 'z').ToDictionary(r => r.ToString(), r => 0L);
            var actualInstructionIndex = 0;
            var numberOfInstructions = instructions.Count();
            var freq = 0L;

            while (actualInstructionIndex < numberOfInstructions) {
                var actualInstriction = instructions.ElementAt(actualInstructionIndex);
                var type = actualInstriction[0];
                var register = actualInstriction[1];
                var value = actualInstriction.Length > 2 ? GetValue(registers, actualInstriction[2]) : 0L;
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
                        if (GetValue(registers, register) != 0)
                            return freq;
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

        private static long PartTwo(IEnumerable<string[]> instructions) {
            var registers = instructions.Select(i => i[1][0]).Distinct().Where(r => r >= 'a' && r <= 'z').ToDictionary(r => r.ToString(), r => 0L);
            var programs = new[] { new Program(0, registers.ToDictionary(i => i.Key, i => i.Value)), new Program(1, registers.ToDictionary(i => i.Key, i => i.Value)) };
            var numberOfInstructions = instructions.Count();
            int sends = 0;

            while (programs[1].ActualIndex < numberOfInstructions) {
                if (programs[0].Waiting && programs[1].Waiting)
                    return sends;
                foreach (var program in programs) {
                    program.Waiting = false;
                    var actualInstriction = instructions.ElementAt(program.ActualIndex);
                    var type = actualInstriction[0];
                    var register = actualInstriction[1];
                    var value = actualInstriction.Length > 2 ? GetValue(program.Registers, actualInstriction[2]) : 0L;
                    switch (type) {
                        case "snd":
                            program.Sends.Add(GetValue(program.Registers, register));
                            if (program.Id == 1)
                                sends++;
                            break;
                        case "set":
                            program.Registers[register] = value;
                            break;
                        case "add":
                            program.Registers[register] += value;
                            break;
                        case "mul":
                            program.Registers[register] *= value;
                            break;
                        case "mod":
                            program.Registers[register] %= value;
                            break;
                        case "rcv":
                            var received = programs[(program.Id + 1) % 2].Send();
                            if (received == null) {
                                program.Waiting = true;
                                continue;
                            }
                            program.Registers[register] = received.Value;
                            break;
                        case "jgz":
                            if (GetValue(program.Registers, register) > 0) {
                                program.ActualIndex += (int)value;
                                continue;
                            }
                            break;
                    }
                    program.ActualIndex++;
                }
            }
            return 0;
        }

        public class Program {
            public int Id;
            public int ActualIndex;
            public bool Waiting;
            public Dictionary<string, long> Registers;
            public List<long> Sends = new List<long>();

            public Program(int id, Dictionary<string, long> registers) {
                Registers = registers;
                Registers["p"] = Id = id;
            }

            public long? Send() {
                if (Sends.Count == 0)
                    return null;
                var output = Sends.First();
                Sends.RemoveAt(0);
                return output;
            }
        }

        public static long GetValue(Dictionary<string, long> registers, string register) {
            var isNumeric = long.TryParse(register, out var n);
            return isNumeric ? n : registers[register];
        }
    }
}
