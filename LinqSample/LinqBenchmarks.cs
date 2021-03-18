using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Collections.Generic;
using System.Linq;

namespace LinqSample
{
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class LinqBenchmarks
    {
        private readonly Dictionary<int, string> _employees = new Dictionary<int, string>
        {
            { 1, "Bence" },
            { 2, "Jazeem" },
            { 3, "Shahid" },
            { 4, "Luca" },
            { 5, "Hossein" }
        };

        [Benchmark]
        public void GetEmployeeWithWherePredicate()
        {
            var employee = _employees.Where(e => e.Key == 3).First();
        }

        [Benchmark]
        public void GetEmployeeWithFirstPredicate()
        {
            var employee = _employees.First(e => e.Key == 3);
        }
    }
}