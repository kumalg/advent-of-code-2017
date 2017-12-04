using System.Collections.Generic;
using System.Linq;

namespace Day04 {
    public class Passphrase {
        public static int CountValidPassphrasesForOne(IEnumerable<IEnumerable<string>> list) {
            return list.Count(sublist => sublist.All(new HashSet<string>().Add));
        }

        public static int CountValidPassphrasesForTwo(IEnumerable<IEnumerable<string>> list) {
            return list.Count(sublist => sublist.Select(word => new string(word.OrderBy(letter => letter)
                                                                               .ToArray()))
                                                .All(new HashSet<string>().Add));
        }
    }
}
