using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Domain.Aggregates.FleetAggregate.Dapper
{
    public interface IFleetDapperRepository
    {
        Task<List<Fleet>> GetAll();
    }
}
