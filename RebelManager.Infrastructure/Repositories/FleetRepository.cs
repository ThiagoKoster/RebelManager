using Microsoft.EntityFrameworkCore;
using RebelManager.Domain.Aggregates.FleetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Infrastructure.Repositories
{
    internal class FleetRepository : IFleetRepository
    {
        private readonly RebelManagerDbContext _rebelManagerDbContext;

        public FleetRepository(RebelManagerDbContext rebelManagerDbContext)
        {
            _rebelManagerDbContext = rebelManagerDbContext;
        }

        public async Task<Fleet> AddAsync(Fleet fleet)
        {
            await _rebelManagerDbContext.AddAsync(fleet);
            await _rebelManagerDbContext.SaveChangesAsync();

            return fleet;

        }

        public async Task AddFleetsAsync(List<Fleet> fleets)
        {
            await _rebelManagerDbContext.Fleet.AddRangeAsync(fleets);
            await _rebelManagerDbContext.SaveChangesAsync();
        }

        public async Task<List<Fleet>> GetAll()
        {
            return await _rebelManagerDbContext.Fleet.ToListAsync();
        }

        public async Task<Fleet> GetByIdAsync(long id)
        {
            return await _rebelManagerDbContext.Fleet.FindAsync(id);
        }
    }
}
