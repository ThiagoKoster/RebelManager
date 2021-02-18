using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Domain.Aggregates.FleetAggregate.Dapper
{
    public interface IPilotDapperRepository
    {
        Task<Pilot> GetAsync(long id);
    }
}
