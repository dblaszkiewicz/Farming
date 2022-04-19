using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.Queries;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/[controller]")]
    public class PlantController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PlantController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("processAction")]
        public async Task<IActionResult> ProcessAction([FromBody] AddPlantActionRequest addPlantActionDto)
        {
            var command = _mapsterMapper.From(addPlantActionDto).AdaptToType<ProcessPlantActionCommand>();
            command.UserId = TemporaryUser.Id();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPlantsQuery());

            return result.Any() ? Ok(result) : NotFound();
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
