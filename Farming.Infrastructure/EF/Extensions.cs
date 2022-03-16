using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Options;
using Farming.Infrastructure.EF.Repositories;
using Farming.Shared.Options;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farming.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFertilizerWarehouseRepository, FertilizerWarehouseRepository>();

            var options = configuration.GetOptions<SqlOptions>("Sql");
            
            services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
