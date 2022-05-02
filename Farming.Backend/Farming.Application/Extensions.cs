using Farming.Application.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace Farming.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IAuthConfiguration, AuthConfiguration>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            return services;
        }
    }
}
