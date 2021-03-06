﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RebelManager.Domain.Aggregates.FleetAggregate.EFCore
{
    public interface IPilotEFCoreRepository
    {
        Task<Pilot> GetAsync(long id);
        Task<Pilot> GetAsNoTrackingAsync(long id);
        Task<Pilot> GetAsNoTrackingIdentityResolutionAsync(long id);
    }
}
