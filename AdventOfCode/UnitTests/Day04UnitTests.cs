//using System.Collections.Generic;
//using AdventOfCode.Days;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTests {
//    [TestClass]
//    public class Day04UnitTests {
//        [TestMethod]
//        public void FirstPart() {
//            var list = new List<IEnumerable<string>>
//            {
//                "aa bb cc dd ee".Split(' '),
//                "aa bb cc dd aa".Split(' '),
//                "aa bb cc dd aaa".Split(' ')
//            };
//            var result = Day04.Passphrase.CountValidPassphrasesForOne(list);
//            Assert.AreEqual(result, 2, $"result should be {2} but is {result}");
//        }

//        [TestMethod]
//        public void SecondPart() {
//            var list = new List<IEnumerable<string>>
//            {
//                "abcde fghij".Split(' '),
//                "abcde xyz ecdab".Split(' '),
//                "a ab abc abd abf abj".Split(' '),
//                "iiii oiii ooii oooi oooo".Split(' '),
//                "oiii ioii iioi iiio".Split(' '),
//            };
//            var result = Day04.Passphrase.CountValidPassphrasesForTwo(list);
//            Assert.AreEqual(result, 3, $"result should be {3} but is {result}");
//        }
//    }
//}
