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
    }
}
