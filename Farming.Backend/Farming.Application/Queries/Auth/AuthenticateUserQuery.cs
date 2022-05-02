using Farming.Application.Queries.Auth;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Queries
{
    public class AuthenticateUserQuery : IRequest<Response<AuthenticateUserResponse>>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
