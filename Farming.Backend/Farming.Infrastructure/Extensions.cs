using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farming.Infrastructure.EF;
using Microsoft.AspNetCore.Builder;

namespace Farming.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSql(configuration);

            return services;
        }

        public static IApplicationBuilder CreateDatabase(this IApplicationBuilder app)
        {
            app.AddDb();

            return app;
        }
    }
}
