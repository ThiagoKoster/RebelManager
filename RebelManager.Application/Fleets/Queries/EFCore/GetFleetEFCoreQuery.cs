using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Fleets.Queries.EFCore
{
    public class GetFleetEFCoreQuery : IRequest<Fleet>
    {
        public long Id { get; set; }
        public GetFleetEFCoreQuery(long id)
        {
            Id = id;
        }
    }

    public class GetFleetQueryHandler : IRequestHandler<GetFleetEFCoreQuery, Fleet>
    {

        private readonly IFleetEFCoreRepository _fleetRepository;

        public GetFleetQueryHandler(IFleetEFCoreRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<Fleet> Handle(GetFleetEFCoreQuery request, CancellationToken cancellationToken)
        {
            return await _fleetRepository.GetByIdAsync(request.Id);
        }
    }
}
