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
    public class PesticideController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;
        private readonly ICurrentUserHelper _currentUserHelper;

        public PesticideController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
            _currentUserHelper = currentUserHelper;
        }

        [HttpPost("processAction")]
        public async Task<IActionResult> ProcessAction([FromBody] AddPesticideActionRequest addPesticideActionDto)
        {
            var command = _mapsterMapper.From(addPesticideActionDto).AdaptToType<ProcessPesticideActionCommand>();
            command.UserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPesticidesQuery());

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("getByType")]
        public async Task<IActionResult> GetByType([FromQuery] Guid pesticideTypeId)
        {
            var result = await _mediator.Send(new GetPesticidesByTypeQuery(pesticideTypeId));

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("getByPlant")]
        public async Task<IActionResult> GetByPlant([FromQuery] Guid plantId)
        {
            var result = await _mediator.Send(new GetSuitablePesticidesByPlantQuery(plantId));

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("getAllActions")]
        public async Task<IActionResult> GetAllActions(Guid seasonId, Guid landId)
        {
            var query = new GetPesticideActionsByLandAndSeasonQuery(seasonId, landId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
