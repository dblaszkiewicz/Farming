using Farming.Application.Auth;
using Farming.Domain.Factories;
using Farming.Domain.Policies;
using Farming.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Farming.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IAuthConfiguration, AuthConfiguration>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();

            services.AddSingleton<IFertilizerPolicy, FertilizerPolicy>();
            services.AddSingleton<IFertilizerWarehouseStatePolicy, FertilizerWarehouseStatePolicy>();
            services.AddSingleton<ILandPolicy, LandPolicy>();
            services.AddSingleton<IPesticidePolicy, PesticidePolicy>();
            services.AddSingleton<IPesticideWarehouseStatePolicy, PesticideWarehouseStatePolicy>();
            services.AddSingleton<IPlantPolicy, PlantPolicy>();
            services.AddSingleton<IPlantWarehouseStatePolicy, PlantWarehouseStatePolicy>();

            services.AddSingleton<IPlantActionFactory, PlantActionFactory>();
            services.AddSingleton<IPesticideActionFactory, PesticideActionFactory>();
            services.AddSingleton<IFertilizerActionFactory, FertilizerActionFactory>();

            services.AddSingleton<IFertilizerDomainService, FertilizerDomainService>();
            services.AddSingleton<IPesticideDomainService, PesticideDomainService>();
            services.AddSingleton<IPlantDomainService, PlantDomainService>();

            return services;
        }
    }
}
