using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class FertilizerWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public FertilizerWarehouseController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("addDelivery")]
        public async Task<IActionResult> AddDelivery([FromBody] AddFertilizerWarehouseDeliveryRequest addFertilizerWarehouseDeliveryDto)
        {
            var command = _mapsterMapper.From(addFertilizerWarehouseDeliveryDto).AdaptToType<AddFertilizerWarehouseDeliveryCommand>();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
