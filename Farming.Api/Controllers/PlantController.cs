using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.DTO;
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
        public async Task<IActionResult> ProcessPlantAction([FromBody] AddPlantActionDto addPlantActionDto)
        {
            var command = _mapsterMapper.From(addPlantActionDto).AdaptToType<AddPlantActionCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
