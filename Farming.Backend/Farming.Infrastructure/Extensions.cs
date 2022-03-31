using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farming.Infrastructure.EF;

namespace Farming.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSql(configuration);

            return services;
        }
    }
}
