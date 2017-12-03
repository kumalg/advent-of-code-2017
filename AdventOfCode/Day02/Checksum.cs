using System.Collections.Generic;
using System.Linq;

namespace Day02 {
    internal class Checksum {
        public static int ComputeChecksum(IEnumerable<IEnumerable<int>> matrix) {
            return matrix.Select(i => i.Max() - i.Min()).Sum();
        }

        public static int ComputeChecksumFor2(IEnumerable<IEnumerable<int>> matrix) {
            var result = 0;
            foreach (var row in matrix) {
                var rowResult = 0;
                var rowSorted = row.OrderByDescending(i => i);
                for (var i = 0; i < rowSorted.Count(); i++) {
                    for (var j = i + 1; j < rowSorted.Count(); j++) {
                        if (rowSorted.ElementAt(i) % rowSorted.ElementAt(j) != 0) continue;
                        rowResult = (rowSorted.ElementAt(i) / rowSorted.ElementAt(j));
                        break;
                    }
                    if (rowResult == 0) continue;
                    result += rowResult;
                    break;
                }
            }
            return result;
        }
    }
}
