using Farming.Application.Commands;
using Farming.Application.Queries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class LandController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public LandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLandsWithPlantQuery());

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPut("destroy")]
        public async Task<IActionResult> Destroy([FromQuery] Guid landId)
        {
            var command = new ChangeLandToDestroyedCommand(landId);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("harvest")]
        public async Task<IActionResult> Harvest([FromQuery] Guid landId)
        {
            var command = new ChangeLandToHarvestedCommand(landId);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
