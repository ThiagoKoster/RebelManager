using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RebelManager.API.Dto;
using RebelManager.Application.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebelManager.API.Controllers
{

    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SeedDb([FromBody] SeedDbRequest request)
        {
            var command = request.Adapt<SeedDbCommand>();
            await _mediator.Send(command);

            return Ok();
        }

    }
}
