using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day21 {
        private static void Main() {
            var input = File.ReadAllLines("../../Inputs/day21.txt")
                .Select(x =>
                    x.Split(new[] { " => " }, StringSplitOptions.None).Select(PatternExtensions.ToPattern).ToArray())
                .ToDictionary(x => x[0], x => x[1]);

            var superDict = new Dictionary<Pattern, Pattern>();

            foreach (var pattern in input) {
                var key = pattern.Key.ToString();
                if (!superDict.ContainsKey(pattern.Key)) {
                    superDict.Add(pattern.Key, pattern.Value);
                }

                var last = pattern.Key;
                
                var vertical = last.Vertical();
                if (!superDict.ContainsKey(vertical)) {
                    superDict.Add(vertical, pattern.Value);
                }

                var horizontal = last.Horizontal();
                if (!superDict.ContainsKey(horizontal)) {
                    superDict.Add(horizontal, pattern.Value);
                }

                for (var i = 0; i < 3; i++) {
                    last = last.Rotate(1);
                    if (!superDict.ContainsKey(last)) {
                        superDict.Add(last, pattern.Value);
                    }

                    vertical = last.Vertical();
                    if (!superDict.ContainsKey(vertical)) {
                        superDict.Add(vertical, pattern.Value);
                    }
                   
                    horizontal = last.Horizontal();
                    if (!superDict.ContainsKey(horizontal)) {
                        superDict.Add(horizontal, pattern.Value);
                    }
                }
            }

            PartOne(superDict);

            Console.ReadKey();
        }

        private static void PartOne(Dictionary<Pattern, Pattern> input) {
            var currentImage = new[,]
            {
                {false, true, false},
                {false, false, true},
                {true, true, true}
            };
            for (var i = 0; i < 18; i++) {
                Console.Write(i + " ");
                var length = currentImage.GetLength(0);
                Pattern[,] patternImage;
                if (length % 2 == 0) {
                    patternImage = ToPatternImage(currentImage, 2);
                }
                else if (length % 3 == 0) {
                    patternImage = ToPatternImage(currentImage, 3);
                }
                else throw new Exception("zesrało sie");

                for (var y = 0; y < patternImage.GetLength(0); y++) {
                    for (var x = 0; x < patternImage.GetLength(1); x++) {
                        patternImage[y, x] = input[patternImage[y, x]];
                    }
                }

                currentImage = ToBoolImage(patternImage);
            }
            Console.WriteLine();
            Console.WriteLine(currentImage.Cast<bool>().Count(x => x));
        }

        private static Pattern[,] ToPatternImage(bool[,] image, int size) {
            var length = image.GetLength(0);
            var patterns = new Pattern[length / size, length / size];

            for (var y = 0; y < length / size; y++) {
                for (var x = 0; x < length / size; x++) {
                    var matrix = new bool[size, size];
                    for (var i = 0; i < size; i++) {
                        for (var j = 0; j < size; j++) {
                            matrix[i, j] = image[y * size + i, x * size + j];
                        }
                    }

                    patterns[y, x] = new Pattern(matrix);
                }
            }

            return patterns;
        }

        private static bool[,] ToBoolImage(Pattern[,] patternImage) {
            var size = patternImage[0, 0].Value.GetLength(0);
            var length = patternImage.GetLength(0) * size;
            var image = new bool[length, length];

            for (var y = 0; y < length / size; y++) {
                for (var x = 0; x < length / size; x++) {
                    for (var i = 0; i < size; i++) {
                        for (var j = 0; j < size; j++) {
                            image[y * size + i, x * size + j] = patternImage[y, x].Value[i, j];
                        }
                    }
                }
            }

            return image;
        }
    }

    public class Pattern {
        public bool[,] Value;

        public Pattern(bool[,] matrix) {
            Value = matrix;
        }

        public Pattern Rotate(int sides) {
            var matrix = Value;

            for (var i = 0; i < sides; i++) {
                matrix = RotateMatrix(matrix);
            }

            return new Pattern(matrix);
        }

        private bool[,] RotateMatrix(bool[,] oldMatrix) {
            var newMatrix = new bool[oldMatrix.GetLength(1), oldMatrix.GetLength(0)];
            var newRow = 0;
            for (var oldColumn = oldMatrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--) {
                var newColumn = 0;
                for (var oldRow = 0; oldRow < oldMatrix.GetLength(0); oldRow++) {
                    newMatrix[newRow, newColumn] = oldMatrix[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newMatrix;
        }

        public Pattern Horizontal() {
            var size = Value.GetLength(0);
            var newMatrix = new bool[size, size];

            for (var x = 0; x < size; x++) {
                for (var y = 0; y < size; y++) {
                    newMatrix[size - x - 1, y] = Value[x, y];
                }
            }
            return new Pattern(newMatrix);
        }

        public Pattern Vertical() {
            var size = Value.GetLength(0);
            var newMatrix = new bool[size, size];

            for (var x = 0; x < size; x++) {
                for (var y = 0; y < size; y++) {
                    newMatrix[x, size - y - 1] = Value[x, y];
                }
            }
            return new Pattern(newMatrix);
        }

        public override bool Equals(object obj) {
            if (!(obj is Pattern pattern))
                return false;
            return ToString() == pattern.ToString();
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public override string ToString() {
            return string.Join("/", Value.Cast<bool>().Select(item => string.Join("", item)));
        }
    }

    public static class PatternExtensions {
        public static Pattern ToPattern(this string line) {
            var matrix = line
                .Split('/')
                .Select(x => x
                    .ToCharArray()
                    .Select(y => y == '#')
                    .ToArray())
                .ToArray();

            var matrix2D = new bool[matrix.Length, matrix.Length];
            for (var i = 0; i < matrix2D.GetLength(0); i++) {
                for (var j = 0; j < matrix2D.GetLength(1); j++)
                    matrix2D[i, j] = matrix[i][j];
            }

            return new Pattern(matrix2D);
        }
    }
}