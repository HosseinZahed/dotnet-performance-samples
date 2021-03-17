using BenchmarkDotNet.Running;

namespace LinqSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<LinqBenchmarks>();
        }
    }
}