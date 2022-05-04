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
    public class LandController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserHelper _currentUserHelper;

        public LandController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _currentUserHelper = currentUserHelper;
        }

        [HttpGet("getAllWithPlant")]
        public async Task<IActionResult> GetAllWithPlant()
        {
            var result = await _mediator.Send(new GetAllLandsWithPlantQuery());

            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLandsQuery());
            return Ok(result);
        }

        [HttpPut("destroy")]
        public async Task<IActionResult> Destroy([FromQuery] Guid landId)
        {
            var command = new ChangeLandToDestroyedCommand(landId);
            command.CurrentUserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("harvest")]
        public async Task<IActionResult> Harvest([FromQuery] Guid landId)
        {
            var command = new ChangeLandToHarvestedCommand(landId);
            command.CurrentUserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
