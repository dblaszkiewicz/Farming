using Farming.Application.Services;
using Farming.Domain.Repositories;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Options;
using Farming.Infrastructure.EF.Repositories;
using Farming.Infrastructure.EF.Services;
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

            var options = configuration.GetOptions<SqlOptions>("Sql");
            
            services.AddDbContext<ReadDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
