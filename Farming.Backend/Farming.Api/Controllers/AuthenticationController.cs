using Farming.Api.MapsterProfiles;
using Farming.Application.Queries;
using Farming.Application.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDto authenticateUserDto)
        {
            var query = _mapsterMapper.From(authenticateUserDto).AdaptToType<AuthenticateUserQuery>();
            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
