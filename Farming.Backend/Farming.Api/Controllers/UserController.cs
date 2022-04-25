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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddDelivery([FromBody] AddUserRequest addUserRequest)
        {
            var command = _mapsterMapper.From(addUserRequest).AdaptToType<AddUserCommand>();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("changeActive")]
        public async Task<IActionResult> ChangeActive([FromQuery] Guid userId)
        {
            var currentUserId = TemporaryUser.Id();

            var command = new ChangeUserActiveCommand(userId, currentUserId);

            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("changeRole")]
        public async Task<IActionResult> ChangeRole([FromQuery] Guid userId)
        {
            var currentUserId = TemporaryUser.Id();

            var command = new ChangeUserRoleCommand(userId, currentUserId);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
