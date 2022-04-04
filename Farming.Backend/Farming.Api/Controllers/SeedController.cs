using Farming.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("seed")]
        public async Task<IActionResult> AddFertilizerWarehouseDelivery()
        {
            var command = new SeedBasicDataCommand();
            
            await _mediator.Send(command);

            return Ok();
        }
    }
}
