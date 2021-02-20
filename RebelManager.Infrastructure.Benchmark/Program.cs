using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Mathematics;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Perfolizer.Mathematics.OutlierDetection;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Infrastructure.Repositories;
using RebelManager.Infrastructure.Repositories.Dapper;
using RebelManager.Infrastructure.Repositories.EFCore;
using System;
using System.Threading.Tasks;


namespace RebelManager.Infrastructure.Benchmark
{
    class Program
    {
       
        public Program()
        {
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var summary = BenchmarkRunner.Run<FleetDapperXEfcore>();
            var summary2 = BenchmarkRunner.Run<PilotDapperXEfCore>();
        }

    }

    [MemoryDiagnoser]
    [RPlotExporter]
    [SimpleJob(RunStrategy.Throughput, invocationCount:2)]
    public class FleetDapperXEfcore
    {
        private readonly string _connectionString = "Data Source=LOKI;Initial Catalog=RebelManagerDb;Integrated Security=True";
        private readonly FleetDapperRepository _fleetDapperRepository;
        private readonly FleetEFCoreRepository _fleetEFCoreRepository;

        private readonly Consumer _consumer = new Consumer();

        public FleetDapperXEfcore()
        {
            _fleetDapperRepository = new FleetDapperRepository(_connectionString);
            _fleetEFCoreRepository = new FleetEFCoreRepository(_connectionString);
        }

        [Benchmark(Description = "Dapper")]
        public async Task Dapper() => (await _fleetDapperRepository.GetAll()).Consume(_consumer);

        [Benchmark(Baseline = true, Description = "EFCore")]
        public async Task EFCore() => (await _fleetEFCoreRepository.GetAll()).Consume(_consumer);

        [Benchmark(Description = "AsNoTracking")]
        public async Task EFCoreAsNoTracking() => (await _fleetEFCoreRepository.GetAllAsNoTracking()).Consume(_consumer);

        [Benchmark(Description = "AsNoTrackingWithIdentityResolution")]
        public async Task EFCoreAsNoTrackingWithIdentityResolution() => (await _fleetEFCoreRepository.GetAllAsNoTrackingWithIdentityResolution()).Consume(_consumer);

    }

    [MemoryDiagnoser]
    [RPlotExporter]
    [Outliers(OutlierMode.DontRemove)]
    [SimpleJob(RunStrategy.Throughput, invocationCount: 500)]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn(NumeralSystem.Stars)]
    public class PilotDapperXEfCore
    {
        private readonly PilotDapperRepository _pilotDapperRepository;
        private readonly PilotEFCoreRepository _pilotEFCoreRepository;
        private readonly string _connectionString = "Data Source=LOKI;Initial Catalog=RebelManagerDb;Integrated Security=True";

        public PilotDapperXEfCore()
        {
            _pilotDapperRepository = new PilotDapperRepository(_connectionString);
            _pilotEFCoreRepository = new PilotEFCoreRepository(_connectionString);
        }

        [Benchmark(Description = "Dapper")]
        public async Task<Pilot> Dapper() => await _pilotDapperRepository.GetAsync(100);

        [Benchmark(Baseline = true, Description = "EFCore")]
        public async Task<Pilot> EFCore() => await _pilotEFCoreRepository.GetAsync(100);

        [Benchmark(Description = "AsNoTracking")]
        public async Task<Pilot> EFCoreAsNoTracking() => await _pilotEFCoreRepository.GetAsNoTrackingAsync(100);

        [Benchmark(Description = "AsNoTrackingWithIdentityResolution")]
        public async Task<Pilot> EFCoreAsNoTrackingWithIdentityResolution() => await _pilotEFCoreRepository.GetAsNoTrackingIdentityResolutionAsync(100);
    }
}
