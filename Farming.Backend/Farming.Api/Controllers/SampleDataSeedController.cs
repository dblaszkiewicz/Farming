using Farming.Api.Auth;
using Farming.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Farming.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SampleDataSeedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SampleDataSeedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Seed()
        {
            var query = new SampleDataSeedQuery();
            return Ok(await _mediator.Send(query));
        }
    }
}
