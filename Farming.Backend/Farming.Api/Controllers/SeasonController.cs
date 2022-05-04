using Farming.Api.Auth;
using Farming.Api.Helpers;
using Farming.Application.Commands;
using Farming.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SeasonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserHelper _currentUserHelper;

        public SeasonController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _currentUserHelper = currentUserHelper;
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
            var command = new StartNewSeasonCommand(_currentUserHelper.GetId());
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("endCurrent")]
        public async Task<IActionResult> EndCurrentSeason()
        {
            var command = new EndCurrentSeasonCommand(_currentUserHelper.GetId());
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
