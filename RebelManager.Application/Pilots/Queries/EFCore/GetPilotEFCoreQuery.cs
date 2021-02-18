using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Pilots.Queries.EFCore
{
    public class GetPilotEFCoreQuery : IRequest<Pilot>
    {
        public long Id { get; set; }

        public GetPilotEFCoreQuery(long id)
        {
            Id = id;
        }
    }

    public class GetPilotEFCoreQueryHandler : IRequestHandler<GetPilotEFCoreQuery, Pilot>
    {
        private readonly IPilotEFCoreRepository _pilotRepository;

        public GetPilotEFCoreQueryHandler(IPilotEFCoreRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<Pilot> Handle(GetPilotEFCoreQuery request, CancellationToken cancellationToken)
        {
            return await _pilotRepository.GetAsync(request.Id);
        }
    }
}
