//using System.Collections.Generic;
//using AdventOfCode.Days;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTests {
//    [TestClass]
//    public class Day03UnitTests {
//        [TestMethod]
//        public void FirstPart_1() {
//            var result = Day03.Spiral.CountSteps(1);
//            Assert.AreEqual(result, 0, $"result should be {0} but is {result}");
//        }

//        [TestMethod]
//        public void FirstPart_2() {
//            var result = Day03.Spiral.CountSteps(12);
//            Assert.AreEqual(result, 3, $"result should be {3} but is {result}");
//        }

//        [TestMethod]
//        public void FirstPart_3() {
//            var result = Day03.Spiral.CountSteps(23);
//            Assert.AreEqual(result, 2, $"result should be {2} but is {result}");
//        }

//        [TestMethod]
//        public void FirstPart_4() {
//            var result = Day03.Spiral.CountSteps(1024);
//            Assert.AreEqual(result, 31, $"result should be {31} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_1() {
//            var result = Day03.Spiral.ComputeNextNumber(10);
//            Assert.AreEqual(result, 11, $"result should be {11} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_2() {
//            var result = Day03.Spiral.ComputeNextNumber(26);
//            Assert.AreEqual(result, 54, $"result should be {54} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_3() {
//            var result = Day03.Spiral.ComputeNextNumber(133);
//            Assert.AreEqual(result, 142, $"result should be {142} but is {result}");
//        }
//    }
//}
