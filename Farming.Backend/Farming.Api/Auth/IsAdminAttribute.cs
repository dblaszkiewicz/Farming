using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Farming.Api.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IsAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.IsAdmin())
            {
                context.Result = new JsonResult(new { message = "Forbidden" })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }
    }
}
