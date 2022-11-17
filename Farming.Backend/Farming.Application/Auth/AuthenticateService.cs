using Farming.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Farming.Application.Auth
{
    internal sealed class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthConfiguration _configuration;

        public AuthenticateService(IAuthConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Authenticate(User user)
        {
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.JwtSecret();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("tenantId", user.TenantId.ToString()),
                    new Claim("id", user.Id.Value.ToString()),
                    new Claim("name", user.Name.Value),
                    new Claim("isAdmin", user.IsAdmin.Value.ToString()),
                    new Claim("isAuthorized", true.ToString()),
                    new Claim("isActive", user.Active.Value.ToString())
                }),

                Expires = new DateTimeOffset(DateTimeOffset.UtcNow.Date).AddDays(1).AddHours(3).UtcDateTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
