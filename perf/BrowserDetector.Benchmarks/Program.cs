using BenchmarkDotNet.Running;
using System;

namespace BrowserDetector.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DetectorBenchmarks>();
            Console.WriteLine("Benchmark done.");
        }
    }
    //dotnet run -c Release -- --job short --runtimes clr core --filter BrowserDetector.Benchmarks
}
