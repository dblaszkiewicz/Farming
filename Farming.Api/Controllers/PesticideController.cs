using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Queries;
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
        public async Task<IActionResult> ProcessPesticideAction([FromBody] AddPesticideActionRequest addPesticideActionDto)
        {
            var command = _mapsterMapper.From(addPesticideActionDto).AdaptToType<ProcessPesticideActionCommand>();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("allPesticides")]
        public async Task<IActionResult> GetAllPesticides()
        {
            var result = await _mediator.Send(new GetAllPesticidesQuery());

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("pesticidesByType")]
        public async Task<IActionResult> GetFertilizersByType([FromQuery] Guid pesticideTypeId)
        {
            var result = await _mediator.Send(new GetPesticidesByTypeQuery(pesticideTypeId));

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("suitablePesticidesByPlant")]
        public async Task<IActionResult> Get([FromQuery] Guid plantId)
        {
            var result = await _mediator.Send(new GetSuitablePesticidesByPlantQuery(plantId));

            return result.Any() ? Ok(result) : NotFound();
        }
    }
}
