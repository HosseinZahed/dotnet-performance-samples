using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using SqlSample.Services;
using System.Threading.Tasks;

namespace SqlSample.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class QueryBenchmarks
    {
        private DataService _dataService;

        [GlobalSetup]
        public void Setup()
        {
            _dataService = new DataService();
        }

        [Benchmark]
        public async Task GetByEntityFramework() => await _dataService.GetByEntityFramework();

        [Benchmark]
        public async Task GetByDapper() => await _dataService.GetByDapper();

        [Benchmark]
        public async Task GetByPlainSqlConnection() => await _dataService.GetByPlainSqlConnection();

        [Benchmark]
        public async Task GetByStoredProcedureSql() => await _dataService.GetByStoredProcedureSql();

        [Benchmark]
        public async Task GetByStoredProcedureEf() => await _dataService.GetByStoredProcedureEf();
    }
}