﻿using BenchmarkDotNet.Running;

namespace LinqSample
{
    public class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<LinqBenchmarks>();
        }
    }
}