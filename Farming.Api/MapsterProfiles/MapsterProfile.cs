using Farming.Application.Commands;
using Farming.Application.Requests;
using Mapster;

namespace Farming.Api.MapsterProfiles
{
    public static class MapsterProfile
    {
        public static TypeAdapterConfig GetAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddFertilizerWarehouseDeliveryRequest, AddFertilizerWarehouseDeliveryCommand>();
            config.NewConfig<AddPesticideWarehouseDeliveryRequest, AddPesticideWarehouseDeliveryCommand>();
            config.NewConfig<AddPlantActionRequest, ProcessPlantActionCommand>();
            config.NewConfig<ProcessFertilizerActionRequest, ProcessFertilizerActionCommand>();

            return config;
        }
    }
}
