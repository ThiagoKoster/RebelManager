using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Fleets.Queries.EFCore
{
    public class GetAllFleetsEFCoreQuery : IRequest<List<Fleet>>
    {

    }

    public class GetAllFleetsEFCoreQueryHandler : IRequestHandler<GetAllFleetsEFCoreQuery, List<Fleet>>
    {
        private readonly IFleetEFCoreRepository _fleetRepository;

        public GetAllFleetsEFCoreQueryHandler(IFleetEFCoreRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<List<Fleet>> Handle(GetAllFleetsEFCoreQuery request, CancellationToken cancellationToken)
        {
            return await _fleetRepository.GetAll();
        }
    }
}
