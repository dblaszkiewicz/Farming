using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
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
        public async Task<IActionResult> ProcessPlantAction([FromBody] ProcessFertilizerActionRequest processFertilizerActionDto)
        {
            var command = _mapsterMapper.From(processFertilizerActionDto).AdaptToType<ProcessFertilizerActionCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
