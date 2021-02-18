using Microsoft.EntityFrameworkCore;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Infrastructure.Repositories
{
    public class FleetEFCoreRepository : IFleetEFCoreRepository
    {
        private readonly string _connectionString;
        

        public FleetEFCoreRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Fleet> AddAsync(Fleet fleet)
        {
            using (var _rebelManagerDbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                await _rebelManagerDbContext.AddAsync(fleet);
                await _rebelManagerDbContext.SaveChangesAsync();
                return fleet;

            }
        }

        public async Task AddFleetsAsync(List<Fleet> fleets)
        {
            using (var _rebelManagerDbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                await _rebelManagerDbContext.Fleet.AddRangeAsync(fleets);
                await _rebelManagerDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Fleet>> GetAll()
        {
            using (var _rebelManagerDbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                return await _rebelManagerDbContext.Fleet.Include(f => f.Ships).ThenInclude(s => s.Pilots).AsNoTracking().ToListAsync();
            }
        }

        public async Task<Fleet> GetByIdAsync(long id)
        {
            using (var _rebelManagerDbContext = new RebelManagerDbContext(new DbContextOptionsBuilder().UseSqlServer(_connectionString).Options))
            {
                return await _rebelManagerDbContext.Fleet.FindAsync(id);
            }
        }
    }
}
