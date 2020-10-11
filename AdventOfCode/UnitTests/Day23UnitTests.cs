//using System.Collections.Generic;
//using AdventOfCode.Days;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace UnitTests {
//    [TestClass]
//    public class Day23UnitTests {
//        private readonly Dictionary<string, int> _registers = new Dictionary<string, int>
//        {
//            { "a", 12},
//            { "b", 33}
//        };

//        [TestMethod]
//        public void GetValueOfNumber() {
//            const string number = "23";
//            const int shoulBe = 23;
//            var result = _registers.GetValue(number);

//            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
//        }

//        [TestMethod]
//        public void GetValueOfRegister() {
//            const string register = "b";
//            const int shoulBe = 33;
//            var result = _registers.GetValue(register);

//            Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
//        }

//        //[TestMethod]
//        //public void GetValueOfNoRegister() {
//        //    const string register = "c";
//        //    const int shoulBe = 0;
//        //    var result = _registers.GetValue(register);

//        //    Assert.AreEqual(result, shoulBe, $"result should be {shoulBe} but is {result}");
//        //}
//    }
//}
