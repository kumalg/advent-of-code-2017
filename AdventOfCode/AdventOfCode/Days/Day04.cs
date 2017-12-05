/*
--- Day 4: High-Entropy Passphrases ---

A new system policy has been put in place that requires all accounts to use a passphrase instead of simply a password. A passphrase consists of a series of words (lowercase letters) separated by spaces.

To ensure security, a valid passphrase must contain no duplicate words.

For example:

aa bb cc dd ee is valid.
aa bb cc dd aa is not valid - the word aa appears more than once.
aa bb cc dd aaa is valid - aa and aaa count as different words.
The system's full passphrase list is available as your puzzle input. How many passphrases are valid?

Your puzzle answer was 466.

--- Part Two ---

For added security, yet another system policy has been put in place. Now, a valid passphrase must contain no two words that are anagrams of each other - that is, a passphrase is invalid if any word's letters can be rearranged to form any other word in the passphrase.

For example:

abcde fghij is a valid passphrase.
abcde xyz ecdab is not valid - the letters from the third word can be rearranged to form the first word.
a ab abc abd abf abj is a valid passphrase, because all letters need to be used when forming another word.
iiii oiii ooii oooi oooo is valid.
oiii ioii iioi iiio is not valid - any of these words can be rearranged to form any other word.
Under this new system policy, how many passphrases are valid?

Your puzzle answer was 251.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days {
    public class Day04 {
        public static void Run() {
            var matrix = GetMatrix("../../Inputs/day04.txt");
            Console.WriteLine($" Part I: {Passphrase.CountValidPassphrasesForOne(matrix)}");
            Console.WriteLine($"Part II: {Passphrase.CountValidPassphrasesForTwo(matrix)}");
            Console.ReadKey();
        }

        static IEnumerable<IEnumerable<string>> GetMatrix(string fileName) {
            var matrix = new List<List<string>>();
            try {
                using (var sr = new StreamReader(fileName)) {
                    try {
                        var line = sr.ReadLine();
                        while (line != null) {
                            var lineArray = Regex.Split(line, @"\s+");
                            matrix.Add(lineArray.ToList());
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

        public class Passphrase {
            public static int CountValidPassphrasesForOne(IEnumerable<IEnumerable<string>> list) {
                return list.Count(sublist => sublist.All(new HashSet<string>().Add));
            }

            public static int CountValidPassphrasesForTwo(IEnumerable<IEnumerable<string>> list) {
                return list.Count(sublist => sublist.Select(word => new string(word.OrderBy(letter => letter)
                        .ToArray()))
                    .All(new HashSet<string>().Add));
            }
        }
    }
}
