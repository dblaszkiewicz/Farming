using Farming.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeasonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("startNew")]
        public async Task<IActionResult> StartNewSeason()
        {
            var command = new StartNewSeasonCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("endCurrent")]
        public async Task<IActionResult> EndCurrentSeason()
        {
            var command = new EndCurrentSeasonCommand();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
