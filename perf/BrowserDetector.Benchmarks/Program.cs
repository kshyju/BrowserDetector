namespace BrowserDetector.Benchmarks
{
    using System;
    using BenchmarkDotNet.Running;

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DetectorBenchmarks>();
            Console.WriteLine($"Benchmarking done in {summary.TotalTime.TotalMilliseconds} milli seconds");
        }
    }

    // dotnet run -c Release -- --job short --runtimes clr core --filter BrowserDetector.Benchmarks
}
