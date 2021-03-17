using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SqlSample.DbContexts;
using SqlSample.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SqlSample.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class QueryBenchmarks
    {
        private readonly SqlDbContext _sqlDbContext;
        private const string Query = "SELECT * FROM Persons ORDER BY NAME";

        public QueryBenchmarks()
        {
            _sqlDbContext = new SqlDbContext();
        }

        [Benchmark]
        public async Task GetByEntityFramework()
        {
            var persons = await _sqlDbContext
                .Persons
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        [Benchmark]
        public async Task GetByDapper()
        {
            await using var connection = new SqlConnection(Config.ConnectionString);
            var persons = await connection.QueryAsync(Query);
        }

        [Benchmark]
        public async Task GetByPlainSqlConnection()
        {
            await using var connection = new SqlConnection(Config.ConnectionString);
            var persons = await connection.ExecuteReaderAsync(Query);
        }

        [Benchmark]
        public async Task GetByStoredProcedureSql()
        {
            var persons = new List<Person>();
            await using var connection = new SqlConnection(Config.ConnectionString);
            await using var command = new SqlCommand("sp_GetPersons", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            await connection.OpenAsync();
            var sqlDataReader = await command.ExecuteReaderAsync();
            await sqlDataReader.ReadAsync();
            await connection.CloseAsync();
        }

        [Benchmark]
        public async Task GetByStoredProcedureEf()
        {
            var persons = await _sqlDbContext.Persons.FromSqlRaw("sp_GetPersons").ToListAsync();
        }
    }
}