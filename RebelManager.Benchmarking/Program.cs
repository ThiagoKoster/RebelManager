using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using RebelManager.Infrastructure;
using RebelManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelManager.Benchmarking
{
    public class Program
    {
        [MemoryDiagnoser]
        public class SingleVsFirst
        {
            private readonly List<string> _haystack = new List<string>();
            private readonly int _haystackSize = 1000000;
            private readonly string _needle = "needle";

            public SingleVsFirst()
            {
                //Add a large amount of items to our list. 
                Enumerable.Range(1, _haystackSize).ToList().ForEach(x => _haystack.Add(x.ToString()));
                //Insert the needle right in the middle. 
                _haystack.Insert(_haystackSize / 2, _needle);
            }

            [Benchmark]
            public string Single() => _haystack.SingleOrDefault(x => x == _needle);

            [Benchmark]
            public string First() => _haystack.FirstOrDefault(x => x == _needle);

        }
        [MinIterationTime(100000)]
        [MemoryDiagnoser]
        public class EFCoreVsDapper
        {
            private readonly FleetRepositoryDapper _fleetRepositoryDapper;
            private readonly FleetRepositoryEFCore _fleetRepositoryEFCore;
            public EFCoreVsDapper()
            {
                var optionsBuilder = new DbContextOptionsBuilder();
                optionsBuilder.UseSqlServer("Data Source=LOKI;Initial Catalog=RebelManagerDb;Integrated Security=True");
                var dbContext = new RebelManagerDbContext(optionsBuilder.Options);
                _fleetRepositoryEFCore = new FleetRepositoryEFCore(dbContext);
                _fleetRepositoryDapper = new FleetRepositoryDapper("Data Source=LOKI;Initial Catalog=RebelManagerDb;Integrated Security=True");
            }

            [Benchmark]
            public void Dapper()
            {
                _fleetRepositoryDapper.GetAll();
            }

            [Benchmark]
            public async Task EFCore()
            {
                await _fleetRepositoryEFCore.GetAll();
            }
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<EFCoreVsDapper>();
            Console.ReadLine();
        }
    }
}
