using System.Linq;

namespace Day01 {
    internal class Captcha {
        public static int ComputeCaptchaPartOne(int[] array) {
            var result = 0;
            for (var i = 0; i < array.Length - 1;) {
                if (array[i] == array[++i])
                    result += array[i];
            }
            if (array.Last() == array.First())
                result += array.First();
            return result;
        }
        public static int ComputeCaptchaPartTwo(int[] array) {
            var result = 0;
            var halfWay = array.Length / 2;
            for (var i = 0; i < halfWay; i++) {
                if (array[i] == array[i + halfWay])
                    result += array[i];
            }
            return result * 2;
        }
    }
}
