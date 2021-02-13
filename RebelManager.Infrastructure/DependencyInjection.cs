using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RebelManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RebelManagerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RebelManagerDb")));
            services.AddScoped<IFleetRepository, FleetRepository>();

            return services;

        }

    }
}
