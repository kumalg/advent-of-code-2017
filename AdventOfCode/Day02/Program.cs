using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day02 {
    class Program {
        static void Main(string[] args) {
            var matrix = GetMatrix("input.txt");
            var result = Checksum.ComputeChecksumFor2(matrix);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        static IEnumerable<IEnumerable<int>> GetMatrix(string fileName) {
            var matrix = new List<List<int>>();
            try {
                using (var sr = new StreamReader(fileName)) {
                    try {
                        string line = sr.ReadLine();
                        int iterator = 0;
                        while (line != null) {
                            List<int> newList = new List<int>();
                            var lineArray = Regex.Split(line, @"\s+");

                            foreach (var numberString in lineArray)
                                newList.Add(int.Parse(numberString));
                            matrix.Add(newList);

                            iterator++;
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
    }
}
