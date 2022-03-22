using Farming.Application.Commands;
using Farming.Application.DTO;
using Mapster;

namespace Farming.Api.MapsterProfiles
{
    public static class MapsterProfile
    {
        public static TypeAdapterConfig GetFertilizerAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddFertilizerWarehouseDeliveryDto, AddFertilizerWarehouseDeliveryCommand>();
            return config;
        }

        public static TypeAdapterConfig GetPesticideAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddPesticideWarehouseDeliveryDto, AddPesticideWarehouseDeliveryCommand>();
            return config;
        }
    }
}
