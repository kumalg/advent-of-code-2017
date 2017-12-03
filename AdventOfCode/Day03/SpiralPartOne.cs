using System;

namespace Day03 {
    internal class SpiralPartOne {
        public static int CountSteps(int value) {
            var ring = (int)Math.Ceiling(Math.Sqrt(value));
            if (ring % 2 == 0)
                ring++;

            var maxValueInRing = ring * ring;

            var halfSteps = ring / 2;
            var maxSteps = halfSteps * 2;
            
            var steps = maxValueInRing - value;
            while (steps > maxSteps)
                steps -= maxSteps;

            return halfSteps + Math.Abs(steps - halfSteps);
        }
    }
}
