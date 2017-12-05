﻿/*
--- Day 2: Corruption Checksum ---

As you walk through the door, a glowing humanoid shape yells in your direction. "You there! Your state appears to be idle. Come help us repair the corruption in this spreadsheet - if we take another millisecond, we'll have to display an hourglass cursor!"

The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's checksum. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.

For example, given the following spreadsheet:

5 1 9 5
7 5 3
2 4 6 8
The first row's largest and smallest values are 9 and 1, and their difference is 8.
The second row's largest and smallest values are 7 and 3, and their difference is 4.
The third row's difference is 6.
In this example, the spreadsheet's checksum would be 8 + 4 + 6 = 18.

What is the checksum for the spreadsheet in your puzzle input?

Your puzzle answer was 32121.

--- Part Two ---

"Great work; looks like we're on the right track after all. Here's a star for your effort." However, the program seems a little worried. Can programs be worried?

"Based on what we're seeing, it looks like all the User wanted is some information about the evenly divisible values in the spreadsheet. Unfortunately, none of us are equipped for that kind of calculation - most of us specialize in bitwise operations."

It sounds like the goal is to find the only two numbers in each row where one evenly divides the other - that is, where the result of the division operation is a whole number. They would like you to find those numbers on each line, divide them, and add up each line's result.

For example, given the following spreadsheet:

5 9 2 8
9 4 7 3
3 8 6 5
In the first row, the only two numbers that evenly divide are 8 and 2; the result of this division is 4.
In the second row, the two numbers are 9 and 3; the result is 3.
In the third row, the result is 2.
In this example, the sum of the results would be 4 + 3 + 2 = 9.

What is the sum of each row's result in your puzzle input?

Your puzzle answer was 197.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days {
    public class Day02 {
        public static void Run() {
            var matrix = GetMatrix("../../Inputs/day02.txt");
            Console.WriteLine($" Part I: {Checksum.ComputeChecksumPartOne(matrix)}");
            Console.WriteLine($"Part II: {Checksum.ComputeChecksumPartTwo(matrix)}");
            Console.ReadKey();
        }

        static IEnumerable<IEnumerable<int>> GetMatrix(string fileName) {
            var matrix = new List<List<int>>();
            try {
                using (var sr = new StreamReader(fileName)) {
                    try {
                        var line = sr.ReadLine();
                        while (line != null) {
                            var lineArray = Regex.Split(line, @"\s+");
                            var newList = lineArray.Select(int.Parse).ToList();
                            matrix.Add(newList);
                            line = sr.ReadLine();
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return matrix;
        }

        public class Checksum {
            public static int ComputeChecksumPartOne(IEnumerable<IEnumerable<int>> matrix) {
                return matrix.Select(i => i.Max() - i.Min()).Sum();
            }

            public static int ComputeChecksumPartTwo(IEnumerable<IEnumerable<int>> matrix) {
                var result = 0;
                foreach (var row in matrix) {
                    var rowResult = 0;
                    var rowSorted = row.OrderByDescending(i => i);
                    for (var i = 0; i < rowSorted.Count(); i++) {
                        for (var j = i + 1; j < rowSorted.Count(); j++) {
                            if (rowSorted.ElementAt(i) % rowSorted.ElementAt(j) != 0) continue;
                            rowResult = (rowSorted.ElementAt(i) / rowSorted.ElementAt(j));
                            break;
                        }
                        if (rowResult == 0) continue;
                        result += rowResult;
                        break;
                    }
                }
                return result;
            }
        }
    }
}