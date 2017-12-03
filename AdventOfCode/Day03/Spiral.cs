using System;

namespace Day03 {
    internal class Spiral {
        public static int ComputeStepsCount(int number) {
            var ringNumber = (int)Math.Ceiling(Math.Sqrt(number));
            if (ringNumber % 2 == 0)
                ringNumber++;

            var rightDownValueInRing = (int)Math.Pow(ringNumber, 2);
            var leftDownValueInRing = rightDownValueInRing - ringNumber + 1;
            var leftUpValueInRing = rightDownValueInRing - 2 * ringNumber + 2;
            var rightUpValueInRing = rightDownValueInRing - 3 * ringNumber + 3;

            if (number == rightDownValueInRing ||
                number == leftDownValueInRing ||
                number == leftUpValueInRing ||
                number == rightUpValueInRing) {
                return (int)Math.Pow(ringNumber - 1, 2);
            }

            var halfFloor = (int)Math.Floor(ringNumber / 2.0);
            int rest;

            if (number > leftDownValueInRing && number < rightDownValueInRing)
                rest = (rightDownValueInRing - number);
            else if (number > leftUpValueInRing && number < leftDownValueInRing)
                rest = (leftDownValueInRing - number);
            else if (number > rightUpValueInRing && number < leftUpValueInRing)
                rest = (leftUpValueInRing - number);
            else
                rest = (rightUpValueInRing - number);

            rest = Math.Abs(rest - halfFloor);
            return halfFloor + rest;
        }
    }
}
