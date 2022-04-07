using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Queries;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class PlantWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PlantWarehouseController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpGet("getNameById")]
        public async Task<IActionResult> GetNameById([FromQuery] Guid warehouseId)
        {
            var command = new GetPlantWarehouseNameByIdQuery(warehouseId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("addDelivery")]
        public async Task<IActionResult> AddDelivery([FromBody] AddPlantWarehouseDeliveryRequest addPlantWarehouseDeliveryDto)
        {
            var command = _mapsterMapper.From(addPlantWarehouseDeliveryDto).AdaptToType<AddPlantWarehouseDeliveryCommand>();
            command.UserId = TemporaryUser.Id();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllPlantWarehousesQuery();
            var result = await _mediator.Send(command);

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("getStatesByWarehouse")]
        public async Task<IActionResult> GetStatesByWarehouse([FromQuery] Guid warehouseId)
        {
            var command = new GetPlantStatesByWarehouseQuery(warehouseId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getDeliveriesByWarehouse")]
        public async Task<IActionResult> GetDeliveriesByWarehouse([FromQuery] Guid warehouseId)
        {
            var command = new GetPlantDeliveriesByWarehouseQuery(warehouseId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getDeliveriesByWarehouseAndPlant")]
        public async Task<IActionResult> GetDeliveriesByWarehouseAndFertilizer([FromQuery] Guid warehouseId, [FromQuery] Guid plantId)
        {
            var command = new GetPlantDeliveriesByWarehouseAndPlantQuery(warehouseId, plantId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
