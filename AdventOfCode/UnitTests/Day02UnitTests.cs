using System.Collections.Generic;
using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests {
    [TestClass]
    public class Day02UnitTests {
        [TestMethod]
        public void FirstPart() {
            var spreadsheet =
                new List<IEnumerable<int>>{
                    new List<int>{ 5, 1, 9, 5 },
                    new List<int>{ 7, 5, 3 },
                    new List<int> { 2, 4, 6, 8 }
                };
            var result = Day02.Checksum.ComputeChecksumPartOne(spreadsheet);

            Assert.AreEqual(result, 18, $"result should be {18} but is {result}");
        }

        [TestMethod]
        public void SecondPart() {
            var spreadsheet =
                new List<IEnumerable<int>>{
                    new List<int>{ 5, 9, 2, 8 },
                    new List<int>{ 9, 4, 7, 3 },
                    new List<int> { 3, 8, 6, 5 }
                };
            var result = Day02.Checksum.ComputeChecksumPartTwo(spreadsheet);

            Assert.AreEqual(result, 9, $"result should be {9} but is {result}");
        }
    }
}
