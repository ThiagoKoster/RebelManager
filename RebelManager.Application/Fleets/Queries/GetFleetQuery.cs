using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Fleets.Queries
{
    public class GetFleetQuery : IRequest<Fleet>
    {
        public long Id { get; set; }
        public GetFleetQuery(long id)
        {
            Id = id;
        }
    }

    public class GetFleetQueryHandler : IRequestHandler<GetFleetQuery, Fleet>
    {

        private readonly IFleetRepository _fleetRepository;

        public GetFleetQueryHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<Fleet> Handle(GetFleetQuery request, CancellationToken cancellationToken)
        {
            return await _fleetRepository.GetByIdAsync(request.Id);
        }
    }
}
