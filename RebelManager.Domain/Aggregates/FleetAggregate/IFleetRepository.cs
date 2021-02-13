﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Domain.Aggregates.FleetAggregate
{
    public interface IFleetRepository
    {
        Task<List<Fleet>> GetAll();
        Task<Fleet> AddAsync(Fleet fleet);
        Task<Fleet> GetByIdAsync(long id);
        Task AddFleetsAsync(List<Fleet> fleets);
    }
}
