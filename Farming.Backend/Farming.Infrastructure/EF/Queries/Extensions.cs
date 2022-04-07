﻿using Farming.Application.DTO;
using Farming.Infrastructure.EF.Models;

namespace Farming.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PlantDto AsDto(this PlantReadModel readModel)
        {
            return new PlantDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Description = readModel.Description,
                RequiredAmountPerHectare = readModel.RequiredAmountPerHectare
            };
        }

        public static FertilizerDto AsDto(this FertilizerReadModel readModel)
        {
            return new FertilizerDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Description = readModel.Description,
                RequiredAmountPerHectare = readModel.RequiredAmountPerHectare
            };
        }

        public static PesticideDto AsDto(this PesticideReadModel readModel)
        {
            return new PesticideDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Description = readModel.Description,
                RequiredAmountPerHectare = readModel.RequiredAmountPerHectare
            };
        }

        public static PlantWarehouseDto AsDto(this PlantWarehouseReadModel readModel)
        {
            return new PlantWarehouseDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
            };
        }

        public static FertilizerWarehouseDto AsDto(this FertilizerWarehouseReadModel readModel)
        {
            return new FertilizerWarehouseDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
            };
        }

        public static PesticideWarehouseDto AsDto(this PesticideWarehouseReadModel readModel)
        {
            return new PesticideWarehouseDto()
            {
                Id = readModel.Id,
                Name = readModel.Name,
            };
        }

        public static FertilizerStateDto AsDto(this FertilizerWarehouseStateReadModel readModel)
        {
            var enoughForArea = readModel.Quantity / readModel.Fertilizer.RequiredAmountPerHectare;
            return new FertilizerStateDto()
            {
                FertilizerId = readModel.FertilizerId,
                FertilizerTypeId = readModel.Fertilizer.FertilizerTypeId,
                FertilizerName = readModel.Fertilizer.Name,
                FertilizerTypeName = readModel.Fertilizer.FertilizerType.Name,
                Quantity = readModel.Quantity,
                RequiredAmountPerHectare = readModel.Fertilizer.RequiredAmountPerHectare,
                EnoughForArea = enoughForArea
            };
        }

        public static PesticideStateDto AsDto(this PesticideWarehouseStateReadModel readModel)
        {
            var enoughForArea = readModel.Quantity / readModel.Pesticide.RequiredAmountPerHectare;
            return new PesticideStateDto()
            {
                PesticideId = readModel.PesticideId,
                PesticideTypeId = readModel.Pesticide.PesticideTypeId,
                PesticideName = readModel.Pesticide.Name,
                PesticideTypeName = readModel.Pesticide.PesticideType.Name,
                Quantity = readModel.Quantity,
                RequiredAmountPerHectare = readModel.Pesticide.RequiredAmountPerHectare,
                EnoughForArea = enoughForArea
            };
        }

        public static FertilizerDeliveryByWarehouseDto AsDtoByWarehouse(this FertilizerWarehouseDeliveryReadModel readModel)
        {
            return new FertilizerDeliveryByWarehouseDto()
            {
                Name = readModel.Fertilizer.Name,
                UserName = readModel.User.FirstName,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerTon = readModel.Quantity / readModel.Price * 1000
            };
        }

        public static PesticideDeliveryByWarehouseDto AsDtoByWarehouse(this PesticideWarehouseDeliveryReadModel readModel)
        {
            return new PesticideDeliveryByWarehouseDto()
            {
                Name = readModel.Pesticide.Name,
                UserName = readModel.User.FirstName,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerLiter = readModel.Quantity / readModel.Price * 1000
            };
        }

        public static FertilizerDeliveryDto AsDtoByFertilzier(this FertilizerWarehouseDeliveryReadModel readModel)
        {
            return new FertilizerDeliveryDto()
            {
                UserName = readModel.User.FirstName,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerTon = readModel.Quantity / readModel.Price * 1000
            };
        }

        public static PesticideDeliveryDto AsDtoByPesticide(this PesticideWarehouseDeliveryReadModel readModel)
        {
            return new PesticideDeliveryDto()
            {
                UserName = readModel.User.FirstName,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerLiter = readModel.Quantity / readModel.Price * 1000
            };
        }
    }
}
