using Farming.Api.Helpers;
using Farming.Api.Middleware;

namespace Farming.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserHelper, CurrentUserHelper>();
            services.AddScoped<MultiTenantServiceMiddleware>();

            return services;
        }
    }
}
