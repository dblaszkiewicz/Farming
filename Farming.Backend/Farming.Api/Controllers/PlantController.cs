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
    public class PlantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;
        private readonly ICurrentUserHelper _currentUserHelper;

        public PlantController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
            _currentUserHelper = currentUserHelper;
        }

        [HttpPost("processAction")]
        public async Task<IActionResult> ProcessAction([FromBody] AddPlantActionRequest addPlantActionDto)
        {
            var command = _mapsterMapper.From(addPlantActionDto).AdaptToType<ProcessPlantActionCommand>();
            command.UserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPlantsQuery());

            return Ok(result);
        }

        [HttpGet("getAllActions")]
        public async Task<IActionResult> GetAllActions(Guid seasonId, Guid landId)
        {
            var query = new GetPlantActionsByLandAndSeasonQuery(seasonId, landId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
