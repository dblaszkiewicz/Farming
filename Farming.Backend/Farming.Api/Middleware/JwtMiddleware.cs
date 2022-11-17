using Farming.Api.Auth;
using Farming.Application.Auth;
using Farming.Infrastructure.EF.MultiTenancy;
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

        public async Task Invoke(HttpContext context, ITenantSetter tenantSetter)
        {
            var token = context.Request
                .Headers["Authorization"]
                .FirstOrDefault()?
                .Split(" ")
                .Last();

            if (token != null)
            {
                await AttachUserToContext(context, tenantSetter, token);
            }

            await _next(context);
        }

        private async Task AttachUserToContext(HttpContext context, ITenantSetter tenantSetter, string token)
        {
            try
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
                var tenantId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "tenantId").Value);

                if (userId == Guid.Empty || tenantId == Guid.Empty)
                {
                    throw new Exception("XD");
                }

                context.Items["TenantId"] = tenantId;
                context.Items["UserId"] = userId;

                tenantSetter.SetTenant(tenantId);
            }
            catch (Exception ex)
            {
                throw new AuthorizationException(ex.Message);
            }
        }
    }
}
