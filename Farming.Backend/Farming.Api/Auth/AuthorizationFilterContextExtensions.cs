using Farming.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Farming.Api.Auth
{
    public static class AuthorizationFilterContextExtensions
    {
        public static User User(this AuthorizationFilterContext context) =>
            (User)context.HttpContext.Items["User"];
    }
}
