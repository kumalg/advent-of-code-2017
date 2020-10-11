//using System;
//using System.Collections.Immutable;
//using System.Linq;

//namespace AdventOfCode.Days {
//    public class Day17 {
//        public static int Input = 345;
//        private static void Main() {
//            Console.WriteLine($" Part I: {PartOne(Input)}");
//            Console.WriteLine($"Part II: {PartTwo(Input)}");
//            Console.ReadKey();
//        }

//        public static (ImmutableList<int> list, int index) GetList(int steps, int lastValue) {
//            return Enumerable
//                .Range(1, lastValue)
//                .Aggregate((list: new[] { 0 }.ToImmutableList(), index: 0),
//                    (a, b) => (a.list.Insert(a.index = (a.index + steps) % a.list.Count + 1, b), a.index));
//        }

//        public static int PartOne(int steps) {
//            var list = GetList(steps, 2017);
//            return list.list.ElementAt(list.index + 1);
//        }

//        public static int PartTwo(int steps) {
//            var list = GetList(steps, 50_000_000);
//            return list.list.ElementAt(list.list.IndexOf(0) + 1);
//        }
//    }
//}
