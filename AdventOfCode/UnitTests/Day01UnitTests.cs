//using AdventOfCode.Days;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTests {
//    [TestClass]
//    public class Day01UnitTests {
//        [TestMethod]
//        public void FirstPart_1() {
//            var sequence = new[] { 1, 1, 2, 2 };
//            var result = Day01.Captcha.ComputeCaptchaPartOne(sequence);

//            Assert.AreEqual(result, 3, $"result should be {3} but is {result}");
//        }

//        [TestMethod]
//        public void FirstPart_2() {
//            var sequence = new[] { 1, 1, 1, 1 };
//            var result = Day01.Captcha.ComputeCaptchaPartOne(sequence);

//            Assert.AreEqual(result, 4, $"result should be {4} but is {result}");
//        }

//        [TestMethod]
//        public void FirstPart_3() {
//            var sequence = new[] { 1, 2, 3, 4 };
//            var result = Day01.Captcha.ComputeCaptchaPartOne(sequence);

//            Assert.AreEqual(result, 0, $"result should be {0} but is {result}");
//        }

//        [TestMethod]
//        public void FirstPart_4() {
//            var sequence = new[] { 9, 1, 2, 1, 2, 1, 2, 9 };
//            var result = Day01.Captcha.ComputeCaptchaPartOne(sequence);

//            Assert.AreEqual(result, 9, $"result should be {9} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_1() {
//            var sequence = new[] { 1, 2, 1, 2 };
//            var result = Day01.Captcha.ComputeCaptchaPartTwo(sequence);

//            Assert.AreEqual(result, 6, $"result should be {6} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_2() {
//            var sequence = new[] { 1, 2, 2, 1 };
//            var result = Day01.Captcha.ComputeCaptchaPartTwo(sequence);

//            Assert.AreEqual(result, 0, $"result should be {0} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_3() {
//            var sequence = new[] { 1, 2, 3, 4, 2, 5 };
//            var result = Day01.Captcha.ComputeCaptchaPartTwo(sequence);

//            Assert.AreEqual(result, 4, $"result should be {4} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart_4() {
//            var sequence = new[] { 1, 2, 3, 1, 2, 3 };
//            var result = Day01.Captcha.ComputeCaptchaPartTwo(sequence);

//            Assert.AreEqual(result, 12, $"result should be {12} but is {result}");
//        }


//        [TestMethod]
//        public void SecondPart_5() {
//            var sequence = new[] { 1, 2, 1, 3, 1, 4, 1, 5 };
//            var result = Day01.Captcha.ComputeCaptchaPartTwo(sequence);

//            Assert.AreEqual(result, 4, $"result should be {4} but is {result}");
//        }
//    }
//}
