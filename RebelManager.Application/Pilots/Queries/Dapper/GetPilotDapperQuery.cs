using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using RebelManager.Domain.Aggregates.FleetAggregate.Dapper;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Pilots.Queries.Dapper
{
    public class GetPilotDapperQuery : IRequest<Pilot>
    {
        public long Id { get; }

        public GetPilotDapperQuery(long id)
        {
            Id = id;
        }
    }

    public class GetPilotQueryHandler : IRequestHandler<GetPilotDapperQuery, Pilot>
    {
        private readonly IPilotDapperRepository _pilotRepository;

        public GetPilotQueryHandler(IPilotDapperRepository pilotRepository)
        {
            _pilotRepository = pilotRepository;
        }

        public async Task<Pilot> Handle(GetPilotDapperQuery request, CancellationToken cancellationToken)
        {
            return await _pilotRepository.GetAsync(request.Id);
        }
    }
}
