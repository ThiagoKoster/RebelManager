using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Fleets.Queries
{
    public class GetAllFleetsQuery : IRequest<List<Fleet>>
    {

    }

    public class GetAllFleetsQueyHandler : IRequestHandler<GetAllFleetsQuery, List<Fleet>>
    {
        private readonly IFleetRepository _fleetRepository;

        public GetAllFleetsQueyHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<List<Fleet>> Handle(GetAllFleetsQuery request, CancellationToken cancellationToken)
        {
            return await _fleetRepository.GetAll();
        }
    }
}
