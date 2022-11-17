using Farming.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Farming.Api.Auth
{
    public static class AuthorizationFilterContextExtensions
    {
        public static Guid UserId(this AuthorizationFilterContext context)
        {
            var userIdStr = context.HttpContext.Items["UserId"]?.ToString();
            Guid userId;

            if (!Guid.TryParse(userIdStr, out userId))
            {
                return Guid.Empty;
            }

            return userId;
        }

        public static Guid TenantId(this AuthorizationFilterContext context)
        {
            var tenantIdStr = context.HttpContext.Items["TenantId"]?.ToString();
            Guid tenantId;

            if (!Guid.TryParse(tenantIdStr, out tenantId))
            {
                return Guid.Empty;
            }

            return tenantId;
        }

        public static bool IsAdmin(this AuthorizationFilterContext context)
        {
            return false;
        }
    }
}
