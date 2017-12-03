using System;

namespace Day03 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine($" Part I: {Spiral.ComputeStepsCount(277678)}");
            Console.WriteLine($"Part II: {SpiralFor2.ComputeNextNumber(277678)}");
            Console.ReadKey();
        }
    }
}
