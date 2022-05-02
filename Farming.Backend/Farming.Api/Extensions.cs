using Farming.Api.Helpers;

namespace Farming.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUserHelper, CurrentUserHelper>();

            return services;
        }
    }
}
