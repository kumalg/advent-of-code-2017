using System;
using System.IO;

namespace Day01 {
    class Program {
        static void Main(string[] args) {
            var array = GetArray("input.txt");
            Console.WriteLine($" Part I: {Captcha.ComputeCaptcha(array)}");
            Console.WriteLine($"Part II: {Captcha.ComputeCaptchaFor2(array)}");
            Console.ReadKey();
        }
        static int[] GetArray(string fileName) {
            int[] array = null;
            try {
                using (var sr = new StreamReader(fileName)) {
                    try {
                        var line = sr.ReadLine();
                        var tokens = line.ToCharArray();
                        array = Array.ConvertAll(tokens, c => (int)char.GetNumericValue(c));
                    }
                    catch (Exception e) {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return array;
        }
    }
}
