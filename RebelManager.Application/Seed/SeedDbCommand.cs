using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RebelManager.Application.Seed
{
    public class SeedDbCommand : IRequest<Unit>
    {
        public int NumberOfFleets { get; set; }
    }

    public class SeedDbCommandHandler : IRequestHandler<SeedDbCommand, Unit>
    {

        private readonly IFleetRepository _fleetRepository;

        public SeedDbCommandHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<Unit> Handle(SeedDbCommand request, CancellationToken cancellationToken)
        {

            await _fleetRepository.AddFleetsAsync(DataGenerator.FleetGenerator(request.NumberOfFleets));
            return Unit.Value;
        }
    }
}
