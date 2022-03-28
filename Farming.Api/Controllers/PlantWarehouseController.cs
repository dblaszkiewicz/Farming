using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.DTO.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class PlantWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PlantWarehouseController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("addPlantWarehouseDelivery")]
        public async Task<IActionResult> AddFertilizerWarehouseDelivery([FromBody] AddPlantWarehouseDeliveryRequestDto addPlantWarehouseDeliveryDto)
        {
            var command = _mapsterMapper.From(addPlantWarehouseDeliveryDto).AdaptToType<AddPlantWarehouseDeliveryCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
