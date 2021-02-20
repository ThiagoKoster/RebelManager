using Microsoft.EntityFrameworkCore;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
using System.Threading.Tasks;

namespace RebelManager.Infrastructure.Repositories.EFCore
{
    public class PilotEFCoreRepository : IPilotEFCoreRepository
    {
        private readonly string _connectionString;
        public PilotEFCoreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Pilot> GetAsNoTrackingAsync(long id)
        {
            using(var dbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                return await dbContext.Pilot.AsNoTracking().FirstAsync(p => p.Id == id);
            }
        }
        public async Task<Pilot> GetAsNoTrackingIdentityResolutionAsync(long id)
        {
            using (var dbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                return await dbContext.Pilot.AsNoTrackingWithIdentityResolution().FirstAsync(p => p.Id == id);
            }
        }


        public async Task<Pilot> GetAsync(long id)
        {
            using (var dbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                return await dbContext.Pilot.FirstAsync(p => p.Id == id);
            }
        }
    }
}
