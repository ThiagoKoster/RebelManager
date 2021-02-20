using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RebelManager.API.Dto;
using RebelManager.Application.Fleets.Commands;
using RebelManager.Application.Fleets.Queries.Dapper;
using RebelManager.Application.Fleets.Queries.EFCore;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RebelManager.API.Controllers
{
    [Route("[controller]")]
    public class FleetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FleetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFleets()
        {
            var watch = new Stopwatch();
            var query = new GetAllFleetsEFCoreQuery();

            watch.Start();
            var result = await _mediator.Send(query);
            watch.Stop();
            return Ok();
        }

        [HttpGet("dapper")]
        public async Task<IActionResult> GetFleetsDapper()
        {
            var query = new GetAllFleetsDapperQuery();
            var result = await _mediator.Send(query);
            return Ok();
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
}
