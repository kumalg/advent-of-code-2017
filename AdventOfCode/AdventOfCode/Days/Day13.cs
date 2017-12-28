using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Days {
    public class Day13 {
        private static void Main() {
            var layers = File.ReadAllText("../../Inputs/day13.txt")
                .Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Split(':').Select(int.Parse)).Select(i =>
                    new KeyValuePair<int, Layer>(i.ElementAt(0), new Layer { Depth = i.ElementAt(1) })).ToDictionary(i => i.Key, i => i.Value);

            Console.WriteLine($" Part I: {PartOne(layers)}");
            Console.WriteLine($"Part II: {PartTwo(layers)}");

            Console.ReadKey();
        }

        public static int PartOne(Dictionary<int, Layer> layersOriginal) {
            var layers = layersOriginal.ToDictionary(i => i.Key, i => i.Value.ToLayer());
            var lastLayer = layers.Keys.Max();
            var catchedOn = new List<int>();
            for (var packetPosition = 0; packetPosition <= lastLayer; packetPosition++) {
                if (layers.ContainsKey(packetPosition)) {
                    if (layers[packetPosition].ScannerPosition == 0)
                        catchedOn.Add(packetPosition);
                }
                foreach (var layer in layers)
                    layer.Value.MoveScanner();
            }

            return catchedOn.Select(i => i * layers[i].Depth).Sum();
        }

        public static long PartTwo(Dictionary<int, Layer> layers) {
            var lastLayer = layers.Keys.Max();
            var delay = 0L;
            while (true) {
                if (delay == long.MaxValue)
                    return 0L;

                var catched = false;
                var tempLayers = layers.ToDictionary(i => i.Key, i => new Layer(i.Value.Depth, delay));

                for (var packetPosition = 0; packetPosition <= lastLayer; packetPosition++) {
                    if (tempLayers.ContainsKey(packetPosition)) {
                        if (tempLayers[packetPosition].ScannerPosition == 0) {
                            catched = true;
                            break;
                        }
                    }
                    foreach (var layer in tempLayers)
                        layer.Value.MoveScanner();
                }
                if (!catched)
                    return delay;
                delay++;
            }
        }

        public class Layer {
            public int Depth;
            public int ScannerPosition = 0;
            private int _direction = 1;

            public void MoveScanner() {
                if (ScannerPosition == 0)
                    _direction = 1;
                else if (ScannerPosition + 1 == Depth)
                    _direction = -1;

                ScannerPosition += _direction;
            }

            public Layer() { }
            public Layer(int depth, long delay) {
                Depth = depth;
                ScannerPosition = (int)(delay % ((Depth - 1U) * 2U));
                if (ScannerPosition >= Depth) {
                    ScannerPosition = (int)((Depth - 1U) * 2 - ScannerPosition);
                    _direction = -1;
                }
            }

            public Layer ToLayer() {
                return new Layer {
                    Depth = Depth
                };
            }
        }
    }
}
