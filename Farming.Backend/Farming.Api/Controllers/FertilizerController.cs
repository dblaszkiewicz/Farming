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
    public class FertilizerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;
        private readonly ICurrentUserHelper _currentUserHelper;

        public FertilizerController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
            _currentUserHelper = currentUserHelper;
        }


        [HttpPost("processAction")]
        public async Task<IActionResult> ProcessAction([FromBody] ProcessFertilizerActionRequest processFertilizerActionDto)
        {
            var command = _mapsterMapper.From(processFertilizerActionDto).AdaptToType<ProcessFertilizerActionCommand>();
            command.UserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFertilizersQuery());

            return Ok(result);
        }

        [HttpGet("getByType")]
        public async Task<IActionResult> GetByType([FromQuery] Guid fertilizerTypeId)
        {
            var result = await _mediator.Send(new GetFertilizersByTypeQuery(fertilizerTypeId));

            return Ok(result);
        }

        [HttpGet("getByPlant")]
        public async Task<IActionResult> GetByPlant([FromQuery] Guid plantId)
        {
            var result = await _mediator.Send(new GetSuitableFertilizersByPlantQuery(plantId));

            return Ok(result);
        }

        [HttpGet("getAllActions")]
        public async Task<IActionResult> GetAllActions(Guid seasonId, Guid landId)
        {
            var query = new GetFertilizerActionsByLandAndSeasonQuery(seasonId, landId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
