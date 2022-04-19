using Farming.Application.Commands;
using Farming.Application.Queries;
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

        [HttpGet("getCurrent")]
        public async Task<IActionResult> GetCurrentSeason()
        {
            var query = new GetCurrentSeasonQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
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

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllSeasons()
        {
            var query = new GetAllSeasonsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
