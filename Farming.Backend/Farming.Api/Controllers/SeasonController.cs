using Farming.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class SeasonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeasonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("startNewSeason")]
        public async Task<IActionResult> StartNewSeason()
        {
            var command = new StartNewSeasonCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("endCurrentSeason")]
        public async Task<IActionResult> EndCurrentSeason()
        {
            var command = new EndCurrentSeasonCommand();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
