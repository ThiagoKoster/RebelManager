using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebelManager.Domain.Aggregates.FleetAggregate.Dapper;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
using RebelManager.Infrastructure.Repositories;
using RebelManager.Infrastructure.Repositories.Dapper;
using RebelManager.Infrastructure.Repositories.EFCore;

namespace RebelManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RebelManagerDb");

            services.AddDbContext<RebelManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RebelManagerDb")));

            services.AddScoped<IFleetEFCoreRepository, FleetEFCoreRepository>(x => new FleetEFCoreRepository(connectionString));
            services.AddScoped<IFleetDapperRepository, FleetDapperRepository>(x => new FleetDapperRepository(connectionString));
            services.AddScoped<IPilotDapperRepository, PilotDapperRepository>(x => new PilotDapperRepository(connectionString));
            services.AddScoped<IPilotEFCoreRepository, PilotEFCoreRepository>(x => new PilotEFCoreRepository(connectionString));

            return services;

        }

    }
}
