using Farming.Api.Auth;
using Farming.Api.Helpers;
using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Queries;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PesticideWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;
        private readonly ICurrentUserHelper _currentUserHelper;

        public PesticideWarehouseController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
            _currentUserHelper = currentUserHelper;
        }

        [HttpGet("getNameById")]
        public async Task<IActionResult> GetNameById([FromQuery] Guid warehouseId)
        {
            var command = new GetPesticideWarehouseNameByIdQuery(warehouseId);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("addDelivery")]
        public async Task<IActionResult> AddDelivery([FromBody] AddPesticideWarehouseDeliveryRequest addPesticideWarehouseDeliveryDto)
        {
            var command = _mapsterMapper.From(addPesticideWarehouseDeliveryDto).AdaptToType<AddPesticideWarehouseDeliveryCommand>();
            command.UserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var command = new GetAllPesticideWarehousesQuery();
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getStatesByWarehouse")]
        public async Task<IActionResult> GetStatesByWarehouse([FromQuery] Guid warehouseId)
        {
            var command = new GetPesticideStatesByWarehouseQuery(warehouseId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getStatesByWarehouseAndPlant")]
        public async Task<IActionResult> GetStatesByWarehouseAndPlant([FromQuery] Guid warehouseId, [FromQuery] Guid plantId)
        {
            var command = new GetPesticideStatesByWarehouseAndPlantQuery(warehouseId, plantId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getDeliveriesByWarehouse")]
        public async Task<IActionResult> GetDeliveriesByWarehouse([FromQuery] Guid warehouseId)
        {
            var command = new GetPesticideDeliveriesByWarehouseQuery(warehouseId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("getDeliveriesByWarehouseAndPesticide")]
        public async Task<IActionResult> GetDeliveriesByWarehouseAndFertilizer([FromQuery] Guid warehouseId, [FromQuery] Guid pesticideId)
        {
            var command = new GetPesticideDeliveriesByWarehouseAndPesticideQuery(warehouseId, pesticideId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
