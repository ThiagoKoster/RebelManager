using MediatR;
using RebelManager.Domain.Aggregates.FleetAggregate.EFCore;
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

        private readonly IFleetEFCoreRepository _fleetRepository;

        public SeedDbCommandHandler(IFleetEFCoreRepository fleetRepository)
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
