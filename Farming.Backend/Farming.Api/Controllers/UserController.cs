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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;
        private readonly ICurrentUserHelper _currentUserHelper;
        

        public UserController(IMediator mediator, ICurrentUserHelper currentUserHelper)
        {
            _mediator = mediator;
            _currentUserHelper = currentUserHelper;
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
            command.CurrentUserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("changeActive")]
        public async Task<IActionResult> ChangeActive([FromQuery] Guid userId)
        {
            var currentUserId = _currentUserHelper.GetId();

            var command = new ChangeUserActiveCommand(userId, currentUserId);

            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("changeRole")]
        public async Task<IActionResult> ChangeRole([FromQuery] Guid userId)
        {
            var currentUserId = _currentUserHelper.GetId();

            var command = new ChangeUserRoleCommand(userId, currentUserId);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
        {
            var command = _mapsterMapper.From(changePasswordRequest).AdaptToType<ChangePasswordCommand>();
            command.UserId = _currentUserHelper.GetId();
            await _mediator.Send(command);
            return Ok();
        }
    }
}
