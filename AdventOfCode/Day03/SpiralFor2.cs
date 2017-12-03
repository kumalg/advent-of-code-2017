using System;

namespace Day03 {
    internal class SpiralFor2 {
        public static int ComputeNextNumber(int number) {
            var ringNumber = (int)Math.Ceiling(Math.Sqrt(number));
            var matrix = new int?[ringNumber, ringNumber];

            var centerIndex = (int)Math.Floor(ringNumber / 2.0);

            matrix[centerIndex, centerIndex] = 1;
            var actualCol = centerIndex;
            var actualRow = centerIndex;

            for (var i = 1; i <= ringNumber; i++) {
                int actualNumber;
                var offset = i % 2 != 0
                    ? 1
                    : -1;

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
