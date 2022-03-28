using Farming.Application.Commands;
using Farming.Application.DTO;
using Mapster;

namespace Farming.Api.MapsterProfiles
{
    public static class MapsterProfile
    {
        public static TypeAdapterConfig GetAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddFertilizerWarehouseDeliveryDto, AddFertilizerWarehouseDeliveryCommand>();
            config.NewConfig<AddPesticideWarehouseDeliveryDto, AddPesticideWarehouseDeliveryCommand>();
            config.NewConfig<AddPlantActionDto, AddPlantActionCommand>();

            return config;
        }
    }
}
