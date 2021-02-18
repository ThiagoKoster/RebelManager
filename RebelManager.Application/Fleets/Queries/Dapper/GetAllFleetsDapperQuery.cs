using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.Dapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Fleets.Queries.Dapper
{
    public class GetAllFleetsDapperQuery : IRequest<List<Fleet>>
    {

    }

    public class GetAllFleetsDapperQueryHandler : IRequestHandler<GetAllFleetsDapperQuery, List<Fleet>>
    {
        private readonly IFleetDapperRepository _fleetRepository;

        public GetAllFleetsDapperQueryHandler(IFleetDapperRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<List<Fleet>> Handle(GetAllFleetsDapperQuery request, CancellationToken cancellationToken)
        {
            return await _fleetRepository.GetAll();
        }


    }
}
