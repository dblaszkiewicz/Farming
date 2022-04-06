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
    public class FertilizerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public FertilizerController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpGet("getNameById")]
        public async Task<IActionResult> GetNameById([FromQuery] Guid fertilizerId)
        {
            var command = new GetFertilizerNameByIdQuery(fertilizerId);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("processAction")]
        public async Task<IActionResult> ProcessAction([FromBody] ProcessFertilizerActionRequest processFertilizerActionDto)
        {
            var command = _mapsterMapper.From(processFertilizerActionDto).AdaptToType<ProcessFertilizerActionCommand>();
            command.UserId = TemporaryUser.Id();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllFertilizersQuery());

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("getByType")]
        public async Task<IActionResult> GetByType([FromQuery] Guid fertilizerTypeId)
        {
            var result = await _mediator.Send(new GetFertilizersByTypeQuery(fertilizerTypeId));

            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpGet("getByPlant")]
        public async Task<IActionResult> GetByPlant([FromQuery] Guid plantId)
        {
            var result = await _mediator.Send(new GetSuitableFertilizersByPlantQuery(plantId));

            return result.Any() ? Ok(result) : NotFound();
        }
    }
}
