using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RebelManager.API.Dto;
using RebelManager.Application.Fleets.Commands;
using RebelManager.Application.Fleets.Queries.Dapper;
using RebelManager.Application.Fleets.Queries.EFCore;
using System.Threading.Tasks;

namespace RebelManager.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("fleet")]
    public class FleetV1Controller : ControllerBase
    {
        private readonly IMediator _mediator;

        public FleetV1Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFleets()
        {
            var query = new GetAllFleetsEFCoreQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpGet("efcore/{id}")]
        public async Task<IActionResult> GetFleet(long id)
        {
            var query = new GetFleetEFCoreQuery(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddFleet([FromBody] CreateFleetRequest request)
        {
            var command = request.Adapt<CreateFleetCommand>();
            var result = await _mediator.Send(command);

            return CreatedAtAction("GetFleet",new { id = result.Id }, result);
        }
    }

    [ApiController]
    [ApiVersion("2.0")]
    [Route("fleet")]
    public class FleetV2Controller : ControllerBase
    {
        private readonly IMediator _mediator;
        public FleetV2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFleetsDapper()
        {
            var query = new GetAllFleetsDapperQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}
