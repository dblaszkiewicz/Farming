using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.DTO.Requests;
using Farming.Application.Queries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class PlantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PlantController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("processPlantAction")]
        public async Task<IActionResult> ProcessPlantAction([FromBody] AddPlantActionDtoRequest addPlantActionDto)
        {
            var command = _mapsterMapper.From(addPlantActionDto).AdaptToType<ProcessPlantActionCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("allPlants")]
        public async Task<IActionResult> GetAllPlants()
        {
            var result = await _mediator.Send(new GetAllPlantsQuery());

            return result.Any() ? Ok(result) : NotFound();
        }
    }
}
