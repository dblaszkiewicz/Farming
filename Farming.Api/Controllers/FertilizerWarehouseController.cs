using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.DTO;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class FertilizerWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public FertilizerWarehouseController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetFertilizerAdapterConfig());
        }

    [HttpPost("AddFertilizerWarehouseDelivery")]
        public async Task<IActionResult> AddFertilizerWarehouseDelivery([FromBody] AddFertilizerWarehouseDeliveryDto addFertilizerWarehouseDeliveryDto)
        {
            Guid fertilizerWarehouseId = new Guid("7036CC33-4F6E-477F-B3BA-CF9B8A1498B6");
            Guid fertilizerId = new Guid("940a5152-5537-4810-820b-bfa33d69cccf");
            Guid userId = new Guid("F2207741-E86D-4E71-810F-C7C1C3C3D314");

            addFertilizerWarehouseDeliveryDto.UserId = userId;
            addFertilizerWarehouseDeliveryDto.FertilizerId = fertilizerId;
            addFertilizerWarehouseDeliveryDto.FertilizerWarehouseId = fertilizerWarehouseId;
            addFertilizerWarehouseDeliveryDto.Price = 10;
            addFertilizerWarehouseDeliveryDto.Quantity = 10;

            var command = _mapsterMapper.From(addFertilizerWarehouseDeliveryDto).AdaptToType<AddFertilizerWarehouseDeliveryCommand>();

            var result = await _mediator.Send(command);

            return Ok();
        }
    }
}
