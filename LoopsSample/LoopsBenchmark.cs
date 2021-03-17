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
            for (int i = 0; i < _numbers.Count(); i++)
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
            while (i < _numbers.Count())
            {
                // Do something
                i++;
            }
        }

        [Benchmark]
        public void DoWhileLoop()
        {
            var i = 0;
            do
            {
                // Do something
                i++;
            } while (i < _numbers.Count());
        }
    }
}