using BenchmarkDotNet.Running;

namespace LoopsSample
{
    public class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<LoopsBenchmark>();
        }
    }
}