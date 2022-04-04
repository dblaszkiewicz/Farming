using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class PesticideWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PesticideWarehouseController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("addDelivery")]
        public async Task<IActionResult> AddDelivery([FromBody] AddPesticideWarehouseDeliveryRequest addPesticideWarehouseDeliveryDto)
        {
            var command = _mapsterMapper.From(addPesticideWarehouseDeliveryDto).AdaptToType<AddPesticideWarehouseDeliveryCommand>();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
