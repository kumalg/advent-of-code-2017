using AdventOfCode.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests {
    [TestClass]
    public class Day09UnitTests {
        [TestMethod]
        public void FirstPart_1() {
            const string input = "{}";
            const int shoulBe = 1;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_2() {
            const string input = "{{{}}}";
            const int shoulBe = 6;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_3() {
            const string input = "{{},{}}";
            const int shoulBe = 5;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_4() {
            const string input = "{{{},{},{{}}}}";
            const int shoulBe = 16;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_5() {
            const string input = "{<a>,<a>,<a>,<a>}";
            const int shoulBe = 1;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_6() {
            const string input = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
            const int shoulBe = 9;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_7() {
            const string input = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
            const int shoulBe = 9;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }

        [TestMethod]
        public void FirstPart_8() {
            const string input = "{{<a!>},{<a!>},{<a!>},{<ab>}}";
            const int shoulBe = 3;
            var result = Day09.CountTotalScore(input);

            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
        }
    }
}
