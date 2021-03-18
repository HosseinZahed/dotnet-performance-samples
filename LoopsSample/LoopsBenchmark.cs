using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoopsSample
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class LoopsBenchmark
    {
        private IEnumerable<int> _numbers;

        [GlobalSetup]
        public void Setup()
        {
            var rnd = new Random(15);
            _numbers = Enumerable.Range(0, rnd.Next(50, 100));
        }

        [Benchmark]
        public void ForLoop()
        {
            var count = _numbers.Count();
            for (int i = 0; i < count; i++)
            {
                // Do something
            }
        }

        [Benchmark]
        public void ForEachLoop()
        {
            foreach (var number in _numbers)
            {
                // Do something
            }
        }

        [Benchmark]
        public void WhileLoop()
        {
            var i = 0;
            var count = _numbers.Count();
            while (i < count)
            {
                // Do something
                i++;
            }
        }

        [Benchmark]
        public void DoWhileLoop()
        {
            var i = 0;
            var count = _numbers.Count();
            do
            {
                // Do something
                i++;
            } while (i < count);
        }
    }
}