using Microsoft.Extensions.Configuration;

namespace Farming.Application.Auth
{
    internal sealed class AuthConfiguration : IAuthConfiguration
    {
        private readonly IConfiguration _configuration;

        public AuthConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string JwtSecret()
        {
            return _configuration.GetSection("Authorization")["Secret"];
        }
    }
}
