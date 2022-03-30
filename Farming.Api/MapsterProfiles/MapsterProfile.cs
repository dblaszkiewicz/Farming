﻿using Farming.Application.Commands;
using Farming.Application.DTO.Requests;
using Mapster;

namespace Farming.Api.MapsterProfiles
{
    public static class MapsterProfile
    {
        public static TypeAdapterConfig GetAdapterConfig()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<AddFertilizerWarehouseDeliveryRequestDto, AddFertilizerWarehouseDeliveryCommand>();
            config.NewConfig<AddPesticideWarehouseDeliveryRequestDto, AddPesticideWarehouseDeliveryCommand>();
            config.NewConfig<AddPlantActionDtoRequest, ProcessPlantActionCommand>();
            config.NewConfig<ProcessFertilizerActionDtoRequest, ProcessFertilizerActionCommand>();

            return config;
        }
    }
}
