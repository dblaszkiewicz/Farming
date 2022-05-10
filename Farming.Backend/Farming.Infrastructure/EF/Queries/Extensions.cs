using Farming.Application.Consts;
using Farming.Application.DTO;
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
                RequiredAmountPerHectare = readModel.RequiredAmountPerHectare,
                Unit = readModel.Unit
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

        public static PlantStateDto AsDto(this PlantWarehouseStateReadModel readModel)
        {
            var enoughForArea = readModel.Quantity / readModel.Plant.RequiredAmountPerHectare;
            return new PlantStateDto()
            {
                PlantId = readModel.PlantId,
                PlantName = readModel.Plant.Name,
                Quantity = readModel.Quantity,
                Unit = readModel.Plant.Unit,
                RequiredAmountPerHectare = readModel.Plant.RequiredAmountPerHectare,
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
                UserName = readModel.User.Name,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerTon = readModel.Price / readModel.Quantity * 1000
            };
        }

        public static PesticideDeliveryByWarehouseDto AsDtoByWarehouse(this PesticideWarehouseDeliveryReadModel readModel)
        {
            return new PesticideDeliveryByWarehouseDto()
            {
                Name = readModel.Pesticide.Name,
                UserName = readModel.User.Name,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerLiter = readModel.Price / readModel.Quantity * 1000
            };
        }

        public static PlantDeliveryByWarehouseDto AsDtoByWarehouse(this PlantWarehouseDeliveryReadModel readModel)
        {
            return new PlantDeliveryByWarehouseDto()
            {
                Name = readModel.Plant.Name,
                UserName = readModel.User.Name,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                Unit = readModel.Plant.Unit,
                RealizationDate = readModel.RealizationDate,
            };
        }

        public static FertilizerDeliveryDto AsDtoByFertilzier(this FertilizerWarehouseDeliveryReadModel readModel)
        {
            return new FertilizerDeliveryDto()
            {
                UserName = readModel.User.Name,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerTon = readModel.Price / readModel.Quantity * 1000
            };
        }

        public static PesticideDeliveryDto AsDtoByPesticide(this PesticideWarehouseDeliveryReadModel readModel)
        {
            return new PesticideDeliveryDto()
            {
                UserName = readModel.User.Name,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                RealizationDate = readModel.RealizationDate,
                PricePerLiter = readModel.Price / readModel.Quantity * 1000
            };
        }

        public static PlantDeliveryDto AsDtoByPlant(this PlantWarehouseDeliveryReadModel readModel)
        {
            return new PlantDeliveryDto()
            {
                UserName = readModel.User.Name,
                Price = readModel.Price,
                Quantity = readModel.Quantity,
                Unit = readModel.Plant.Unit,
                RealizationDate = readModel.RealizationDate,
            };
        }

        public static LandWithPlantedDto AsDtoWithPlant(this LandReadModel readModel)
        {
            return new LandWithPlantedDto()
            {
                Id = readModel.Id,
                Area = readModel.Area,
                LandClass = readModel.LandClass,
                Name = readModel.Name,
                Status = readModel.Status,
                IsPlanted = readModel.Status == LandStatus.Planted,
            };
        }

        public static LandDto AsDto(this LandReadModel readModel)
        {
            return new LandDto()
            {
                Id = readModel.Id,
                Area = readModel.Area,
                LandClass = readModel.LandClass,
                Name = readModel.Name,
            };
        }

        public static UserDto AsDto(this UserReadModel readModel)
        {
            return new UserDto()
            {
                Id = readModel.Id,
                Login = readModel.Login,
                Name = readModel.Name,
                Active = readModel.Active,
                IsAdmin = readModel.IsAdmin,
                Created = readModel.Created
            };
        }
    }
}
