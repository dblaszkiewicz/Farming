using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.MultiTenancy;
using Farming.Infrastructure.EF.Options;
using Farming.Infrastructure.EF.Repositories;
using Farming.Infrastructure.EF.Services;
using Farming.Shared.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Farming.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScopedAs<TenantService>(new[]
            {
                typeof(ITenantGetter),
                typeof(ITenantSetter)
            });

            services.AddScoped<IFertilizerTypeRepository, FertilizerTypeRepository>();
            services.AddScoped<IFertilizerWarehouseRepository, FertilizerWarehouseRepository>();
            services.AddScoped<ILandRepository, LandRepository>();
            services.AddScoped<IPesticideTypeRepository, PesticideTypeRepository>();
            services.AddScoped<IPesticideWarehouseRepository, PesticideWarehouseRepository>();
            services.AddScoped<IPlantRepository, PlantRepository>();
            services.AddScoped<IPlantWarehouseRepository, PlantWarehouseRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFertilizerRepository, FertilizerRepository>();
            services.AddScoped<IPesticideRepository, PesticideRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserReadService, UserReadService>();
            services.AddScoped<IFertilizerReadService, FertilizerReadService>();
            services.AddScoped<IFertilizerWarehouseReadService, FertilizerWarehouseReadService>();
            services.AddScoped<IPesticideReadService, PesticideReadService>();
            services.AddScoped<IPesticideWarehouseReadService, PesticideWarehouseReadService>();
            services.AddScoped<IPlantReadService, PlantReadService>();
            services.AddScoped<IPlantWarehouseReadService, PlantWarehouseReadService>();
            services.AddScoped<ILandReadService, LandReadService>();
            services.AddScoped<ISeasonReadService, SeasonReadService>();

            services.AddScoped<IWeatherService, WeatherService>();

            var options = configuration.GetOptions<DatabaseOptions>("PostgreSql");

            services.AddDbContext<ReadDbContext>(ctx =>
            {
                ctx.EnableSensitiveDataLogging();
                ctx.UseNpgsql(options.ConnectionString);
            });

            services.AddDbContext<WriteDbContext>(ctx =>
            {
                ctx.EnableSensitiveDataLogging();
                ctx.UseNpgsql(options.ConnectionString);
            });

            return services;
        }

        public static IApplicationBuilder AddDb(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ReadDbContext>();

                DbInitializer.CreateAndSeedDatabase(context);
            }

            return app;
        }

        public static IServiceCollection AddScopedAs<T>(this IServiceCollection services, IEnumerable<Type> types)
            where T : class
        {
            services.AddScoped<T>();

            foreach (var type in types)
            {
                services.AddScoped(type, svc =>
                {
                    var rs = svc.GetRequiredService<T>();
                    return rs;
                });
            }

            return services;
        }
    }
}
