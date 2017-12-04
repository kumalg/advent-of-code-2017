using System;

namespace Day03 {
    internal class SpiralPartTwo {
        public static int ComputeNextNumber(int number) {
            var ring = (int)Math.Ceiling(Math.Sqrt(number));
            var matrix = new int[ring, ring];

            var center = ring / 2;

            matrix[center, center] = 1;
            var col = center;
            var row = center;

            for (var i = 1; i <= ring; i++) {
                var offset = IsOdd(i) ? 1 : -1;

                for (var j = 0; j < 2; j++) {
                    for (var k = 0; k < i; k++) {
                        if (j == 0) row += offset;
                        else col += offset;
                        if ((matrix[row, col] = ComputeValueInCell(matrix, row, col)) > number)
                            return matrix[row, col];
                    }
                }
            }
            return 0;
        }

        private static bool IsOdd(int number) => number % 2 != 0;

        private static int ComputeValueInCell(int[,] matrix, int row, int col) {
            var result = 0;
            for (var i = -1; i < 2; i++) {
                for (var j = -1; j < 2; j++)
                    result += matrix[row + i, col + j];
            }
            return result;
        }
    }
}
