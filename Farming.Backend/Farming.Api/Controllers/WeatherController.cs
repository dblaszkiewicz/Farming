using Farming.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("weatherByPlace")]
        public async Task<IActionResult> GetAllWithPlant([FromQuery] string place)
        {
            var result = await _mediator.Send(new GetWeatherByPlaceQuery(place));

            return Ok(result);
        }
    }
}
