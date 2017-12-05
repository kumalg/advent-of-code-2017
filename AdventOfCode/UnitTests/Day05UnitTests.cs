using System.Collections.Generic;
using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests {
    [TestClass]
    public class Day05UnitTests {
        [TestMethod]
        public void FirstPartResult() {
            var instructions = new List<int> { 0, 3, 0, 1, -3 };
            var result = Day05.Instructions.CountStepsForOne(instructions).Key;

            Assert.AreEqual(result, 5, "result should be 5 but is " + result);
        }

        [TestMethod]
        public void FirstPartList() {
            var instructions = new List<int> { 0, 3, 0, 1, -3 };
            var list = new List<int> { 2, 5, 0, 1, -2 };
            var result = Day05.Instructions.CountStepsForOne(instructions).Value;

            CollectionAssert.AreEqual(result, list, $"result should be {{ 2, 5, 0, 1, -2 }} but is {{ {string.Join(", ", result.ToArray())} }}");
        }

        [TestMethod]
        public void SecondPartResult() {
            var instructions = new List<int> { 0, 3, 0, 1, -3 };
            var result = Day05.Instructions.CountStepsForTwo(instructions).Key;

            Assert.AreEqual(result, 10, "result should be 10 but is " + result);
        }

        [TestMethod]
        public void SecondPartList() {
            var instructions = new List<int> { 0, 3, 0, 1, -3 };
            var list = new List<int> { 2, 3, 2, 3, -1 };
            var result = Day05.Instructions.CountStepsForTwo(instructions).Value;

            CollectionAssert.AreEqual(result, list, $"result should be {{ 2, 3, 2, 3, -1 }} but is {{ {string.Join(", ", result.ToArray())} }}");
        }
    }
}
