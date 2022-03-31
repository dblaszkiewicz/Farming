using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class PesticideController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PesticideController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("processPesticideAction")]
        public async Task<IActionResult> ProcessPlantAction([FromBody] AddPesticideActionRequest addPesticideActionDto)
        {
            var command = _mapsterMapper.From(addPesticideActionDto).AdaptToType<ProcessPesticideActionCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
