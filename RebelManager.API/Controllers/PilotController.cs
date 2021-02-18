using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebelManager.Application.Pilots.Queries.Dapper;
using RebelManager.Application.Pilots.Queries.EFCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            var watch = new Stopwatch();
            var query = new GetPilotDapperQuery(id);

            watch.Start();
            var result = await _mediator.Send(query);
            watch.Stop();
            return Ok(watch.ElapsedMilliseconds);
        }

        [HttpGet("efcore/{id}")]
        public async Task<IActionResult> GetWithEFCoreAsync(long id)
        {
            var watch = new Stopwatch();
            var query = new GetPilotEFCoreQuery(id);

            watch.Start();
            var result = await _mediator.Send(query);
            return Ok(watch.ElapsedMilliseconds);
        }
    }
}
