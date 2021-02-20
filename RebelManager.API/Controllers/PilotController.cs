using MediatR;
using Microsoft.AspNetCore.Mvc;
using RebelManager.Application.Pilots.Queries.Dapper;
using RebelManager.Application.Pilots.Queries.EFCore;
using System.Threading.Tasks;

namespace RebelManager.API.Controllers
{
    [Route("[controller]")]
    public class PilotController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PilotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("dapper/{id}")]
        public async Task<IActionResult> GetWithDapperAsync(long id)
        {
            var query = new GetPilotDapperQuery(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("efcore/{id}")]
        public async Task<IActionResult> GetWithEFCoreAsync(long id)
        {
            var query = new GetPilotEFCoreQuery(id);
            return Ok(await _mediator.Send(query));
        }
    }
}
