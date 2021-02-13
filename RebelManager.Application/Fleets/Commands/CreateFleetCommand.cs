using Mapster;
using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Fleets.Commands
{
    public class CreateFleetCommand : IRequest<Fleet>
    {
        public string Name { get; set; }
    }

    public class CreateFleetCommandHandler : IRequestHandler<CreateFleetCommand, Fleet>
    {
        private readonly IFleetRepository _fleetRepository;

        public CreateFleetCommandHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<Fleet> Handle(CreateFleetCommand request, CancellationToken cancellationToken)
        {
            var fleet = request.Adapt<Fleet>();
            await _fleetRepository.AddAsync(fleet);

            return fleet;
        }
    }
}
