using System;

namespace Day03 {
    internal class SpiralPartTwo {
        public static int ComputeNextNumber(int number) {
            var ring = (int)Math.Ceiling(Math.Sqrt(number));
            var matrix = new int?[ring, ring];

            var centerIndex = ring / 2;

            matrix[centerIndex, centerIndex] = 1;
            var actualCol = centerIndex;
            var actualRow = centerIndex;

            for (var i = 1; i <= ring; i++) {
                int actualNumber;
                var offset = IsOdd(i) ? 1 : -1;

                for (var j = 0; j < i; j++) {
                    actualRow += offset;
                    actualNumber = ComputeValueInCell(matrix, actualRow, actualCol);
                    matrix[actualRow, actualCol] = actualNumber;
                    if (actualNumber > number)
                        return actualNumber;
                }
                for (var j = 0; j < i; j++) {
                    actualCol += offset;
                    actualNumber = ComputeValueInCell(matrix, actualRow, actualCol);
                    matrix[actualRow, actualCol] = actualNumber;
                    if (actualNumber > number)
                        return actualNumber;
                }
            }
            return 0;
        }

        private static bool IsOdd(int number) {
            return number % 2 != 0;
        }

        private static int ComputeValueInCell(int?[,] matrix, int actualRow, int actualCol) {
            var result = 0;

            result += matrix[actualRow - 1, actualCol - 1] ?? 0;
            result += matrix[actualRow - 1, actualCol] ?? 0;
            result += matrix[actualRow - 1, actualCol + 1] ?? 0;

            result += matrix[actualRow, actualCol - 1] ?? 0;
            result += matrix[actualRow, actualCol + 1] ?? 0;

            result += matrix[actualRow + 1, actualCol - 1] ?? 0;
            result += matrix[actualRow + 1, actualCol] ?? 0;
            result += matrix[actualRow + 1, actualCol + 1] ?? 0;

            return result;
        }
    }
}
