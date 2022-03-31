using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Queries;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class FertilizerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public FertilizerController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("processFertilizerAction")]
        public async Task<IActionResult> ProcessFertilizerAction([FromBody] ProcessFertilizerActionRequest processFertilizerActionDto)
        {
            var command = _mapsterMapper.From(processFertilizerActionDto).AdaptToType<ProcessFertilizerActionCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("allFertilizers")]
        public async Task<IActionResult> GetAllFertilizers()
        {
            var result = await _mediator.Send(new GetAllFertilizersQuery());

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("fertilizersByType")]
        public async Task<IActionResult> GetFertilizersByType([FromQuery] Guid fertilizerTypeId)
        {
            var result = await _mediator.Send(new GetFertilizersByTypeQuery(fertilizerTypeId));

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("suitableFertilizersByPlant")]
        public async Task<IActionResult> Get([FromQuery] Guid plantId)
        {
            var result = await _mediator.Send(new GetSuitableFertilizersByPlantQuery(plantId));

            return result.Any() ? Ok(result) : NotFound();
        }
    }
}
