using BenchmarkDotNet.Running;
using SqlSample.DbContexts;
using System.Threading.Tasks;
using SqlSample.Benchmarks;

namespace SqlSample
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            // Seed database if needed
            await DataSeed.SeedAsync();

            // Run benchmark
            BenchmarkRunner.Run<QueryBenchmarks>();
        }
    }
}