using Farming.Shared.Abstractions.Commands;

namespace Farming.Application.Queries.Auth
{
    public class AuthenticateUserResponse : IResponse
    {
        public string Token { get; set; }

        public AuthenticateUserResponse(string token)
        {
            Token = token;
        }
    }
}
