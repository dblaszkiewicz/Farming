using Farming.Application.Auth;
using Farming.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Farming.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IAuthConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var token = context.Request
                .Headers["Authorization"]
                .FirstOrDefault()?
                .Split(" ")
                .Last();

            if (token != null)
            {
                await AttachUserToContext(context, userRepository, token);
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, IUserRepository userRepository, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.JwtSecret());

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
            var user = await userRepository.GetAsync(userId);

            context.Items["User"] = user;
            context.Items["UserId"] = user.Id.Value;
        }
    }
}
