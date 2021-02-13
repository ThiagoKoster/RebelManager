using Microsoft.EntityFrameworkCore;
using RebelManager.Domain.Aggregates.FleetAggregate;


namespace RebelManager.Infrastructure
{
    public class RebelManagerDbContext : DbContext
    {
        public DbSet<Fleet> Fleet { get; set; }
        public DbSet<Ship> Ship { get; set; }
        public DbSet<Pilot> Pilot { get; set; }
        public RebelManagerDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
